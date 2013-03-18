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
			if(l.ToString() == "HeartFarm.HeartBeet")Console.WriteLine ("HeartBeet Event: " + e);
			if (!EventListeners.ContainsKey (e)) {
				EventListeners.Add (e, new List<Listener> ());
				if(l.ToString() == "HeartFarm.HeartBeet")Console.WriteLine("New Key Added");
			}
			EventListeners[e].Add (l);
		}

		public void RemoveListener(Event e, Listener l)
		{
			//TODO: Implement this
			EventListeners[e].Remove(l);
		}

		public void ClearListeners ()
		{
			EventListeners.Clear();
		}

		public void QueueEvent(Event e)
		{
			Events.Enqueue(e);
		}

		public void Update ()
		{
			try {
				//pop the next event in the queue
				while (Events.Count > 0) {
					var e = Events.Peek ();
					Events.Dequeue ();

					if (!EventListeners.ContainsKey (e))
						break;
					Console.WriteLine(EventListeners[e].Count);
					//call each listener registered to this event type
					for(int i = EventListeners[e].Count-1; i >= 0; i--)
					{

						EventListeners[e][i].OnEvent (e);

					}

//					foreach (Listener l in EventListeners[e]) {
//						l.OnEvent (e);
//						if (e.isDoneProcessing)
//							break;
//					}
					//Console.WriteLine("---------------------------------------------------");
				}
			} catch (InvalidOperationException e)
			{
				Console.WriteLine(e);
			}
		}
	}
}

