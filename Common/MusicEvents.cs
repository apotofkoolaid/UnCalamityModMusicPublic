using System;
using System.Collections.Generic;
using System.IO;
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

        public static List<string> PlayedEvents { get; set; } = [];

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

            for (int i = 0; i < PlayedEvents.Count; i++)
            {
                tag[$"VCMM:PlayedMusicEvent{i}"] = PlayedEvents[i];
            }
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
            ModPacket packet = UnCalamityModMusic.Instance.GetPacket();
            packet.Write((byte)MusicEventsNetcode.VanillaCalamityModMusicMessageType.MusicEventSyncRequest);
            packet.Send();
        }

        public static void FulfillSyncRequest(int requester)
        {
            // Only fulfill requests as the server host
            if (!Main.dedServ)
            {
                return;
            }

            ModPacket packet = UnCalamityModMusic.Instance.GetPacket();
            packet.Write((byte)MusicEventsNetcode.VanillaCalamityModMusicMessageType.MusicEventSyncResponse);

            int trackCount = PlayedEvents.Count;
            packet.Write(trackCount);

            for (int i = 0; i < trackCount; i++)
            {
                packet.Write(PlayedEvents[i]);
            }

            packet.Send(toClient: requester);
        }

        public static void ReceiveSyncResponse(BinaryReader reader)
        {
            // Only receive info on clients
            if (Main.dedServ)
            {
                return;
            }

            PlayedEvents.Clear();
            int trackCount = reader.ReadInt32();

            for (int i = 0; i < trackCount; i++)
            {
                PlayedEvents.Add(reader.ReadString());
            }
        }

        #endregion
    }

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

    public class MusicEventsNetcode
    {
        public enum VanillaCalamityModMusicMessageType : byte
        {
            MusicEventSyncRequest,
            MusicEventSyncResponse
        }

        public static void HandlePacket(Mod mod, BinaryReader reader, int whoAmI)
        {
            try
            {
                VanillaCalamityModMusicMessageType msgType = (VanillaCalamityModMusicMessageType)reader.ReadByte();
                switch (msgType)
                {
                    case VanillaCalamityModMusicMessageType.MusicEventSyncRequest:
                        {
                            MusicEvents.FulfillSyncRequest(whoAmI);
                            break;
                        }

                    case VanillaCalamityModMusicMessageType.MusicEventSyncResponse:
                        {
                            MusicEvents.ReceiveSyncResponse(reader);
                            break;
                        }

                    default:
                        {
                            UnCalamityModMusic.Instance.Logger.Error($"Failed to parse VCMM packet: No VCMM packet exists with ID {msgType}.");
                            throw new Exception("Failed to parse VCMM packet: Invalid VCMM packet ID.");
                        }
                }
            }
            catch (Exception e)
            {
                if (e is EndOfStreamException eose)
                {
                    UnCalamityModMusic.Instance.Logger.Error("Failed to parse VCMM packet: Packet was too short, missing data, or otherwise corrupt.", eose);
                }
                else if (e is ObjectDisposedException ode)
                {
                    UnCalamityModMusic.Instance.Logger.Error("Failed to parse VCMM packet: Packet reader disposed or destroyed.", ode);
                }
                else if (e is IOException ioe)
                {
                    UnCalamityModMusic.Instance.Logger.Error("Failed to parse VCMM packet: An unknown I/O error occurred.", ioe);
                }
                else
                {
                    throw;
                }
            }
        }
    }
}
