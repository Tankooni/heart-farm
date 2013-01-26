using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace HeartFarm
{
    class ScreenManager
    {
        ContentManager _CM;

        Stack<Screen> _screens = new Stack<Screen>();

        public ScreenManager(ContentManager CM, float aspectRatio)
        {
            _CM = CM;

            //start out with the intro screen
            //pushScreen(new IntroScreen(removeScreen, CM, gameOver, aspectRatio));
            //pushScreen(new Level(CM, removeScreen, gameOver, aspectRatio));
        }

        public void gameOver()
        {

        }
        public void pushScreen(Screen screen)
        {
            _screens.Push(screen);
        }
        public void removeScreen(Screen screen)
        {
            _screens.Pop();
        }

        public bool update(InputManager IM)
        {
            //check for higher teir key presses
            
            
            //update current screen
            Screen nextScreen = _screens.Peek().update(IM);
            if (nextScreen != null)
                _screens.Push(nextScreen);

            if (_screens.Count == 0)
            {
                return false; //we're done here
            }

            return true;
        }

        public void draw(SpriteBatch spritebatch, GameTime gametime)
        {
            //draw each screen
            
            foreach (Screen screen in _screens.Reverse)
            {
                screen.draw(spritebatch, gametime);
            }
        }
    }
}
