using System;

namespace HeartFarm
{
	//using OnGO = Listener.OnEvent;

	public interface Listener
	{
		void OnEvent(Event e);
	}
}

