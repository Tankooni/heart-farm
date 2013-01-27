using System;
using Microsoft.Xna.Framework.Graphics;

namespace HeartFarm
{
	public class MainMenu : Menu
	{
		public MainMenu ()
			: base(Game1.g_content.Load<Texture2D>("TitleScreenBackground"))
		{
		}

		public override Screen update ()
		{
			return null;
		}
	}
}

