using System;
using Microsoft.Xna.Framework.Input;

namespace HeartFarm
{
	public enum MouseButtons
	{
		Left,
		Right,
		Middle
	}

	public class MouseButtonPressed : Event
	{
		public MouseButtons button;
		public MouseButtonPressed () {}
		public MouseButtonPressed (MouseButtons btn)
		{
			button = btn;
		}
	}
}

