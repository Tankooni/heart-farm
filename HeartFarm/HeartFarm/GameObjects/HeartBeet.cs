using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;

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

		Level parentLevel;

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
					hitbox = new Rectangle ((int)value.X - _sprite.Width/2, (int)value.Y - _sprite.Height/2, _sprite.Width, _sprite.Height);
				}
			}
		}

		public HeartBeet (Vector pos, Level sentLevel, double sentSize = 125, double sentBlood = 100, double sentGrowthRate = .05, double sentBloodRate = .09)
		{
			_size = sentSize;
			_bloodAmount = sentBlood;
			_rateOfGrowth = sentGrowthRate;
			_rateOfBlood = sentBloodRate;

			parentLevel = sentLevel;

			_sprite = new BaseSprite(Game1.g_content, "HeartBeet");

			_sprite.Origin = new Vector(_sprite.Width/2, _sprite.Height/2, 0);
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
				if(state == State.Clicked && parentLevel.currentTool == Level.Tools.Syringe)
				{
					if (state == State.Clicked) {
						state = State.Idle;
						if(_bloodAmount >= 25)
						{
						_bloodAmount -= 25;
						Level.BloodLevel+=25;
						}
						else
						{
							Level.BloodLevel += (float)_bloodAmount;
							_bloodAmount = 0;
						}
					}
				}
				else if(state == State.Clicked && parentLevel.currentTool == Level.Tools.Scalpel && _size > 124)
				{
					_size = (_size / 2) - 10;
					_bloodAmount = (_bloodAmount / 2) - 20;

					parentLevel.transplant._size = _size;
					parentLevel.transplant._bloodAmount = _bloodAmount;

					EventManager.g_EM.QueueEvent(new ToolChange(HeartFarm.Level.Tools.Heart));
					//parentLevel.currentTool = Level.Tools.Heart;
				}
				state = State.Idle;
			}
		}

		public void draw (Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch, Microsoft.Xna.Framework.GameTime gametime)
		{
			_sprite.Draw(gametime, spriteBatch);


		}
		
		public void update ()
		{
			//make it grow if it has more than 50% blood capacity.
			if ((_bloodAmount * 2f) > _size) {
				_size += _rateOfGrowth;
			}
			//if it's under 25% blood capacity, it shrinks
			else if ((_bloodAmount * 4) < _size) 
			{
				if(_size > 20)
				{
					_size -= _rateOfGrowth;
				}
			}


			if (_size > 200)
				_size = 200;

			//make it make blood
			_bloodAmount += _rateOfBlood;
			if (_bloodAmount > _size)
				_bloodAmount = _size;

			if (_bloodAmount < 20) {
			}

			_sprite.Scale.X = _sprite.Scale.Y = (float)_size/200.0f;
			hitbox = new Rectangle((int)Position.X - _sprite.Width/2, (int)Position.Y - _sprite.Height/2, _sprite.Width, _sprite.Height);
			
			//have it draw the tooltip if the mouse is hovering over it
			if(state == State.Hovered || state == State.Clicked)
				EventManager.g_EM.QueueEvent(new DrawToolTip("Size: " + ((int)_size).ToString() + "\n"
				                                             + "Blood: " + ((int)_bloodAmount).ToString()));
		}
	}
}

