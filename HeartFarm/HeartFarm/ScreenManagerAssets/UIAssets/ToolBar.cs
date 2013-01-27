using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace HeartFarm
{
	public class ToolBar
	{
		TextureButton syringe;
		TextureButton shovel;
		TextureButton scalpel;
		
		public ToolBar(ContentManager CM)
		{
			
			syringe = new TextureButton(CM, "Syringe", new Vector(600,600));
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

