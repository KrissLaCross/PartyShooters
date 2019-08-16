using System;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input.Touch;

namespace RPGController
{
    public class Button
    {
        private Rectangle _bounds;
        private readonly string _text;
        private readonly Action _action;
        private bool _isDown;

        public Button(int minX, int minY, int maxX, int maxY, string text, Action action)
        {
            _text = text;
            _action = action;
            _bounds = new Rectangle(minX, minY, maxX - minX, maxY - minY);
        }

        public void Draw()
        {
            DebugDrawer.DrawRect(_bounds, _isDown ? Color.Gray : Color.White);
            var copy = _bounds;
            copy.Inflate(-10, -10);
            DebugDrawer.DrawRect(copy, _isDown ? Color.White : Color.Gray);
            DebugDrawer.DrawText(_text, _bounds.Center.ToVector2(), Color.White);
        }

        public void Update()
        {
            _isDown = false;

            var touches = TouchHandler.GetState();
            foreach (var touch in touches.Where(touch => _bounds.Contains(touch.Position)))
            {
                _isDown = true;
                if (touch.State == TouchLocationState.Released) _action();
            }
        }
    }
}