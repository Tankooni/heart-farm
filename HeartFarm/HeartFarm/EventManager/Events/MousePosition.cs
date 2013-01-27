using System;
using Microsoft.Xna.Framework.Input;

namespace HeartFarm
{
	public class MousePosition : Event
	{
		public Mouse.POINT pos;
		public MousePosition (){}
		public MousePosition (Mouse.POINT p)
		{
			pos = p;
		}
	}
}

