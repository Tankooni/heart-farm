using System;

namespace HeartFarm
{
	public class SceneLevel : Scene
	{
		public SceneLevel ()
			:base(Game1.g_content)
		{
			//this should have a background, level and hud
			this.pushScreen(new LevelBackground());
			this.pushScreen(new Level());
			this.pushScreen(new UI(Game1.g_content));
		}
	}
}

