using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using System;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using UnCalamityModMusic.Common;
using UnCalamityModMusic.Common.Configs;

namespace UnCalamityModMusic.Content.Items.External
{
    public class MusicBox : GlobalItem
    {
        public override void SetDefaults(Item item)
        {
            // Make the empty music box placeable when its resprite is enabled.
            if (item.type == ItemID.MusicBox)
            {
                if (ModContent.GetInstance<OtherConfig>().MusicBoxResprite)
                {
                    item.useStyle = ItemUseStyleID.Swing;
                    item.useTurn = true;
                    item.useAnimation = 15;
                    item.useTime = 10;
                    item.autoReuse = true;
                    item.consumable = true;
                    item.createTile = ModContent.TileType<Tiles.External.MusicBox>();
                }
            }
        }
    }
    public class MusicBoxRecipe : ModSystem
    {
        public static RecipeGroup CopperBarGroup;

        public override void Unload()
        {
            CopperBarGroup = null;
        }

        public override void AddRecipeGroups()
        {
            CopperBarGroup = new RecipeGroup
            (
                () => $"{Language.GetTextValue("LegacyMisc.37")} {Lang.GetItemNameValue(ItemID.CopperBar)}",
                ItemID.CopperBar, ItemID.TinBar
            );
            RecipeGroup.RegisterGroup("VCMM:CopperBarGroup", CopperBarGroup);
        }

        public override void AddRecipes()
        {
            var calamityMod = ModLoader.TryGetMod("CalamityMod", out Mod calamity);

            // When Calamity 2.1+ is not enabled; this recipe gets deprecated by the Merchant now selling music boxes.
            if (calamityMod && calamity.Version < new Version(2, 1))
            {
                Recipe.Create(ItemID.MusicBox, 1)
                    .AddRecipeGroup(RecipeGroupID.Wood, 6)
                    .AddRecipeGroup("VCMM:CopperBarGroup", 5)
                    .AddRecipeGroup(RecipeGroupID.IronBar, 2)
                    .AddIngredient(ItemID.LifeCrystal, 1)
                    .AddTile(TileID.Anvils)
                    .Register();
            }
        }
    }
    public class MusicBoxResprite : ModSystem
    {
        public override void Load()
        {
            if (ModContent.GetInstance<OtherConfig>().MusicBoxResprite)
            {
                TextureAssets.Item[ItemID.MusicBox] = ModContent.Request<Texture2D>("UnCalamityModMusic/Content/Items/External/MusicBox", AssetRequestMode.AsyncLoad);
            }
        }

        public override void Unload()
        {
            TextureAssets.Item[ItemID.MusicBox] = ModContent.Request<Texture2D>("Terraria/Images/Item_" + ItemID.MusicBox, AssetRequestMode.AsyncLoad);
        }
    }
}

