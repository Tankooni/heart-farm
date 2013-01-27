using System;
using Microsoft.Xna.Framework.Content;

namespace HeartFarm
{
	public class HeartBeet : BaseSprite, Listener
	{
		public HeartBeet (ContentManager cm)
			:base(cm, "heart_beet")
		{

		}

		public void OnEvent (Event e)
		{
			if (e is MousePosition) {
				MousePosition me = (MousePosition) e;

				
			}
		}
	}
}

