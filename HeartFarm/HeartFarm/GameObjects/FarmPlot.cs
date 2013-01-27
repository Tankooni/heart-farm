using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace HeartFarm
{
	public class FarmPlot
	{
		private HeartBeet beet;
		private BaseSprite plotSprite;

		public HeartBeet HeartBeet {
			get { return beet;}
			set { beet = value;}
		}

		public FarmPlot (Vector pos)
		{
			//init plot sprite
			plotSprite = new BaseSprite(Game1.g_content, "PlotTile");
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

