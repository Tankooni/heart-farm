using System;
using Microsoft.Xna.Framework.Input;

namespace HeartFarm
{
	public class KeyboardButtonReleased : Event
	{
		public Keys keyReleased;
		public KeyboardButtonReleased () {}
		public KeyboardButtonReleased(Keys key){
			keyReleased = key;
		}
	}
}

