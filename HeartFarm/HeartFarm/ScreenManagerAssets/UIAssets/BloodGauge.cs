using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace HeartFarm
{
	public class BloodGauge
	{
		BaseSprite bloodVial;
		BaseSprite bloodGauge;
		float _percentToDraw;
		public float PercentToDraw {
			get { return _percentToDraw;}
			set {
				if(value <= 1)
					_percentToDraw = value;
				else if(value < 0)
					_percentToDraw = 0;
				else
					_percentToDraw = 1;
			}
		}

		Rectangle origSize;

		public Vector Position {
			get {
				return bloodVial.Position;
			}
			set {
				bloodVial.Position = value;
				bloodGauge.Position = new Vector(value.X, value.Y + bloodVial.Height - origSize.Height * _percentToDraw);
			}
		}

		public int Width {get {return bloodVial.Width;}}
		public int Height { get {return bloodVial.Height;}}


		public BloodGauge(ContentManager CM)
		{
			bloodVial = new BaseSprite(CM, "BloodGaugeOutLine");
			bloodGauge = new BaseSprite(CM, "BloodGaugeFill");

			bloodVial.LayerDepth = 0.7f;
			bloodGauge.LayerDepth = 0.69f;
			origSize = bloodGauge.ViewBox;

			this.Position = new Vector(100, 100);
			bloodGauge.ViewBox = new Rectangle(origSize.X, (int)(origSize.Y + origSize.Height*(1-_percentToDraw)), origSize.Width, (int)(origSize.Height*_percentToDraw));
			bloodGauge.Position = new Vector(Position.X, Position.Y + bloodVial.Height - origSize.Height*_percentToDraw);
			//bloodGauge.Origin = new Vector(bloodVial.Origin.X, bloodVial.Height);

			//bloodGauge.Origin = new Vector(0, 10);
		}

		public void Update(float percent)
		{
			PercentToDraw = percent;
			bloodGauge.ViewBox = new Rectangle(origSize.X, (int)(origSize.Y + origSize.Height*(1-_percentToDraw)), origSize.Width, (int)(origSize.Height*_percentToDraw));
			bloodGauge.Position = new Vector(Position.X, Position.Y + bloodVial.Height - origSize.Height*_percentToDraw);
			//Console.WriteLine(percentToDraw = (float)Math.Abs(Math.Sin(gameTime.TotalGameTime.Milliseconds)));
		}

		public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
		{
			bloodGauge.Draw(gameTime, spriteBatch);
			bloodVial.Draw(gameTime, spriteBatch);
		}
	}
}

