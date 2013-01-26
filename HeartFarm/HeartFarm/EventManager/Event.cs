using System;
using System.Reflection;

namespace HeartFarm
{
	abstract public class Event
	{
		public override bool Equals(Object obj)
		{
			return this.GetType() == obj.GetType();
		}
	}
}

