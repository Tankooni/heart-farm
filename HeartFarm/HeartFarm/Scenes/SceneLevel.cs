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
			Level l = new Level();
			this.pushScreen(l);
			UI ui = new UI(Game1.g_content, l);
			this.pushScreen(new NightTint(ui));
			this.pushScreen(ui);
		}
	}
}

