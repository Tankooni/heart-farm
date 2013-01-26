//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using Microsoft.Xna.Framework.Graphics;
//using Microsoft.Xna.Framework;
//using Microsoft.Xna.Framework.Content;
//
//namespace HeartFarm.ScreenManagerAssets.Menus
//{
//    class Instructions : Menu
//    {
//        ContentManager _CM;
//        HeartFarm.Gameobjects.Hourglass.Gameover _gameover;
//        float _aspectRatio;
//
//        public Instructions(_removeScreen removeScreen, ContentManager CM, HeartFarm.Gameobjects.Hourglass.Gameover gameover, float aspectRatio)
//            :base(removeScreen, CM.Load<Texture2D>("Instructions"))
//        {
//            menuOptions.Add(new MenuOption("Main Menu", new Rectangle(0, 0, 200, 50), Color.Turquoise, Color.Black, CM.Load<SpriteFont>("IntroScreenOptions")));
//
//            menuOptions[_currentSelection].IsSelected = true;
//
//            _CM = CM;
//            _gameover = gameover;
//            _aspectRatio = aspectRatio;
//
//            _backGround.Scale = new Vector(.85f,.80f,1);
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
//                CB_removeScreen(this);
//            }
//            base.update(IM);
//            
//            return nextScreen;
//        }
//    }
//}
