using System;

namespace HeartFarm
{
	public class SceneTitle : Scene
	{
		public SceneTitle ()
			:base(Game1.g_content)
		{
			this.pushScreen(new TitleScreen());
		}
	}
}

