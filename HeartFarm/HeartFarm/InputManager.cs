using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace HeartFarm
{
    class InputManager
    {
        PlayerIndex playerIndex = PlayerIndex.One;

        GamePadState _currentGamePadState = GamePad.GetState(PlayerIndex.One);
        GamePadState _previousGamePadState = GamePad.GetState(PlayerIndex.One);

        public GamePadState CurrentGamePadState
        {
            get { return _currentGamePadState; }
            set { _currentGamePadState = value; }
        }
        public GamePadState PreviousGamePadState
        {
            get { return _previousGamePadState; }
            set { _previousGamePadState = value; }
        }

        public InputManager()
        {
            playerIndex = PlayerIndex.One;
        }

        public InputManager(int player)
        {
            if (player > 0 && player <= 4)
                playerIndex = (PlayerIndex)(player - 1);
            else
                throw new Exception("Player " + (player - 1) + "throws rocks at you.");
        }

        public void update()
        {
            _previousGamePadState = _currentGamePadState;
            _currentGamePadState = GamePad.GetState(playerIndex);
        }
    }
}
