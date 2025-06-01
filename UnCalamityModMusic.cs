using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;
using UnCalamityModMusic.Common;
using UnCalamityModMusic.Common.Configs;

namespace UnCalamityModMusic
{
	public class UnCalamityModMusic : Mod
	{
		public static UnCalamityModMusic Instance;

        public const string CalamityWikiURL = "https://calamitymod.wiki.gg/wiki/{}";

        internal static bool calamityMod;
		internal static bool calamityModMusic;
		internal static bool catalystMod;
		internal static bool calamityVanities;
		internal static bool otherCalamityMusic;
		internal static bool infernumMod;
		internal static bool infernumModMusic;
		internal static bool magicStorage;
		internal static bool wikiThis;

        public UnCalamityModMusic() => Instance = this;

        public override void Load()
		{
			MusicPathing.InitalizeMusicPaths(Instance);
			WorkshopDetection.InitializeDetectionRadius();

			calamityMod = ModLoader.TryGetMod("CalamityMod", out Mod calamity);
			calamityModMusic = ModLoader.TryGetMod("CalamityModMusic", out Mod cmusic);
			catalystMod = ModLoader.TryGetMod("CatalystMod", out Mod catalyst);
			calamityVanities = ModLoader.TryGetMod("CalValEX", out Mod calval);
			otherCalamityMusic = ModLoader.TryGetMod("OtherCalamityMusic", out Mod othermusic);
			infernumMod = ModLoader.TryGetMod("InfernumMode", out Mod infernum);
			infernumModMusic = ModLoader.TryGetMod("InfernumModeMusic", out Mod imusic);
			magicStorage = ModLoader.TryGetMod("MagicStorage", out Mod mstorage);
			wikiThis = ModLoader.TryGetMod("Wikithis", out Mod wiki);

			if (ModContent.GetInstance<OtherConfig>().MusicBoxResprite)
			{
				TextureAssets.Item[ItemID.MusicBox] = ModContent.Request<Texture2D>("UnCalamityModMusic/Content/Items/External/MusicBox", AssetRequestMode.AsyncLoad);
			}
		}

		public override void Unload()
		{
			Instance = null;

			TextureAssets.Item[ItemID.MusicBox] = ModContent.Request<Texture2D>("Terraria/Images/Item_" + ItemID.MusicBox, AssetRequestMode.AsyncLoad); ;
		}

		public override void PostSetupContent()
		{
			wikiThis = ModLoader.TryGetMod("Wikithis", out Mod wiki);

			if (wikiThis)
			{
				wiki.Call("AddModURL", this, CalamityWikiURL);
                wiki.Call("AddWikiTexture", this, ModContent.Request<Texture2D>("UnCalamityModMusic/WikiThisIcon"));
            }
		}
	}
}