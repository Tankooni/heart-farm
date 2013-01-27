using System;

namespace HeartFarm
{
	public class Level:Screen
	{
		BaseSprite[,] tileArray;

		public Level ()
		{
			tileArray = new BaseSprite[5, 5];

			for (int i = 0; i < 5; i++)
			{
				for(int j = 0; j < 5; j++)
				{
					//tileArray[i][j] = new BaseSprite(
				}

			}
		}

		public override void draw (Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch, Microsoft.Xna.Framework.GameTime gametime)
		{
			throw new System.NotImplementedException ();
		}

		public override Screen update ()
		{
			throw new System.NotImplementedException ();
		}
	}
}

