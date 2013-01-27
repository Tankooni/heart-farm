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
		string toolTip;
		
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

			//add listeners
			EventManager.g_EM.AddListener(new MousePosition(), this);
			EventManager.g_EM.AddListener(new DrawToolTip(), this);
			EventManager.g_EM.AddListener(new ToolChange(), this);

			//init sprite font
			font = Content.Load<SpriteFont>("defaultFont");
		}

		public override Screen update()
		{
			boodles.Update(Level.BloodLevel/level.BloodTarget);
			cüdles.Update();
			toodles.Update();
			return null;
		}
		
		public override void draw (Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch, Microsoft.Xna.Framework.GameTime gameTime)
		{
			boodles.Draw (spriteBatch, gameTime);
			cüdles.Draw (spriteBatch, gameTime);
			toodles.Draw(spriteBatch, gameTime);
			Cursor.Draw (gameTime, spriteBatch);

			if (toolTip != null) {
				//spriteBatch.GraphicsDevice.DrawPrimitives
				spriteBatch.DrawString(font, toolTip, new Vector2(Cursor.Position.X, Cursor.Position.Y), Color.MediumVioletRed);

				toolTip = null;
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
			} else if (e is ToolChange)
			{
				ToolChange tc = (ToolChange)e;
				switch (tc.tool) 
				{
				case (Level.Tools.Syringe):
					Cursor.Texture = toodles.syringe.tool.Texture;
					break;
				case (Level.Tools.Spade):
					Cursor.Texture = toodles.spade.tool.Texture;
					break;
				case (Level.Tools.Scalpel):
					Cursor.Texture = toodles.scalpel.tool.Texture;
					break;
				}
				level.currentTool = tc.tool;
			}
		}
	}
}

