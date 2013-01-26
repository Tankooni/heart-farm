using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace HeartFarm
{
    abstract class Screen
    {
        protected bool isOnTop = true;

        public delegate void _removeScreen(Screen screen);

        protected _removeScreen CB_removeScreen;

        public Screen(_removeScreen removeScreen)
        {
            CB_removeScreen = removeScreen;
        }

        abstract public Screen update(InputManager IM); //returns the next screen to 
        abstract public void draw(SpriteBatch spriteBatch, GameTime gametime);
        abstract public void onTop(bool toptop);
    }
}
