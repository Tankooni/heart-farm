using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace HeartFarm
{
	public class FarmPlot : Listener
	{
		private HeartBeet beet;
		private BaseSprite plotSprite;

		public Rectangle hitbox;

		public Level parentLevel;

		public enum State
		{
			Idle,
			Hovered,
			Clicked
		}

		State state;

		public HeartBeet HeartBeet {
			get { return beet;}
			set { beet = value;}
		}

		public Vector Position {
			get{ return plotSprite.Position;}
			set {
					if (plotSprite != null)
					{
					plotSprite.Position = value;
					hitbox = new Rectangle ((int)value.X, (int)value.Y, plotSprite.Width, plotSprite.Height);
					}
				}
		}

		public FarmPlot (Vector pos, Level sentLevel)
		{
			//init plot sprite
			plotSprite = new BaseSprite(Game1.g_content, "PlotTile");
			plotSprite.Position = pos;
			plotSprite.Origin = new Vector(plotSprite.Width/2, plotSprite.Height/2, 0);

			hitbox = new Rectangle ((int)pos.X - plotSprite.Width/2, (int)pos.Y - plotSprite.Height/2, plotSprite.Width, plotSprite.Height);

			parentLevel = sentLevel;

			EventManager.g_EM.AddListener(new MousePosition(), this);
			EventManager.g_EM.AddListener(new MouseButtonPressed(), this);
			EventManager.g_EM.AddListener(new MouseButtonReleased(), this);
		}

		public void OnEvent (Event e)
		{
			if (e is MousePosition) {
				MousePosition mp = (MousePosition)e;
				if (hitbox.Contains (mp.pos.X, mp.pos.Y)) {
					//Console.WriteLine(hitbox + " " + mp.pos);
					//mouse is hovering over the button, change the texture
					if (state == State.Idle)
						state = State.Hovered;
					//e.isDoneProcessing = true;
				} else if(state == State.Hovered)
					state = State.Idle;
				
			} else if (e is MouseButtonPressed) {
				MouseButtonPressed mbp = (MouseButtonPressed)e;
				if (state == State.Hovered) {
					state = State.Clicked;
					//mbp.isDoneProcessing = true;
				}
			} else if (e is MouseButtonReleased) {
				//set the state back to idle
				if(state == State.Clicked && parentLevel.currentTool == Level.Tools.Heart)
				{
					if(beet == null)
					{
						beet = new HeartBeet(Position, parentLevel, parentLevel.transplant._size, parentLevel.transplant._bloodAmount);
						EventManager.g_EM.QueueEvent(new ToolChange(HeartFarm.Level.Tools.Syringe));
						//parentLevel.currentTool = Level.Tools.Syringe;
					}
				}
				state = State.Idle;
			}
		}


		public void Update ()
		{
			if(beet != null)
				beet.update();
		}

		public void Draw (SpriteBatch sb, GameTime gt)
		{
			plotSprite.Draw (gt, sb);
			if (beet != null) {
				beet.draw(sb, gt);
			}
		}
	}
}

