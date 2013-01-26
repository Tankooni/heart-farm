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
//    class IntroScreen : Menu
//    {
//        ContentManager _CM;
//        HeartFarm.Gameobjects.Hourglass.Gameover _gameover;
//        float _aspectRatio;
//
//        public IntroScreen(_removeScreen removeScreen, ContentManager CM, HeartFarm.Gameobjects.Hourglass.Gameover gameover, float aspectRatio)
//            :base(removeScreen, CM.Load<Texture2D>("IntroBackground"))
//        {
//            menuOptions.Add(new MenuOption("New Game", new Rectangle(500, 150, 200, 50), Color.Turquoise, Color.Black, CM.Load<SpriteFont>("IntroScreenOptions")));
//            menuOptions.Add(new MenuOption("Instructions", new Rectangle(500, 225, 200, 50), Color.Turquoise, Color.Black, CM.Load<SpriteFont>("IntroScreenOptions")));
//            menuOptions.Add(new MenuOption("Exit", new Rectangle(500, 300, 200, 50), Color.Turquoise, Color.Black, CM.Load<SpriteFont>("IntroScreenOptions")));
//            //SoundManager.PlaySetList(new Musics[]{Musics.Chanter, Musics.Constancy, Musics.Decisions, Musics.Exotics, Musics.Faster, Musics.Movement, Musics.Noise});
//            menuOptions[_currentSelection].IsSelected = true;
//
//            _CM = CM;
//            _gameover = gameover;
//            _aspectRatio = aspectRatio;
//
//            _backGround.Scale = new Vector(.85f,.85f,1);
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
//                if (_currentSelection == 0)//new game
//                {
//                    nextScreen = new Level(_CM, CB_removeScreen, _gameover, _aspectRatio, Color.LightGreen);
//                    CB_removeScreen(this);
//                }
//                else if (_currentSelection == 1)
//                {
//                    nextScreen = new Instructions(CB_removeScreen, _CM, _gameover, _aspectRatio);
//                }
//                else //exit
//                {
//                    CB_removeScreen(this);
//                }
//            }
//            base.update(IM);
//            
//            return nextScreen;
//        }
//    }
//}
