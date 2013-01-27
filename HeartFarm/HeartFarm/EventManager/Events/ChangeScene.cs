using System;

namespace HeartFarm
{
	public class ChangeScene : Event
	{
		public Scene scene;
		public ChangeScene () {}
		public ChangeScene (Scene s)
		{
			scene = s;
		}
	}
}

