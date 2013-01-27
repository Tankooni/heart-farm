using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace HeartFarm
{
	public class UI : Screen
	{
		BloodGauge boodles;

		public UI(ContentManager Content)
		{
			boodles = new BloodGauge(Content);
			boodles.Position = new Vector(Game1.ScreenSize.X*0.995f - boodles.Width , Game1.ScreenSize.Y*0.495f - boodles.Height/2);
		}

		public override Screen update(InputManager IM)
		{
			boodles.Update();
			return null;
		}

		public override void draw(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch, Microsoft.Xna.Framework.GameTime gameTime)
		{
			boodles.Draw(spriteBatch, gameTime);
		}
	}
}

