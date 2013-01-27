using System;
using Microsoft.Xna.Framework.Input;

namespace HeartFarm
{
	public class ButtonPressed : Event
	{
		public Keys keyPressed;
		public ButtonPressed() {}
		public ButtonPressed(Keys key) {
			keyPressed = key;
		}
	}
}

