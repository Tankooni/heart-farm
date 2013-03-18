using System;
using System.Collections.Generic;

namespace HeartFarm
{
	public class Level:Screen, Listener
	{
		FarmPlot[,] plots;
		public static float BloodLevel = 0;
		public float BloodTarget = 1000;
		public int vials = 0;
		public int requiredVials = 1;

		public HeartBeet transplant;
		public int day = 1;

		public enum Tools
		{
			Syringe,
			Spade,
			Scalpel,
			Heart
		}

		public Tools currentTool = Tools.Syringe;

		public Level ()
		{
			transplant = new HeartBeet(new Vector(0, 0), this);

			plots = new FarmPlot[5, 5];
			bool beetPlanted = false;
			for (int i = 0; i < 5; i++) {
				for (int j = 0; j < 5; j++) {
					plots [i, j] = new FarmPlot (new Vector (j * 64f + 250, i * 64f + 160), this);
					if (Game1.rand.Next (100) < 3) {
						//beetPlanted = true;
						//plots [i, j].Beet = new HeartBeet (plots [i, j].Position, this);
					}

				}
			}
			if (!beetPlanted) {
				int i = Game1.rand.Next (5);
				int j = Game1.rand.Next (5);
				plots [i, j].Beet = new HeartBeet (plots [i, j].Position, this);
			}

			//add listeners
			EventManager.g_EM.AddListener(new DayChanged(), this);
		}

		public override void draw (Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch, Microsoft.Xna.Framework.GameTime gametime)
		{
			//throw new System.NotImplementedException ();
			for (int i = 0; i < 5; i++) {
				for (int j = 0; j < 5; j++) {
					plots [i, j].Draw(spriteBatch, gametime);
				}	
			}
		}

		public override Screen update ()
		{
			if (BloodLevel >= BloodTarget) {
				BloodLevel -= BloodTarget;
				vials++;
			} 

			foreach(FarmPlot p in plots)
				p.Update();
			return null;
		}

		public void OnEvent (Event e)
		{
			if (e is DayChanged) {
				day++;

				//see if the player lost
				if(vials < requiredVials)
				{
					EventManager.g_EM.QueueEvent(new ChangeScene(new SceneGameOver()));
				}
				else
				{
					vials -= requiredVials;
				}
				requiredVials++;

			}
		}
	}
}

