using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Drawing;
using Terraria.GameContent.ObjectInteractions;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria.Utilities;

namespace UnCalamityModMusic.Common
{
    public abstract class MusicBoxItem : ModItem
    {
        public abstract int MusicBoxTile { get; }

        public virtual int? MusicBoxTileAlt { get; } = null;

        public abstract string MusicFilePath { get; }

        public virtual void MusicBoxRecipe() { return; }

        public override void SetStaticDefaults()
        {
            ItemID.Sets.CanGetPrefixes[Type] = false;
            ItemID.Sets.ShimmerTransformToItem[Type] = ItemID.MusicBox;

            if (!String.IsNullOrEmpty(MusicFilePath) && MusicPathing.GetMusicSlot(MusicFilePath) > 0)
            {
                if (MusicBoxTileAlt == null)
                {
                    MusicLoader.AddMusicBox(Mod, MusicPathing.GetMusicSlot(MusicFilePath), Type, MusicBoxTile);
                }
                else
                {
                    MusicLoader.AddMusicBox(Mod, MusicPathing.GetMusicSlot(MusicFilePath), Type, MusicBoxTileAlt.Value);
                }
            }
        }

        public override void SetDefaults()
        {
            Item.DefaultToMusicBox(MusicBoxTile);
        }

        public override void AddRecipes()
        {
            MusicBoxRecipe();
        }
    }

    public abstract class MusicBoxTile : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileObsidianKill[Type] = true;
            TileID.Sets.HasOutlines[Type] = true;
            TileID.Sets.DisableSmartCursor[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
            TileObjectData.newTile.Origin = new Point16(0, 1);
            TileObjectData.newTile.LavaDeath = false;
            TileObjectData.newTile.DrawYOffset = 2;
            TileObjectData.newTile.StyleLineSkip = 2;
            TileObjectData.addTile(Type);

            AddMapEntry(new Color(191, 142, 111), Language.GetText("ItemName.MusicBox"));
        }

        public override void MouseOver(int i, int j)
        {
            Player player = Main.LocalPlayer;
            player.noThrow = 2;
            player.cursorItemIconEnabled = true;
            player.cursorItemIconID = TileLoader.GetItemDropFromTypeAndStyle(Type);
        }

        public override bool HasSmartInteract(int i, int j, SmartInteractScanSettings settings) => true;

        public override bool CreateDust(int i, int j, ref int type) => false;

        public override void DrawEffects(int i, int j, SpriteBatch spriteBatch, ref TileDrawInfo drawData)
        {
            Tile tile = Main.tile[i, j];

            if (Lighting.UpdateEveryFrame && new FastRandom(Main.TileFrameSeed).WithModifier(i, j).Next(4) != 0)
            {
                return;
            }

            if (TileDrawing.IsVisible(tile) && tile.TileFrameX == 36 && tile.TileFrameY % 36 == 0 && (int)Main.timeForVisualEffects % 7 == 0 && Main.rand.NextBool(3))
            {
                int goreType = Main.rand.Next(570, 573);
                Vector2 position = new Vector2(i * 16 + 8, j * 16 - 8);
                Vector2 velocity = new Vector2(Main.WindForVisuals * 2f, -0.5f);
                velocity.X *= Main.rand.NextFloat(0.5f, 1.5f);
                velocity.Y *= Main.rand.NextFloat(0.5f, 1.5f);

                if (goreType == 572)
                {
                    position.X -= 8f;
                }
                else if (goreType == 571)
                {
                    position.X -= 4f;
                }

                Gore.NewGore(new EntitySource_TileUpdate(i, j), position, velocity, goreType, 0.8f);
            }
        }
    }
}
