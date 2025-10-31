using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UnCalamityModMusic.Common
{
    public class BossDetection : ModSystem
    {
        public static bool AreThereAnyBosses = false;

        public static bool IsABoss(NPC npc)
        {
            var calamityMod = ModLoader.TryGetMod("CalamityMod", out Mod calamity);

            if (npc is null || !npc.active)
            {
                return false;
            }

            // Add Slime God Paladins to the count
            if (calamityMod)
            {
                if (npc.type == calamity.Find<ModNPC>("EbonianPaladin").Type ||
                    npc.type == calamity.Find<ModNPC>("CrimulanPaladin").Type ||
                    npc.type == calamity.Find<ModNPC>("SplitEbonianPaladin").Type ||
                    npc.type == calamity.Find<ModNPC>("SplitCrimulanPaladin").Type)
                {
                    return true;
                }
            }

            // Any boss, minus Martian Saucer, plus Eater of Worlds
            return (npc.boss &&
                npc.type != NPCID.MartianSaucerCore) ||
                npc.type == NPCID.EaterofWorldsBody ||
                npc.type == NPCID.EaterofWorldsHead ||
                npc.type == NPCID.EaterofWorldsTail;
        }

        public static bool AnyBossNPCS()
        {
            foreach (NPC npc in Main.ActiveNPCs)
            {
                if (IsABoss(npc))
                {
                    return true;
                }
            }
            return false;
        }

        public override void PreUpdateEntities()
        {
            AreThereAnyBosses = AnyBossNPCS();
        }
    }
}
