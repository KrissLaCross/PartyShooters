using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input.Touch;

namespace RPGController
{
    internal class VirtualJoyStick
    {
        private readonly Vector2 _position;
        private readonly float _radius;
        private int _touchId = -1;
        private bool _directionChanged;
        private Vector2 _direction;

        public VirtualJoyStick(Vector2 position, float radius) => (_position, _radius) = (position, radius);

        public void CheckForTouch()
        {
            if (_touchId > -1) return;
            
            var touchCollection = TouchHandler.GetState();
            foreach (var touch in touchCollection)
            {
                if (touch.State != TouchLocationState.Pressed) continue;

                var delta = touch.Position - _position;
                var length = delta.Length();

                if (length <= _radius)
                    _touchId = touch.Id;
            }
        }

        public bool GetDirIfChanged(out Vector2 aVector2)
        {
            aVector2 = Vector2.Zero;

            if (!_directionChanged) return false;

            aVector2 = _direction;
            return true;

        }

        public void UpdateDirection()
        {
            _directionChanged = false;
            _direction = Vector2.Zero;

            if (!TouchHandler.GetState().FindById(_touchId, out var touch) || _touchId < 0) return;

            switch (touch.State)
            {
                case TouchLocationState.Moved:
                case TouchLocationState.Pressed:
                    _direction = CalcDirection(touch);
                    break;
                case TouchLocationState.Invalid:
                case TouchLocationState.Released:
                    _direction = Vector2.Zero;
                    _touchId = -1;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            _directionChanged = true;
        }

        private Vector2 CalcDirection(TouchLocation touchLocation)
        {
            var delta = touchLocation.Position - _position;
            var length = Math.Min(delta.Length(), _radius);
            delta.Normalize();
            return delta * (length / _radius);
        }

        public void Draw()
        {
            DebugDrawer.DrawCircle(_position, _radius, new Color(0f, 0f, 0f, 0.1f));
            DebugDrawer.DrawCircle(_position + _direction * _radius, _radius * 0.2f, new Color(0, 0, 0, 1f));
        }
    }
}