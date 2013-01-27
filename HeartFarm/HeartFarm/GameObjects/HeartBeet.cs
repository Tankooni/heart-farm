using System;
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

		public Vector Position {
			get { return _sprite.Position; }
			set {
				if(_sprite != null)
					_sprite.Position = value;
			}
		}

		public HeartBeet(Vector pos)
		{
			_size = 10;
			_bloodAmount = _size / 2;
			_rateOfGrowth = 0.1;
			_rateOfBlood = 1;

			Position = pos;

			_sprite = new BaseSprite(Game1.g_content, "HeartBeet");
		}

		public HeartBeet (int sentSize, int sentBlood, double sentGrowthRate, double sentBloodRate, Vector pos)
		{
			_size = sentSize;
			_bloodAmount = sentBlood;
			_rateOfGrowth = sentGrowthRate;
			_rateOfBlood = sentBloodRate;

			Position = pos;
			
			_sprite = new BaseSprite(Game1.g_content, "HeartBeet");

		}

		public void OnEvent (Event e)
		{
			if (e is MousePosition) {
				MousePosition me = (MousePosition) e;

				
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
			if(_size > 200)
				_size = 200;

			//make it make blood
			_bloodAmount += _rateOfBlood;
			if(_bloodAmount > _size)
				_bloodAmount = _size;
		}
	}
}

