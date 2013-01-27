using System;
using Microsoft.Xna.Framework.Content;

namespace HeartFarm
{
	public class HeartBeet: Screen, Listener
	{
		public int _size;
		public int _bloodAmount;
		public double _rateOfGrowth;
		public double _rateOfBlood;

		public Vector _position;
		public Vector _scale;
		BaseSprite _sprite;

		public HeartBeet(Vector sentPos, Vector sentScale)
		{
			_size = 10;
			_bloodAmount = _size / 2;
			_rateOfGrowth = 0.1;
			_rateOfBlood = 1;

			_position = sentPos;
			_scale = sentScale;

			_sprite = new BaseSprite(Game1.g_content, "HeartBeet", _position, _scale);
		}

		public HeartBeet (int sentSize, int sentBlood, double sentGrowthRate, double sentBloodRate, Vector sentPos, Vector sentScale)
		{
			_size = sentSize;
			_bloodAmount = sentBlood;
			_rateOfGrowth = sentGrowthRate;
			_rateOfBlood = sentBloodRate;
			
			_position = sentPos;
			_scale = sentScale;
			
			_sprite = new BaseSprite(Game1.g_content, "HeartBeet", _position, _scale);

		}

		public void OnEvent (Event e)
		{
			if (e is MousePosition) {
				MousePosition me = (MousePosition) e;

				
			}
		}

		public override void draw (Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch, Microsoft.Xna.Framework.GameTime gametime)
		{
			_sprite.Draw(gametime, spriteBatch);
		}
		
		public override Screen update ()
		{
			throw new System.NotImplementedException ();
		}
	}
}

