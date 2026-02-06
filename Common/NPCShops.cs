using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using UnCalamityModMusic.Content.Items;

namespace UnCalamityModMusic.Common
{
    public class NPCShops : GlobalNPC
    {
        public override void ModifyShop(NPCShop shop)
        {
            if (shop.NpcType == NPCID.Princess)
            {
                shop.Add(ModContent.ItemType<HardmodeInterludeMusicBox>(), Condition.Hardmode);
                shop.Add(ModContent.ItemType<FalseEpilogueMusicBox>(), Condition.DownedMoonLord);
            }
        }
    }
}
