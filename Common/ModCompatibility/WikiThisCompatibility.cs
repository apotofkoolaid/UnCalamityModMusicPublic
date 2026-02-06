using Microsoft.Xna.Framework.Graphics;
using Terraria.ModLoader;

namespace UnCalamityModMusic.Common.ModCompatibility
{
    public class WikiThisCompatibility : ModSystem
    {
        public const string CalamityWikiURL = "https://calamitymod.wiki.gg/wiki/{}";

        public override void PostSetupContent()
        {
            WikiThisSetup();
        }

        public void WikiThisSetup()
        {
            bool wikiThis = ModLoader.TryGetMod("Wikithis", out Mod wikithis);

            if (!wikiThis)
            {
                return;
            }

            wikithis.Call("AddModURL", this, CalamityWikiURL);
            wikithis.Call("AddWikiTexture", this, ModContent.Request<Texture2D>("UnCalamityModMusic/WikiThisIcon"));
        }
    }
}