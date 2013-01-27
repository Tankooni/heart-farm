using System;
using System.Collections.Generic;

namespace HeartFarm
{
	public class Level:Screen
	{
		BaseSprite[,] tileArray;
		public List<HeartBeet> beetList = new List<HeartBeet>();

		public Level ()
		{
			tileArray = new BaseSprite[5, 5];

			for (int i = 0; i < 5; i++)
			{
				for(int j = 0; j < 5; j++)
				{
					tileArray[i, j] = new BaseSprite(Game1.g_content, "DirtTile", new Vector(j * 64f, i * 64f), new Vector(1.0f, 1.0f, 1.0f));
				}

			}
			//Add one beet to the list for testing purposes.
			beetList.Add(new HeartBeet(new Vector(30f, 30f), new Vector(0.7f, 0.7f, 0.7f)));
		}

		public override void draw (Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch, Microsoft.Xna.Framework.GameTime gametime)
		{
			//throw new System.NotImplementedException ();

			for (int i = 0; i < 5; i++) {
				for (int j = 0; j < 5; j++) {
					tileArray [i, j].Draw (gametime, spriteBatch);
				}
				
			}

			for (int k = 0; k < beetList.Count; k++)
			{
				beetList[k].draw(spriteBatch, gametime);
			}

		}

		public override Screen update ()
		{
			return null;
		}
	}
}

