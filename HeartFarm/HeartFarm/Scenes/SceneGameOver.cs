using System;

namespace HeartFarm
{
	public class SceneGameOver : Scene
	{
		public SceneGameOver ()
			:base(Game1.g_content)
		{
			this.pushScreen(new GameOverScreen());
		}
	}
}

