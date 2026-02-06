using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using UnCalamityModMusic.Common.Configs;

namespace UnCalamityModMusic.Common
{
    // This system was created by Nycro for the main Calamity Mod.
    // An altered form of it is here so VCMM doesn't have to rely on external code.
    public record class MusicEventEntry(string Id, int Song, TimeSpan Length, TimeSpan IntroSilence, TimeSpan OutroSilence, Func<bool> ShouldPlay, Func<bool> Enabled);

    public class MusicEvents : ModSystem
    {
        #region Statics

        public static MusicEventEntry CurrentEvent { get; set; } = null;

        public static DateTime? TrackStart { get; set; } = null;

        public static DateTime? TrackEnd { get; set; } = null;

        public static int LastPlayedEvent { get; set; } = -1;

        public static TimeSpan? OutroSilence { get; set; } = null;

        public static bool NoFade { get; set; } = false;

        public static Thread EventTrackerThread { get; set; } = null;

        public static HashSet<string> PlayedEvents { get; set; } = [];

        public static List<MusicEventEntry> EventCollection { get; set; } = [];

        private static bool oldWorld { get; set; } = true;

        #endregion

        #region Events List

        public override void OnModLoad()
        {
            static void AddEntry(string eventId, string songName, TimeSpan length, Func<bool> shouldPlay, Func<bool> enabled, TimeSpan? introSilence = null, TimeSpan? outroSilence = null)
            {
                MusicEventEntry entry = new(eventId, MusicPathing.GetMusicSlot(songName), length, introSilence ?? TimeSpan.Zero, outroSilence ?? TimeSpan.Zero, shouldPlay, enabled);
                EventCollection.Add(entry);
            }

            // Hardmode Interlude
            AddEntry("HardmodeStarted", "HardmodeInterlude", TimeSpan.FromSeconds(206.400d), () => Main.hardMode, () => ModContent.GetInstance<MusicConfig>().HardmodeInterlude);
        }

        public override void Unload() => EventCollection.Clear();

        #endregion

        #region Event Handling
        public override void PostUpdateTime()
        {
            // If the player is in Infernum's Lost Colosseum, do nothing (would prefer if this happened for all subworlds)
            if (MusicFlags.LostColosseum)
            {
                return;
            }

            // If the Boss Rush is active, any would-be music events should be cancelled out and marked as played
            if (MusicFlags.BossRush)
            {
                foreach (MusicEventEntry entry in EventCollection)
                {
                    if (entry.ShouldPlay())
                        PlayedEvents.Add(entry.Id);
                }

                TrackStart = null;
                LastPlayedEvent = -1;
                OutroSilence = null;

                TrackEnd = null;
                CurrentEvent = null;

                return;
            }

            // If the player has already completed conditions to trigger certain music events, we don't
            // want to queue a bunch of tracks to play as soon as they enter the world, so instead just mark them as played
            if (oldWorld)
            {
                foreach (MusicEventEntry entry in EventCollection)
                {
                    if (entry.ShouldPlay())
                        PlayedEvents.Add(entry.Id);
                }

                oldWorld = false;
            }

            // If the event has just finished, we want a little silence before fading back to normal
            if (TrackEnd is not null)
            {
                // `silence` is the time after a track ends before music goes back to normal
                TimeSpan silence = OutroSilence.Value;
                TimeSpan postTrack = DateTime.Now - TrackEnd.Value;

                // Play silence for the time specified
                if (postTrack < silence)
                {
                    int silenceSlot = MusicLoader.GetMusicSlot(Mod, "Assets/Sounds/Silence");
                    Main.musicBox2 = silenceSlot;
                }

                else
                {
                    LastPlayedEvent = -1;
                    TrackEnd = null;
                    OutroSilence = null;
                }

                return;
            }

            // Only check for new events to play if none is currently playing
            // This makes sure events always finish before a new one starts
            if (CurrentEvent is null)
            {
                foreach (MusicEventEntry musicEvent in EventCollection)
                {
                    // Make sure the event hasn't already played and SHOULD play
                    if (!PlayedEvents.Contains(musicEvent.Id) && musicEvent.ShouldPlay())
                    {
                        // Even if an event isn't marked as enabled, it should be counted
                        // as "played" so it isn't played when the player doesn't expect it
                        PlayedEvents.Add(musicEvent.Id);

                        // Events are always enabled on the server
                        if (Main.dedServ || musicEvent.Enabled())
                        {
                            // Assign the current event and start time
                            CurrentEvent = musicEvent;
                            TrackStart = DateTime.Now + musicEvent.IntroSilence;

                            // On clients, use a background thread to make sure the track always plays for exactly
                            // the specified length, regardless of if the game gets minimized, lags, or time becomes
                            // detangled from a consistent 60fps in any other way
                            if (!Main.dedServ)
                            {
                                EventTrackerThread = new(WatchMusicEvent);
                                EventTrackerThread.Start();
                            }

                            break;
                        }
                    }
                }
            }

            if (TrackStart is not null)
            {
                if (TrackStart > DateTime.Now)
                {
                    int silenceSlot = MusicLoader.GetMusicSlot(Mod, "Assets/Sounds/Silence");
                    Main.musicBox2 = silenceSlot;
                    NoFade = true;
                }

                else
                {
                    Main.musicBox2 = CurrentEvent.Song;

                    if (NoFade)
                    {
                        Main.musicFade[CurrentEvent.Song] = 1f;
                        NoFade = false;
                    }

                    // If the event has finished playing, mark the end as now and clear the current event
                    if (DateTime.Now - TrackStart >= CurrentEvent.Length)
                    {
                        int silenceSlot = MusicLoader.GetMusicSlot(Mod, "Assets/Sounds/Silence");
                        Main.musicBox2 = silenceSlot;
                        Main.musicFade[CurrentEvent.Song] = 0f;

                        TrackEnd = DateTime.Now;
                        LastPlayedEvent = CurrentEvent.Song;
                        OutroSilence = CurrentEvent.OutroSilence;

                        TrackStart = null;
                        CurrentEvent = null;
                    }
                }
            }
        }

