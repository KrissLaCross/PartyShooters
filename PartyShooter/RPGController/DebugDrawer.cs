using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace RPGController
{
    internal static class DebugDrawer
    {
        private static SpriteBatch _spriteBatch;
        private static Texture2D _circle;
        private static Texture2D _pixel;
        private static SpriteFont _spriteFont;

        public static void Init(SpriteBatch aSpriteBatch, ContentManager content, GraphicsDevice graphicsDevice)
        {
            _spriteBatch = aSpriteBatch;
            _circle = content.Load<Texture2D>("Circle");
            _pixel = new Texture2D(graphicsDevice, 1, 1);
            _pixel.SetData(new[] { Color.White });

            _spriteFont = content.Load<SpriteFont>("SpriteFont");
        }

        public static void DrawCircle(Vector2 aPosition, float aRadius, Color aColor)
        {
            _spriteBatch.Draw(_circle, aPosition, null, aColor, 0, new Vector2(1024, 1024), new Vector2(aRadius / 1024), SpriteEffects.None, 0);
        }

        public static void DrawRect(Rectangle bounds, Color color)
        {
            _spriteBatch.Draw(_pixel, bounds, color);
        }

        public static void DrawText(string text, Vector2 center, Color color)
        { ;
            _spriteBatch.DrawString(_spriteFont, text, center, color, 0, _spriteFont.MeasureString(text) / 2, Vector2.One * 16, SpriteEffects.None, 0);
        }
    }
}