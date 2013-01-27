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
			
			syringe = new TextureButton(CM, "ButtonIdle", Vector.Zero, "ButtonHover", "ButtonClick");
		}
		
		public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
		{
			syringe.Draw(gameTime, spriteBatch);
		}
		
		public void Update()
		{
			
		}
	}
}

