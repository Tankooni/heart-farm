using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace HeartFarm
{
	public class NightTint : Screen
	{
		Texture2D tont;
		UI _ui;

		public NightTint(UI ui)
		{
			_ui = ui;
		}

		public override void draw(SpriteBatch spriteBatch, GameTime gametime)
		{
			Drawer.drawNight(spriteBatch);
		}

		public override Screen update ()
		{
			Drawer.setNightAlpha((int)(Math.Abs(Math.Sin(_ui.ClockRotation/2))*133));
			return null;
		}
	}
}

