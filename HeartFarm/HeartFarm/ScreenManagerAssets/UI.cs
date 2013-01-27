using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace HeartFarm
{
	public class UI : Screen, Listener
	{
		BloodGauge boodles;
		Clock cüdles;
		ToolBar toodles;
		BaseSprite Cursor;
		
		public UI(ContentManager Content)
		{
			boodles = new BloodGauge(Content);
			boodles.Position = new Vector(Game1.ScreenSize.X*0.995f - boodles.Width , Game1.ScreenSize.Y*0.495f - boodles.Height/2);

			cüdles = new Clock(Content);
			cüdles.Position = new Vector(Game1.ScreenSize.X*0.5f, 0);

			toodles = new ToolBar(Content);

			Cursor = new BaseSprite(Content, "Syringe");
			Cursor.Origin.Y = Cursor.Height;
			EventManager.g_EM.AddListener(new MousePosition(), this);
		}

		public override Screen update()
		{
			boodles.Update();
			cüdles.Update();
			toodles.Update();
			return null;
		}
		
		public override void draw(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch, Microsoft.Xna.Framework.GameTime gameTime)
		{
			boodles.Draw(spriteBatch, gameTime);
			cüdles.Draw(spriteBatch, gameTime);
			toodles.Draw(spriteBatch, gameTime);
			Cursor.Draw(gameTime, spriteBatch);
		}

		public void OnEvent (Event e)
		{
			if (e is MousePosition) {
				MousePosition mp = (MousePosition)e;
				Cursor.Position.X = mp.pos.X;
				Cursor.Position.Y = mp.pos.Y;
				e.isDoneProcessing = true;
			}
		}
	}
}

