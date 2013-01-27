using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace HeartFarm
{
	public class ToolBar
	{
		TextureButton syringe;
		TextureButton spade;
		TextureButton scalpel;
		
		public ToolBar(ContentManager CM)
		{
			
			syringe = new TextureButton(CM, "ButtonIdle", Vector.Zero, "ButtonHover", "ButtonClick", "Syringe");
			syringe.onPressed = Moo;
			spade = new TextureButton(CM, "ButtonIdle", Vector.Zero, "ButtonHover", "ButtonClick", "Spade");
			//scalpel.position = new Vector(syringe.position.X + syringe.hitbox.Width, syringe.position.Y);
			spade.position.X = syringe.position.X + syringe.hitbox.Width;
			spade.position.Y = syringe.position.Y;
			spade.hitbox.X = (int)spade.position.X;
			spade.hitbox.Y = (int)spade.position.Y;
			//spade.onPressed = Moo;
			scalpel = new TextureButton(CM, "ButtonIdle", Vector.Zero, "ButtonHover", "ButtonClick", "Scalpel");
			scalpel.position = new Vector(spade.position.X + spade.hitbox.Width, spade.position.Y);
			scalpel.hitbox.X = (int)scalpel.position.X;
			scalpel.hitbox.Y = (int)scalpel.position.Y;
			//scalpel.onPressed = Moo;
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
			Console.WriteLine("Moo");
		}
	}
}

