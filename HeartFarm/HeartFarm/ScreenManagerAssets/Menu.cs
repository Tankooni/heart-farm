using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Diagnostics;

namespace HeartFarm
{
    public abstract class Menu : Screen
    {
        protected BaseSprite _backGround;
        protected List<TextureButton> buttons = new List<TextureButton>();

        public Menu(Texture2D backGround)
        {
            _backGround = new BaseSprite(backGround);
        }

        public override void draw (SpriteBatch spriteBatch, GameTime gametime)
		{
			_backGround.Draw (gametime, spriteBatch);

			foreach (TextureButton btn in buttons) {
				btn.Draw(gametime, spriteBatch);
			}
		}
    }
}
