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

