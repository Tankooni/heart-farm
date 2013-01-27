using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace HeartFarm
{
	public class ToolBar
	{
		public TextureButton syringe;
		public TextureButton spade;
		public TextureButton scalpel;
		
		public ToolBar(ContentManager CM)
		{
			syringe = new TextureButton(CM, "ButtonIdle", Vector.Zero, "ButtonHover", "ButtonClick", "Syringe");
			syringe.position = new Vector(Game1.ScreenSize.X/2 - 3*syringe.hitbox.Width/2, Game1.ScreenSize.Y - syringe.hitbox.Height);
			syringe.onPressed = Moo;

			spade = new TextureButton(CM, "ButtonIdle", Vector.Zero, "ButtonHover", "ButtonClick", "Spade");
			spade.position = new Vector(syringe.position.X + syringe.hitbox.Width, syringe.position.Y);
			spade.hitbox.X = (int)spade.position.X;
			spade.hitbox.Y = (int)spade.position.Y;
			spade.onPressed = Moo2;

			scalpel = new TextureButton(CM, "ButtonIdle", Vector.Zero, "ButtonHover", "ButtonClick", "Scalpel");
			scalpel.position = new Vector(spade.position.X + spade.hitbox.Width, spade.position.Y);
			scalpel.hitbox.X = (int)scalpel.position.X;
			scalpel.hitbox.Y = (int)scalpel.position.Y;
			scalpel.onPressed = Moo3;
		}
		
		public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
		{
			syringe.Draw(gameTime, spriteBatch);
			spade.Draw(gameTime, spriteBatch);
			scalpel.Draw(gameTime, spriteBatch);
		}
		
		public void Update()
		{

		}

		public void Moo()
		{
			EventManager.g_EM.QueueEvent(new ToolChange(Level.Tools.Syringe));
		}

		public void Moo2()
		{
			EventManager.g_EM.QueueEvent(new ToolChange(Level.Tools.Spade));
		}

		public void Moo3()
		{
			EventManager.g_EM.QueueEvent(new ToolChange(Level.Tools.Scalpel));
		}
	}
}

