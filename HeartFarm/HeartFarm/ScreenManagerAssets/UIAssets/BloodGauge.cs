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
		public float percentToDraw = 0.9f;
		Rectangle origSize;

		public Vector Position {
			get {
				return bloodVial.Position;
			}
			set {
				bloodVial.Position = value;
				bloodGauge.Position = new Vector(value.X, value.Y + bloodVial.Height - origSize.Height * percentToDraw);
			}
		}



		public BloodGauge(ContentManager CM)
		{
			bloodVial = new BaseSprite(CM, "BloodGaugeOutLine");
			bloodGauge = new BaseSprite(CM, "BloodGaugeFill");

			bloodVial.LayerDepth = 0.7f;
			bloodGauge.LayerDepth = 0.69f;
			origSize = bloodGauge.ViewBox;

			this.Position = new Vector(100, 100);
			bloodGauge.ViewBox = new Rectangle(origSize.X, (int)(origSize.Y + origSize.Height*(1-percentToDraw)), origSize.Width, (int)(origSize.Height*percentToDraw));
			bloodGauge.Position = new Vector(Position.X, Position.Y + bloodVial.Height - origSize.Height*percentToDraw);
			//bloodGauge.Origin = new Vector(bloodVial.Origin.X, bloodVial.Height);

			//bloodGauge.Origin = new Vector(0, 10);
		}

		public void Update(/*GameTime gameTime*/)
		{
			bloodGauge.ViewBox = new Rectangle(origSize.X, (int)(origSize.Y + origSize.Height*(1-percentToDraw)), origSize.Width, (int)(origSize.Height*percentToDraw));
			bloodGauge.Position = new Vector(Position.X, Position.Y + bloodVial.Height - origSize.Height*percentToDraw);
			//Console.WriteLine(percentToDraw = (float)Math.Abs(Math.Sin(gameTime.TotalGameTime.Milliseconds)));
		}

		public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
		{
			bloodGauge.Draw(gameTime, spriteBatch);
			bloodVial.Draw(gameTime, spriteBatch);
		}
	}
}

