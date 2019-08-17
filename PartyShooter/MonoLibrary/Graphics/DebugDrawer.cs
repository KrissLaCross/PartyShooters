using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Library.Graphics
{
    public static class DebugDrawer
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

        public static void DrawRect(float left, float top, float right, float bottom, Color color)
        {
            _spriteBatch.Draw(_pixel, new Rectangle((int)left, (int)top, (int)(right - left), (int)(bottom - top)), color);
        }

        internal static void DrawRect(Vector2 position, Vector2 size, Color color)
        {
            var ( x,  y) = position;
            var (sx, sy) = size;
            _spriteBatch.Draw(_pixel, new Rectangle((int) x, (int) y, 
                                                    (int)sx, (int)sy), color);
        }

        public static void DrawString(string text, Vector2 position, Color color, Vector2 size, bool centered = false, float rotation = 0f)
        {
            var origin = centered ? (_spriteFont.MeasureString(text)) / 2 : Vector2.Zero;
            _spriteBatch.DrawString(_spriteFont, text, position, color, rotation, origin, size, SpriteEffects.None, 0);
        }
    }
}