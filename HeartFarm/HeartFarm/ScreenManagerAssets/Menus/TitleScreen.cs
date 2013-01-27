using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace HeartFarm
{
	public class TitleScreen : Menu, Listener
	{
		BaseSprite start;

		public TitleScreen ()
			: base(Game1.g_content.Load<Texture2D>("TitleScreenBackground"))
		{
			start = new BaseSprite(Game1.g_content, "TitleScreen");

			/*float heightRatio = Game1.ScreenSize.Y / _backGround.Height;
			float widthRatio = Game1.ScreenSize.X / _backGround.Width;

			float scale = heightRatio > widthRatio ? heightRatio : widthRatio;*/

			start.Origin = new Vector(start.Width/2, start.Height/2, 1);
			start.Position = new Vector(Game1.ScreenSize.X /2 + 15, Game1.ScreenSize.Y /2 + 35, 0);
			start.Scale = _backGround.Scale;//new Vector(scale, scale, scale);

			EventManager.g_EM.AddListener(new MouseButtonReleased(), this);
			Game1.g_inputManager.addActiveButton(Microsoft.Xna.Framework.Input.Keys.Enter);
			EventManager.g_EM.AddListener(new KeyboardButtonReleased(), this);
		}

		public override Screen update ()
		{
			start.Rotation = start.Rotation + .02f;

			return null;
		}

		public override void draw (SpriteBatch spriteBatch, Microsoft.Xna.Framework.GameTime gametime)
		{
			base.draw (spriteBatch, gametime);

			//draw the "Press Start!" thing and make it rotate
			start.Draw(gametime, spriteBatch);
		}

		public void OnEvent (Event e)
		{
			if (e is MouseButtonReleased || 
			    e is KeyboardButtonReleased && ((KeyboardButtonReleased)e).keyReleased == Microsoft.Xna.Framework.Input.Keys.Enter) {
				//either enter was pressed and released or a mouse button was

				EventManager.g_EM.QueueEvent(new ChangeScene(new SceneLevel()));
			}
		}
	}
}

