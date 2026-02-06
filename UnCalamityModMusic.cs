using Terraria.ModLoader;
using UnCalamityModMusic.Common;

namespace UnCalamityModMusic
{
	public class UnCalamityModMusic : Mod
	{
		internal static UnCalamityModMusic Instance;

        public UnCalamityModMusic() => Instance = this;

        public override void Load()
        {
            MusicPathing.InitalizeMusicPaths(Instance);
        }

        public override void Unload()
		{
			Instance = null;
		}
	}
}