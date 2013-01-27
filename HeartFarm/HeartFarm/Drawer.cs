using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace HeartFarm
{
	static class Drawer
	{
		static Texture2D white;

		public static void Init(GraphicsDevice GD)
		{
			white = new Texture2D(GD, 1, 1, false, SurfaceFormat.Color);
			white.SetData(new[] { Color.White });
		}

		public static void drawRect(SpriteBatch SB, Vector pos, Vector size, Color color)
		{
			SB.Draw(white, pos.toVector2(), new Rectangle(0, 0, (int)size.X, (int)size.Y), color);
		}
	}
}

