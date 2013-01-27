using System;
using System.Collections.Generic;

namespace HeartFarm
{
	public class Level:Screen
	{
		FarmPlot[,] plots;

		public Level ()
		{
			plots = new FarmPlot[5, 5];

			for (int i = 0; i < 5; i++)
			{
				for(int j = 0; j < 5; j++)
				{
					plots[i, j] = new FarmPlot(new Vector(j * 64f + 250, i * 64f + 160));
				}
			}
		}

		public override void draw (Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch, Microsoft.Xna.Framework.GameTime gametime)
		{
			//throw new System.NotImplementedException ();

			for (int i = 0; i < 5; i++) {
				for (int j = 0; j < 5; j++) {
					plots [i, j].Draw(spriteBatch, gametime);
				}	
			}
		}

		public override Screen update ()
		{
			foreach(FarmPlot p in plots)
				p.Update();
			return null;
		}
	}
}

