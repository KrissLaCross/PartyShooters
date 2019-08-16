using Microsoft.Xna.Framework.Input.Touch;

namespace RPGController
{
    internal static class TouchHandler
    {
        private static TouchCollection _touchCollection;

        public static void Update() => _touchCollection = TouchPanel.GetState();

        public static TouchCollection GetState() => _touchCollection;
    }
}