using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace HeartFarm
{
	public class EventManager
	{
		public static EventManager g_EM;

		Dictionary<Event, List<Listener>> EventListeners = new Dictionary<Event, List<Listener>>();
		Queue<Event> Events = new Queue<Event>();

		static EventManager()
		{
			g_EM = new EventManager();
		}

		public EventManager(){}

		public void AddListener(Event e, Listener l)
		{
			if (!EventListeners.ContainsKey(e))
				EventListeners.Add (e, new List<Listener>());
			EventListeners[e].Add (l);
		}

		public void RemoveListener(Event e, Listener l)
		{
			//TODO: Implement this
		}

		public void ClearListeners ()
		{
			EventListeners.Clear();
		}

		public void QueueEvent(Event e)
		{
			Events.Enqueue(e);
		}

		public void Update()
		{
			//pop the next event in the queue
			while(Events.Count > 0)
			{
				var e = Events.Peek();
				Events.Dequeue();

				if(!EventListeners.ContainsKey(e))
					break;

				//call each listener registered to this event type
				foreach(Listener l in EventListeners[e])
				{
					l.OnEvent(e);
					if(e.isDoneProcessing)
						break;
				}
			}
		}
	}
}

