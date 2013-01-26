﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using HeartFarm.ScreenManagerAssets.Menus;
using System.Diagnostics;

namespace HeartFarm
{
    abstract class Menu : Screen
    {
        protected BaseSprite _backGround;
        protected List<MenuOption> menuOptions = new List<MenuOption>();
        protected short _currentSelection = 0;

        public Menu(_removeScreen removeScreen, Texture2D backGround)
            :base(removeScreen)
        {
            _backGround = new BaseSprite(backGround);
            _backGround.LayerDepth = .2f;
        }

        public override void draw(SpriteBatch spriteBatch, GameTime gametime)
        {
            _backGround.Draw(gametime, spriteBatch);

            foreach (MenuOption mo in menuOptions)
            {
                mo.draw(spriteBatch, gametime);
            }
        }



        public override Screen update(InputManager IM)
        {
            if (IM.CurrentGamePadState.Buttons.A == Microsoft.Xna.Framework.Input.ButtonState.Pressed &&
                IM.PreviousGamePadState.Buttons.A == Microsoft.Xna.Framework.Input.ButtonState.Released)
            {
                //SoundManager.PlaySound(SFX.MenuSelect, 1);
            }

            if (menuOptions.Count != 0) //skip the up/down stuff if there are no options
            {
                if (IM.CurrentGamePadState.ThumbSticks.Left.Y > .5f && IM.PreviousGamePadState.ThumbSticks.Left.Y < .5f)//go up
                {
                    //SoundManager.PlaySound(SFX.MenuSelection, 1);

                    menuOptions[_currentSelection].IsSelected = false; //the current one is no longer selected
                    _currentSelection--;
                    if (_currentSelection < 0)
                        _currentSelection = (short)(menuOptions.Count - 1);

                    menuOptions[_currentSelection].IsSelected = true; //the next one is
                }
                else if (IM.CurrentGamePadState.ThumbSticks.Left.Y < -.5f && IM.PreviousGamePadState.ThumbSticks.Left.Y > -.5f)
                {
                    //SoundManager.PlaySound(SFX.MenuSelection, 1);

                    menuOptions[_currentSelection].IsSelected = false; //the current one is no longer selected
                    _currentSelection++;
                    if (_currentSelection >= menuOptions.Count)
                        _currentSelection = 0;

                    menuOptions[_currentSelection].IsSelected = true; //the next one is
                }
            }

            return null;
        }

        public override void onTop(bool toptop)
        {
            if (toptop && !isOnTop)
            {
                foreach(MenuOption mo in menuOptions)
                {
                    mo.textLayer *= 5;
                    mo.buttonLayer *= 5;
                }
                _backGround.LayerDepth += .2f;
            }
            else if(!toptop && isOnTop)
            {
                foreach (MenuOption mo in menuOptions)
                {
                    mo.textLayer /= 5;
                    mo.buttonLayer /= 5;
                }
                _backGround.LayerDepth -= .2f;
            }

            isOnTop = toptop;
        }
    }
}
