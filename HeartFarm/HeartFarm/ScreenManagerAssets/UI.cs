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
		Level level;
		
		SpriteFont font;
		SpriteFont bigFont;
		string toolTip;
		int timeToDisplayNextDayScreenThing = 0;
		
		public float ClockRotation {
			get{return cüdles.Rotation;}
		}

		public UI(ContentManager Content, Level lo)
		{
			level = lo;

			boodles = new BloodGauge(Content);
			boodles.Position = new Vector(Game1.ScreenSize.X*0.995f - boodles.Width , Game1.ScreenSize.Y*0.495f - boodles.Height/2);

			cüdles = new Clock(Content);
			cüdles.Position = new Vector(Game1.ScreenSize.X*0.5f, 0);

			toodles = new ToolBar(Content);

			Cursor = new BaseSprite(Content, "Syringe");
			Cursor.Origin.Y = Cursor.Height;

			//add the listeners
			EventManager.g_EM.AddListener(new MousePosition(), this);
			EventManager.g_EM.AddListener(new DrawToolTip(), this);
			EventManager.g_EM.AddListener(new DayChanged(), this);

			//init sprite font
			font = Content.Load<SpriteFont>("defaultFont");
			bigFont = Content.Load<SpriteFont>("MainMenuFont");
		}

		public override Screen update()
		{
			boodles.Update(Level.BloodLevel/level.BloodTarget);
			cüdles.Update();
			toodles.Update();

			if(timeToDisplayNextDayScreenThing > 0)
				timeToDisplayNextDayScreenThing--;

			return null;
		}
		
		public override void draw (Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch, Microsoft.Xna.Framework.GameTime gameTime)
		{
			boodles.Draw (spriteBatch, gameTime);
			cüdles.Draw (spriteBatch, gameTime);
			toodles.Draw(spriteBatch, gameTime);
			Cursor.Draw (gameTime, spriteBatch);

			//draw number of vials on a rectangle
			Drawer.drawRect(spriteBatch, new Vector(0,0,0), new Vector(160, 40, 0), new Color(0, 0, 0, 50));
			spriteBatch.DrawString(font, "Vials: " + level.vials.ToString() +
			                       "\nRequired Vials: " + level.requiredVials.ToString()
			                       , new Vector2(0,0), Color.MediumVioletRed);

			if (toolTip != null) {
				Drawer.drawRect(spriteBatch, Cursor.Position, new Vector(100, 40, 0), new Color(0, 0, 0, 50));
				spriteBatch.DrawString(font, toolTip, new Vector2(Cursor.Position.X + 15, Cursor.Position.Y - 5), Color.MediumVioletRed);

				toolTip = null;
			}

			//next day thing
			if(timeToDisplayNextDayScreenThing > 0)
			{
				spriteBatch.DrawString(bigFont, "CONGRADULATIONS!\n    You made it to day\n                   " + level.day,
				                       new Vector2(100, 200), Color.LightGoldenrodYellow);
			}
		}

		public void OnEvent (Event e)
		{
			if (e is MousePosition) {
				MousePosition mp = (MousePosition)e;
				Cursor.Position.X = mp.pos.X;
				Cursor.Position.Y = mp.pos.Y;
				e.isDoneProcessing = true;
			} else if (e is DrawToolTip) {
				DrawToolTip dtt = (DrawToolTip)e;

				toolTip = dtt.s;
			} else if (e is DayChanged) {
				//Display MAGIX!!
				timeToDisplayNextDayScreenThing = 120;
			}
		}
	}
}

