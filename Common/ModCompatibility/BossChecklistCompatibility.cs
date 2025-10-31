using System.Collections.Generic;
using Terraria.ModLoader;

namespace UnCalamityModMusic.Common.ModCompatibility
{
    public class BossChecklistCompatibility : ModSystem
    {
        public override void PostSetupContent()
        {
            BossChecklistSetup();
        }

        public void BossChecklistSetup()
        {
            var bossChecklist = ModLoader.TryGetMod("BossChecklist", out Mod checklist);

            if (!bossChecklist)
            {
                return;
            }

            var BossMusicBoxes = new Dictionary<string, object>
            {
                { "Terraria MoonLord", ModContent.ItemType<Content.Items.MoonLordMusicBox>() },
                //{ "Terraria CultistBoss", ModContent.ItemType<Content.Items.LunaticCultistMusicBox>() },
                //{ "Terraria HallowBoss", ModContent.ItemType<Content.Items.EmpressofLightMusicBox>() },
                { "Terraria DukeFishron", ModContent.ItemType<Content.Items.DukeFishronMusicBox>() },
                //{ "Terraria Golem", ModContent.ItemType<Content.Items.GolemMusicBox>() },
                //{ "Terraria Plantera", ModContent.ItemType<Content.Items.PlanteraMusicBox>() },
                //{ "Terraria SkeletronPrime", ModContent.ItemType<Content.Items.SkeletronPrimeMusicBox>() },
                //{ "Terraria TheTwins", ModContent.ItemType<Content.Items.TwinsMusicBox>() },
                //{ "Terraria TheDestroyer", ModContent.ItemType<Content.Items.DestroyerMusicBox>() },
                //{ "Terraria QueenSlimeBoss", ModContent.ItemType<Content.Items.QueenSlimeMusicBox>() },
                { "Terraria WallofFlesh", ModContent.ItemType<Content.Items.WallofFleshMusicBox>() },
                { "Terraria Skeletron", ModContent.ItemType<Content.Items.SkeletronMusicBox>() },
                //{ "Terraria Deerclops", ModContent.ItemType<Content.Items.DeerclopsMusicBox>() },
                //{ "Terraria QueenBee", ModContent.ItemType<Content.Items.QueenBeeMusicBox>() },
                { "Terraria BrainofCthulhu", ModContent.ItemType<Content.Items.BrainofCthulhuMusicBox>() },
                { "Terraria EaterofWorlds", ModContent.ItemType<Content.Items.EaterofWorldsMusicBox>() },
                { "Terraria EyeofCthulhu", ModContent.ItemType<Content.Items.EyeofCthulhuMusicBox>() },
                { "Terraria KingSlime", ModContent.ItemType<Content.Items.KingSlimeMusicBox>() }
            };

            var EventMusicBoxes = new Dictionary<string, object>
            {
                { "Terraria TorchGod", new List<int> { ModContent.ItemType<Content.Items.TorchGodMusicBox>(), ModContent.ItemType<Content.Items.TorchGodRevengeanceMusicBox>() } },
                //{ "Terraria LunarEvent", new List<int> { ModContent.ItemType<Content.Items.CelestialPillarVortexMusicBox>(), ModContent.ItemType<Content.Items.CelestialPillarNebulaMusicBox>(), ModContent.ItemType<Content.Items.CelestialPillarStardustMusicBox>(), ModContent.ItemType<Content.Items.CelestialPillarSolarMusicBox>() } },
                //{ "Terraria MartianMadness", ModContent.ItemType<Content.Items.MartianMadnessMusicBox>() },
                //{ "Terraria FrostMoon", ModContent.ItemType<Content.Items.FrostMoonMusicBox>() },
                { "Terraria PumpkinMoon", ModContent.ItemType<Content.Items.PumpkinMoonMusicBox>() },
                //{ "Terraria OldOnesArmy ", new List<int> { ModContent.ItemType<Content.Items.OldOnesArmyTier1MusicBox>(), ModContent.ItemType<Content.Items.OldOnesArmyTier2MusicBox>(), ModContent.ItemType<Content.Items.OldOnesArmyTier3MusicBox>() } },
                //{ "Terraria PirateInvasion", ModContent.ItemType<Content.Items.PirateInvasionMusicBox>() },
                //{ "Terraria GoblinArmy", ModContent.ItemType<Content.Items.GoblinArmyMusicBox>() },
                //{ "Terraria Eclipse", ModContent.ItemType<Content.Items.SolarEclipseMusicBox>() },
                { "Terraria BloodMoon", new List<int> { ModContent.ItemType<Content.Items.BloodMoonMusicBox>(), ModContent.ItemType<Content.Items.BloodMoonDeathMusicBox>() } },
            };

            var MinibossMusicBoxes = new Dictionary<string, object>
            {
                //{ "CalamityMod GreatSandShark", ModContent.ItemType<Content.Items.SandstormMusicBox>() },
            };


            checklist.Call("SubmitEntryCollectibles", Mod, BossMusicBoxes);
            checklist.Call("SubmitEntryCollectibles", Mod, EventMusicBoxes);
            checklist.Call("SubmitEntryCollectibles", Mod, MinibossMusicBoxes);
        }
    }
}