using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace HeartFarm
{
    public abstract class Screen
    {
		protected bool preventUpdates = false;
		protected bool preventDrawing = false;
		public bool PreventUpdates {
			get { return preventUpdates;}
		}
		public bool PreventDrawing {
			get { return preventDrawing;}
		}

        public Screen()
        {
        }

        abstract public Screen update(); //returns the next screen to 
        abstract public void draw(SpriteBatch spriteBatch, GameTime gametime);
    }
}
