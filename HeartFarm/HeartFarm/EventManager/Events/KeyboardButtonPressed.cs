using System;
using Microsoft.Xna.Framework.Input;

namespace HeartFarm
{
	public class KeyboardButtonPressed : Event
	{
		public Keys keyPressed;
		public KeyboardButtonPressed() {}
		public KeyboardButtonPressed(Keys key) {
			keyPressed = key;
		}
	}
}

