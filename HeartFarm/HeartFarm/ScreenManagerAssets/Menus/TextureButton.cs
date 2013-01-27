using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace HeartFarm
{
	public class TextureButton : Listener
	{
		Texture2D idle;
		Texture2D hover;
		Texture2D clicked;

		Rectangle hitbox;

		State state;

		public delegate void OnPressed();
		public OnPressed onPressed;

		public Vector position;

		public enum State
		{
			Idle,
			Hovered,
			Clicked
		}

		public TextureButton(Texture2D idle, Vector position = null, Texture2D hover = null, Texture2D clicked = null)
		{
			this.idle = idle;
			this.hover = hover;
			this.clicked = clicked;
			if(position == null)
				this.position = position;
			else
				this.position = new Vector(0,0,0);

			//hitbox is the same size as the texture for now
			hitbox = idle.Bounds;

			EventManager.g_EM.AddListener(new MousePosition(), this);
			EventManager.g_EM.AddListener(new MouseButtonPressed(), this);
			EventManager.g_EM.AddListener(new MouseButtonReleased(), this);
		}


		public void Draw (GameTime gameTime, SpriteBatch spriteBatch)
		{
			Texture2D tex;

			//select the correct texture
			switch (state) {
			case State.Idle:
				tex = idle;
				break;
			case State.Hovered:
				tex = hover;
				//reset the state to idle
				state = State.Idle;
				break;
			case State.Clicked:
				tex = clicked;
				break;
			default:
				throw new Exception("Invilad state set to button");
			}

			spriteBatch.Draw(tex, position.toVector2(), Color.White);
		}

		public void OnEvent (Event e)
		{
			if (e is MousePosition) {
				MousePosition mp = (MousePosition)e;

				if (hitbox.Contains(mp.pos.X, mp.pos.Y)) {
					//mouse is hovering over the button, change the texture
					if(state == State.Idle)
						state = State.Hovered;

					e.isDoneProcessing = true;
				}

			} else if (e is MouseButtonPressed) {
				MouseButtonPressed mbp = (MouseButtonPressed)e;

				if (state == State.Hovered) {
					state = State.Clicked;
					mbp.isDoneProcessing = true;
				}
			} else if (e is MouseButtonReleased) {
				//set the state back to idle
				if(state == State.Clicked)
					state = State.Idle;

				if(onPressed != null)
					onPressed();
			}
		}
	}
}

