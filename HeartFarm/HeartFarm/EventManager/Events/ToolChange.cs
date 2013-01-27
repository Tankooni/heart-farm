using System;
using Microsoft.Xna.Framework;

namespace HeartFarm
{
	public class ToolChange : Event
	{
		public String tool;
		public ToolChange (){}
		public ToolChange(String t)
		{
			tool = t;
		}
	}
}

