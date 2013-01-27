using System;

namespace HeartFarm
{
	public class DrawToolTip : Event
	{
		public String s;
		public DrawToolTip ()
		{
		}
		public DrawToolTip (String s)
		{
			this.s = s;
		}
	}
}

