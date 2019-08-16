using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace RPGController
{
    internal static class DebugDrawer
    {
        private static SpriteBatch _spriteBatch;
        private static Texture2D _circle;

        public static void Init(SpriteBatch aSpriteBatch, ContentManager content)
        {
            _spriteBatch = aSpriteBatch;
            _circle = content.Load<Texture2D>("Circle");
        }

        public static void DrawCircle(Vector2 aPosition, float aRadius, Color aColor)
        {
            _spriteBatch.Draw(_circle, aPosition, null, aColor, 0, new Vector2(1024, 1024), new Vector2(aRadius / 1024), SpriteEffects.None, 0);
        }
    }
}