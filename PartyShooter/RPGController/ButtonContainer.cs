using System;
using System.Collections.Generic;

namespace RPGController
{
    public class ButtonContainer
    {
        private readonly List<Button> _buttons = new List<Button>();

        public void Add(int minX, int minY, int maxX, int maxY, string text, Action action)
        {
            _buttons.Add(new Button(minX, minY, maxX, maxY, text, action));
        }

        public void Update() => _buttons.ForEach(o => o.Update());

        public void Draw() => _buttons.ForEach(o => o.Draw());
    }
}