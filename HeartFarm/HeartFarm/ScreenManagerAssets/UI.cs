using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace HeartFarm
{
	public class UI : Screen, Listener
	{
		BloodGauge boodles;
		
		public UI(ContentManager Content)
		{
			boodles = new BloodGauge(Content);
			boodles.Position = new Vector(Game1.ScreenSize.X*0.995f - boodles.Width , Game1.ScreenSize.Y*0.495f - boodles.Height/2);
			EventManager.g_EM.AddListener(new MouseButtonPressed(), this);
		}

		public void OnEvent (Event e)
		{
			Console.WriteLine("Blinks, then dies");
		}

		public override Screen update()
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

