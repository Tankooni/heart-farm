using System;
using Microsoft.Xna.Framework.Input;

namespace HeartFarm
{
	public class MouseButtonReleased : Event
	{
		public MouseButtons button;
		public MouseButtonReleased () {}
		public MouseButtonReleased (MouseButtons btn)
		{
			button = btn;
		}
	}
}