        /// <summary>
        /// Watches for the game minimizing at any point, and adjusts the amount of time to play the song for accordingly
        /// </summary>
        public static void WatchMusicEvent()
        {
            DateTime? minimized = null;

            while (CurrentEvent is not null)
            {
                bool musicPaused = !Main.instance.IsActive;

                if (musicPaused && !minimized.HasValue)
                    minimized = DateTime.Now;

                else if (!musicPaused && minimized.HasValue)
                {
                    TrackStart += DateTime.Now - minimized.Value;
                    minimized = null;
                }
            }

            EventTrackerThread = null;
        }

        #endregion

        #region Event Saving

        public override void SaveWorldData(TagCompound tag)
        {
            tag["VCMM:PlayedMusicEventCount"] = PlayedEvents.Count;
            int i = 0;
            foreach (string playedEvent in PlayedEvents)
                tag[$"VCMM:PlayedMusicEventCount{i++}"] = playedEvent;
        }

        public override void LoadWorldData(TagCompound tag)
        {
            PlayedEvents.Clear();

            if (tag.TryGet("VCMM:PlayedMusicEventCount", out int playedMusicEventCount))
            {
                for (int i = 0; i < playedMusicEventCount; i++)
                {
                    if (tag.TryGet($"VCMM:PlayedMusicEvent{i}", out string playedEvent))
                        PlayedEvents.Add(playedEvent);
                }
            }

            oldWorld = false;
        }

        public override void OnWorldUnload()
        {
            oldWorld = true;
            TrackStart = null;
            TrackEnd = null;
            CurrentEvent = null;
            PlayedEvents.Clear();
            NoFade = false;
            LastPlayedEvent = -1;
        }

        #endregion

        #region Event Syncing

        public static void SendSyncRequest()
        {
            MusicEventSyncRequestPacket.Send();
        }

        #endregion
    }

    #region Multiplayer Syncing

    public class MusicEventsPlayer : ModPlayer
    {
        public override void OnEnterWorld()
        {
            if (Main.netMode == NetmodeID.MultiplayerClient && Player.whoAmI != Main.myPlayer)
            {
                MusicEvents.SendSyncRequest();
            }
        }
    }

