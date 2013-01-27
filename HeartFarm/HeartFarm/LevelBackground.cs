using System;

namespace HeartFarm
{
	public class LevelBackground : Screen
	{
		BaseSprite grassTile;

		public LevelBackground ()
		{
			grassTile = new BaseSprite(Game1.g_content, "GrassTile");
		}

		public override Screen update ()
		{
			return null;
		}

		public override void draw (Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch, Microsoft.Xna.Framework.GameTime gametime)
		{
			for (int x = 0; x < Game1.ScreenSize.X; x += grassTile.Width) {
				for(int y = 0; y < Game1.ScreenSize.Y; y += grassTile.Height)
				{
					grassTile.Position.X = x;
					grassTile.Position.Y = y;
					grassTile.Draw(gametime, spriteBatch);
				}
			}
		}
	}
}

