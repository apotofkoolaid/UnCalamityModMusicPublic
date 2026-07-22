using System;
using System.Collections.Generic;
using System.Linq;
using Terraria.ID;
using Terraria.ModLoader;

namespace UnCalamityModMusic.Common
{
	public class TileCounts : ModSystem
	{
        internal static int GraniteTileCount;
        internal static int MarbleTileCount;
        
        internal static int WorkBenchTileCount;
		internal static int FurnaceTileCount;
		internal static int AnvilTileCount;
		internal static int HellforgeTileCount;
		internal static int HardmodeAnvilTileCount;
		internal static int HardmodeForgeTileCount;
        internal static int AncientManipulatorTileCount;
        internal static int CosmicAnvilTileCount;
        internal static int DraedonsForgeTileCount;

		internal static int LabTileCount;

		internal static int StorageHeartTileCount;
		internal static int CraftingUnitTileCount;

        internal static List<int> ModdedWorkBenches;

        public override void PostSetupContent()
        {
            ModdedWorkBenches = ModdedWorkBenchIDs();
        }

        public override void TileCountsAvailable(ReadOnlySpan<int> tileCounts)
		{
			var calamityMod = ModLoader.TryGetMod("CalamityMod", out Mod calamitymod);

            GraniteTileCount = tileCounts[TileID.Granite];
            MarbleTileCount = tileCounts[TileID.Marble];

            WorkBenchTileCount = tileCounts[TileID.WorkBenches] + 
				ModdedWorkBenchTileCount(tileCounts, ModdedWorkBenches);
            FurnaceTileCount = tileCounts[MusicFlags.Furnace];
			AnvilTileCount = tileCounts[MusicFlags.Anvil];
			HellforgeTileCount = tileCounts[MusicFlags.Hellforge];
			HardmodeAnvilTileCount = tileCounts[MusicFlags.HardmodeAnvil];
			HardmodeForgeTileCount = tileCounts[MusicFlags.HardmodeForge];
            AncientManipulatorTileCount = tileCounts[MusicFlags.AncientManipulator];
            CosmicAnvilTileCount = tileCounts[MusicFlags.CosmicAnvil];
            DraedonsForgeTileCount = tileCounts[MusicFlags.DraedonsForge];
            StorageHeartTileCount = tileCounts[MusicFlags.StorageHeart];
            CraftingUnitTileCount = tileCounts[MusicFlags.CraftingUnit];

            if (calamityMod)
            {
				LabTileCount = tileCounts[calamitymod.Find<ModTile>("LaboratoryPanels").Type] +
					tileCounts[calamitymod.Find<ModTile>("LaboratoryPlating").Type] +
					tileCounts[calamitymod.Find<ModTile>("HazardChevronPanels").Type];
			}
        }

        public static int ModdedWorkBenchTileCount(ReadOnlySpan<int> tileCounts, IEnumerable<int> IDs)
        {
            int workBenchCount = 0;

            if (IDs == null)
                return 0;

            foreach (var id in IDs)
                if (id >= 0 && id < tileCounts.Length)
                    workBenchCount += tileCounts[id];

            return workBenchCount;
        }

        public static List<int> ModdedWorkBenchIDs()
        {
            List<int> workBenchIDs = [];

            for (int id = 0; id < TileLoader.TileCount; id++)
            {
                ModTile modTile = TileLoader.GetTile(id);

                if (modTile != null && modTile.AdjTiles != null && modTile.AdjTiles.Contains(TileID.WorkBenches))
                    workBenchIDs.Add(id);
            }

            return workBenchIDs;
        }
    }
}