    internal sealed class MusicEventSyncRequestPacket : MusicEventPacket
    {
        public static MusicEventSyncRequestPacket Instance { get; private set; }

        public static void Send(int toClient = -1, int ignoreClient = -1)
        {
            if (Main.netMode != NetmodeID.MultiplayerClient)
                return;

            var packet = Instance.CreateBasePacket();
            packet.Send(toClient, ignoreClient);
        }

        public override void HandlePacket(BinaryReader packet, int sender)
        {
            if (!Main.dedServ)
                return;

            MusicEventSyncResponsePacket.Send(toClient: sender);
        }
    }

    internal sealed class MusicEventSyncResponsePacket : MusicEventPacket
    {
        public static MusicEventSyncResponsePacket Instance { get; private set; }

        public static void Send(int toClient = -1, int ignoreClient = -1)
        {
            if (!Main.dedServ)
                return;

            var packet = Instance.CreateBasePacket();
            int trackCount = MusicEvents.PlayedEvents.Count;
            packet.Write(trackCount);

            foreach (string playedEvent in MusicEvents.PlayedEvents)
                packet.Write(playedEvent);

            packet.Send(toClient, ignoreClient);
        }

        public override void HandlePacket(BinaryReader packet, int sender)
        {
            if (Main.netMode != NetmodeID.MultiplayerClient)
            {
                int c = packet.ReadInt32();
                for (int i = 0; i < c; i++)
                    _ = packet.ReadString();

                return;
            }

            MusicEvents.PlayedEvents.Clear();

            int trackCount = packet.ReadInt32();
            for (int i = 0; i < trackCount; i++)
                MusicEvents.PlayedEvents.Add(packet.ReadString());
        }
    }

    internal abstract class MusicEventPacket : ILoadable
    {
        public abstract void HandlePacket(BinaryReader packet, int sender);

        private ushort _NetID;
        private PropertyInfo _Prop_Static_Instance;

        public void Load(Mod mod)
        {
            _NetID = MusicEventsNetcode.RegisterHandler(this);

            var type = GetType();
            var instanceProperty = type.GetProperty("Instance", BindingFlags.Public | BindingFlags.Static | BindingFlags.NonPublic);

            if (instanceProperty == null)
                return;

            if (!instanceProperty.PropertyType.IsAssignableFrom(type))
                UnCalamityModMusic.Instance.Logger.Error($"Packet instance's 'Instance' property is not asssignable with given type! [Failed On: '{type.FullName}']");

            instanceProperty.SetValue(null, this);
            _Prop_Static_Instance = instanceProperty;
        }

        public virtual void Unload()
        {
            _Prop_Static_Instance?.SetValue(null, null);
            _Prop_Static_Instance = null;
        }

        public void CloneAndBroadcast(BinaryReader packet, long startIndex, int length, int ignoreClient = -1)
        {
            if (!Main.dedServ)
                return;

            if (startIndex < 0)
                return;

            packet.BaseStream.Position = startIndex;

            Span<byte> buffer = length <= 256 ? stackalloc byte[length] : new byte[length];
            packet.BaseStream.Read(buffer);

            var newPacket = CreateBasePacket();
            newPacket.Write(buffer);
            newPacket.Send(ignoreClient);
        }

        public ModPacket CreateBasePacket()
        {
            var packet = UnCalamityModMusic.Instance.GetPacket();
            MusicEventsNetcode.WriteHandlerNetID(packet, _NetID);
            return packet;
        }
    }

    public class MusicEventsNetcode : ModSystem
    {
        private static List<MusicEventPacket> _PacketHandlers = [];

        internal static ushort RegisterHandler(MusicEventPacket handler)
        {
            var id = (ushort)_PacketHandlers.Count;
            _PacketHandlers.Add(handler);
            return id;
        }

        internal static void WriteHandlerNetID(BinaryWriter packet, ushort netID)
        {
            if (_PacketHandlers.Count > 256)
                packet.Write(netID);
            else
                packet.Write((byte)netID);
        }
    }
    #endregion
}