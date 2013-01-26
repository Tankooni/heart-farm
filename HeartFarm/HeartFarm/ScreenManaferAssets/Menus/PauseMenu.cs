//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using Microsoft.Xna.Framework.Content;
//using Microsoft.Xna.Framework.Graphics;
//using Microsoft.Xna.Framework;
//
//namespace HeartFarm.ScreenManagerAssets.Menus
//{
//    class PauseMenu : Menu
//    {
//        Level _parent;
//        ContentManager _CM;
//
//        public PauseMenu(_removeScreen removeScreen, ContentManager CM, Color tint, Level parent)
//            :base(removeScreen, CM.Load<Texture2D>("PauseMenuOverlay"))
//        {
//            menuOptions.Add(new MenuOption("Resume", new Rectangle(300, 150, 200, 50), new Color(tint.R,  tint.G , tint.B), Color.Black, CM.Load<SpriteFont>("IntroScreenOptions")));
//            menuOptions.Add(new MenuOption("Exit Game", new Rectangle(300, 300, 200, 50), new Color(tint.R, tint.G, tint.B), Color.Black, CM.Load<SpriteFont>("IntroScreenOptions")));
//
//            menuOptions[_currentSelection].IsSelected = true;
//
//            tint = new Color(0xFF - tint.R, 0xFF - tint.G, 0xFF - tint.B); //invert it
//            tint.A = 100;//give it transparency
//            _backGround.Tint = tint;
//            _parent = parent;
//            _CM = CM;
//        }
//
//        public override void draw(SpriteBatch spriteBatch, GameTime gametime) 
//        {
//            base.draw(spriteBatch, gametime);
//        }
//
//        public override Screen update(InputManager IM)
//        {
//            Screen nextScreen = null;
//            if (IM.CurrentGamePadState.Buttons.A == Microsoft.Xna.Framework.Input.ButtonState.Pressed &&
//                IM.PreviousGamePadState.Buttons.A == Microsoft.Xna.Framework.Input.ButtonState.Released)
//            {
//                if (_currentSelection == 0)//resume
//                {
//                    CB_removeScreen(this); //get rid of the overlay
//                }
//                else //exit
//                {
//                    CB_removeScreen(_parent);
//                    CB_removeScreen(this);
//                    nextScreen = new IntroScreen(CB_removeScreen, _CM, _parent._gameover, _parent._aspectRatio);
//                }
//            }
//            base.update(IM);
//            
//            return nextScreen;
//        }
//    }
//}
