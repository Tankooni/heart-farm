using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace HeartFarm
{
	static class Drawer
	{
		static Texture2D white;
		static Texture2D night;

		public static void Init(GraphicsDevice GD)
		{
			white = new Texture2D(GD, 1, 1, false, SurfaceFormat.Color);
			white.SetData(new[] { Color.White });

			night = new Texture2D(GD, 1, 1, false, SurfaceFormat.Color);
			night.SetData(new[] { Color.FromNonPremultiplied(33, 0 , 199, 0) });
		}

		public static void drawRect(SpriteBatch SB, Vector pos, Vector size, Color color)
		{
			SB.Draw(white, pos.toVector2(), new Rectangle(0, 0, (int)size.X, (int)size.Y), color);
		}

		public static void drawNight(SpriteBatch SB)
		{
			SB.Draw(night, Vector2.Zero, new Rectangle(0, 0, (int)Game1.ScreenSize.X, (int)Game1.ScreenSize.Y), Color.White);
		}

		public static void setNightAlpha(int alpha)
		{
			night.SetData (new[] { Color.FromNonPremultiplied (33, 0, 199, alpha) });
		}
	}
}

