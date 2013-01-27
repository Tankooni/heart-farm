using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace HeartFarm
{
	public class Clock
	{
		BaseSprite Fill;
		BaseSprite Border;
		GameTime initialTime;

		public Vector Position {
			get {
				return Border.Position;
			}
			set {
				Border.Position = value;
				Fill.Position = value;
			}
		}

		public float Rotation
		{
			get { return Fill.Rotation;}
			set { Fill.Rotation = value;}
		}
		
		public int Width {get {return Border.Width;}}
		public int Height { get {return Border.Height;}}

		public Clock (ContentManager CM)
		{
			Fill = new BaseSprite(CM, "DayNightFill");
			Border = new BaseSprite(CM, "DayNightOutline");

			Border.Origin = Fill.Origin = new Vector(Fill.Width/2, Fill.Width/2);
			Border.Scale = Fill.Scale = new Vector(1.3f, 1.3f);

			initialTime = Game1.g_time;
		}

		public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
		{
			Fill.Draw(gameTime, spriteBatch);
			Border.Draw(gameTime, spriteBatch);
		}

		public void Update()
		{
			//Make 70 seconds days
			Rotation += Game1.g_time.ElapsedGameTime.Milliseconds / 20000f;
		}
	}
}

