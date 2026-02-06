using Microsoft.Xna.Framework.Graphics;
using Terraria.ModLoader;

namespace UnCalamityModMusic.Content.Menus
{
    internal class NullSurfaceBackground : ModSurfaceBackgroundStyle
    {
        public override void ModifyFarFades(float[] fades, float transitionSpeed)
        {
            for (int i = 0; i < fades.Length; i++)
            {
                if (i == Slot)
                {
                    fades[i] += transitionSpeed;
                    if (fades[i] > 1f)
                    {
                        fades[i] = 1f;
                    }
                }
                else
                {
                    fades[i] -= transitionSpeed;
                    if (fades[i] < 0f)
                    {
                        fades[i] = 0f;
                    }
                }
            }
        }

        public override int ChooseCloseTexture(ref float scale, ref double parallax, ref float a, ref float b) => -1;
        public override int ChooseFarTexture() => -1;
        public override int ChooseMiddleTexture() => -1;
        public override bool PreDrawCloseBackground(SpriteBatch spriteBatch) => false;
    }
}
