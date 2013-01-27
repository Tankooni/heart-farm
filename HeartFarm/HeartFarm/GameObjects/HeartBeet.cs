using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace HeartFarm
{
	public class HeartBeet : Listener
	{
		public double _size;
		public double _bloodAmount;
		public double _rateOfGrowth;
		public double _rateOfBlood;

		BaseSprite _sprite;
		State state;
		public Rectangle hitbox;

		public enum State
		{
			Idle,
			Hovered,
			Clicked
		}

		public Vector Position {
			get { return _sprite.Position; }
			set {
				if(_sprite != null)
				{
					_sprite.Position = value;
					hitbox = new Rectangle((int)value.X, (int)value.Y, _sprite.Width, _sprite.Height);
				}
			}
		}

		public HeartBeet(Vector pos)
		{
			_size = 10;
			_bloodAmount = _size / 2;
			_rateOfGrowth = 0.1;
			_rateOfBlood = 1;



			_sprite = new BaseSprite(Game1.g_content, "HeartBeet");
			_sprite.Scale.X = _sprite.Scale.Y = (float)_size/100.0f; 
			Position = pos;

			EventManager.g_EM.AddListener(new MousePosition(), this);
			EventManager.g_EM.AddListener(new MouseButtonPressed(), this);
			EventManager.g_EM.AddListener(new MouseButtonReleased(), this);
		}

		public HeartBeet (int sentSize, int sentBlood, double sentGrowthRate, double sentBloodRate, Vector pos)
		{
			_size = sentSize;
			_bloodAmount = sentBlood;
			_rateOfGrowth = sentGrowthRate;
			_rateOfBlood = sentBloodRate;


			
			_sprite = new BaseSprite(Game1.g_content, "HeartBeet");
			_sprite.Scale.X = _sprite.Scale.Y = (float)_size/100.0f;
			Position = pos;

			EventManager.g_EM.AddListener(new MousePosition(), this);
			EventManager.g_EM.AddListener(new MouseButtonPressed(), this);
			EventManager.g_EM.AddListener(new MouseButtonReleased(), this);
		}

		public void OnEvent (Event e)
		{
			if (e is MousePosition) {
				MousePosition mp = (MousePosition)e;
				if (hitbox.Contains (mp.pos.X, mp.pos.Y)) {
					//mouse is hovering over the button, change the texture
					if (state == State.Idle)
						state = State.Hovered;
					//e.isDoneProcessing = true;
				}
				
			} else if (e is MouseButtonPressed) {
				MouseButtonPressed mbp = (MouseButtonPressed)e;
				
				if (state == State.Hovered) {
					state = State.Clicked;
					//mbp.isDoneProcessing = true;
				}
			} else if (e is MouseButtonReleased) {
				//set the state back to idle
				if (state == State.Clicked) {
					state = State.Idle;
					Console.WriteLine("Blood Extracted");

					_bloodAmount -= 50;
					Level.BloodLevel+=25;
//					if (onPressed != null)
//						onPressed ();
				}
			}
		}

		public void draw (Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch, Microsoft.Xna.Framework.GameTime gametime)
		{
			_sprite.Draw(gametime, spriteBatch);
		}
		
		public void update ()
		{
			//make it grow
			_size += _rateOfGrowth;
			if (_size > 200)
				_size = 200;

			//make it make blood
			_bloodAmount += _rateOfBlood;
			if (_bloodAmount > _size)
				_bloodAmount = _size;

			if (_bloodAmount < 20) {
			}

			_sprite.Scale.X = _sprite.Scale.Y = (float)_size/200.0f;
			hitbox = new Rectangle((int)Position.X, (int)Position.Y, _sprite.Width, _sprite.Height);
		}
	}
}

