using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace HeartFarm
{
	public class Clock
	{
		BaseSprite Fill;
		BaseSprite Border;



		public Clock (ContentManager CM)
		{
			Fill = new BaseSprite(CM, "DayNightFill");
			Border = new BaseSprite(CM, "DayNightOutline");
		}
	}
}

