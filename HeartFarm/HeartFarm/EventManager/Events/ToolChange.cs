using System;
using Microsoft.Xna.Framework;

namespace HeartFarm
{
	public class ToolChange : Event
	{
		public Level.Tools tool;
		public ToolChange (){}
		public ToolChange(Level.Tools t)
		{
			tool = t;
		}
	}
}

