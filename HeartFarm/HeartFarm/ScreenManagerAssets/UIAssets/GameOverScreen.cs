using System;
using Microsoft.Xna.Framework.Graphics;

namespace HeartFarm
{
	public class GameOverScreen : Menu, Listener
	{
		public GameOverScreen ()
			: base(Game1.g_content.Load<Texture2D>("GameOver"))
		{			
			EventManager.g_EM.AddListener(new MouseButtonReleased(), this);
			Game1.g_inputManager.addActiveButton(Microsoft.Xna.Framework.Input.Keys.Enter);
			EventManager.g_EM.AddListener(new KeyboardButtonReleased(), this);
		}
		
		public override Screen update ()
		{
			return null;
		}
		
		public override void draw (SpriteBatch spriteBatch, Microsoft.Xna.Framework.GameTime gametime)
		{
			base.draw (spriteBatch, gametime);
		}
		
		public void OnEvent (Event e)
		{
			if (e is MouseButtonReleased || 
			    e is KeyboardButtonReleased && ((KeyboardButtonReleased)e).keyReleased == Microsoft.Xna.Framework.Input.Keys.Enter) {
				//either enter was pressed and released or a mouse button was
				
				EventManager.g_EM.QueueEvent(new ChangeScene(new SceneTitle()));
			}
		}
	}
}

