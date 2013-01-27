using System;
using Microsoft.Xna.Framework.Input;

namespace HeartFarm
{
	public class ButtonReleased : Event
	{
		public Keys keyReleased;
		public ButtonReleased () {}
		public ButtonReleased(Keys key){
			keyReleased = key;
		}
	}
}

