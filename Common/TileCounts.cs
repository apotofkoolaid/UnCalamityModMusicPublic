using System;
using Terraria.ID;
using Terraria.ModLoader;
using UnCalamityModMusic.Content.Tiles;

namespace UnCalamityModMusic.Common
{
	public class TileCounts : ModSystem
	{
		internal static int WorkbenchTileCount;
		internal static int FurnaceTileCount;
		internal static int AnvilTileCount;
		internal static int HellforgeTileCount;
		internal static int HardmodeAnvilTileCount;
		internal static int HardmodeForgeTileCount;
        internal static int GraniteTileCount;
        internal static int MarbleTileCount;

        internal static int CosmicAnvilTileCount;
		internal static int DraedonsForgeTileCount;
		internal static int LabTileCount;

		internal static int StorageHeartTileCount;
		internal static int CraftingUnitTileCount;

        public override void TileCountsAvailable(ReadOnlySpan<int> tileCounts)
		{
			var calamityMod = ModLoader.TryGetMod("CalamityMod", out Mod calamitymod);
			var magicStorage = ModLoader.TryGetMod("MagicStorage", out Mod magicstorage);

			WorkbenchTileCount = tileCounts[TileID.WorkBenches];
			FurnaceTileCount = tileCounts[TileID.Furnaces];
			AnvilTileCount = tileCounts[TileID.Anvils];
			HellforgeTileCount = tileCounts[TileID.Hellforge];
			HardmodeAnvilTileCount = tileCounts[TileID.MythrilAnvil];
			HardmodeForgeTileCount = tileCounts[TileID.AdamantiteForge];
			GraniteTileCount = tileCounts[TileID.Granite];
            MarbleTileCount = tileCounts[TileID.Marble];

            if (calamityMod)
            {
				CosmicAnvilTileCount = tileCounts[calamitymod.Find<ModTile>("CosmicAnvil").Type];
				DraedonsForgeTileCount = tileCounts[calamitymod.Find<ModTile>("DraedonsForge").Type];
				LabTileCount = tileCounts[calamitymod.Find<ModTile>("LaboratoryPanels").Type] +
					tileCounts[calamitymod.Find<ModTile>("LaboratoryPlating").Type] +
					tileCounts[calamitymod.Find<ModTile>("HazardChevronPanels").Type];
			}

			if (magicStorage)
			{
				StorageHeartTileCount = tileCounts[magicstorage.Find<ModTile>("StorageHeart").Type];
				CraftingUnitTileCount = tileCounts[magicstorage.Find<ModTile>("CraftingAccess").Type];
			}
        }
	}
}