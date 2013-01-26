using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace HeartFarm.Gameobjects
{
    class Player : Gameobject
    {
        enum PlayerStates
        {
            MovingRight,
            MovingLeft,
            MovingDown,
            MovingUp,
            Idle,
            SwingRight,
            SwingLeft,
            SwingDown,
            SwingUp
        }

        enum Direction
        {
            Right,
            Left,
            Down,
            Up
        }

        PlayerStates _playerState;
        Direction _direction;

        public Player(ContentManager CM)
            :base(CM,"PlayerSheet",new Vector(96, 96), 8, 1)
        {
            _playerState = PlayerStates.Idle;
            _direction = Direction.Down;

            //set up the origin and collision box
            _collisionBox = new Rectangle((int)_position.X + 32, (int)_position.Y + 32,32,32);
            _origin = new Vector(_collisionBox.X, _collisionBox.Y);
        }

        public override void Draw(Microsoft.Xna.Framework.GameTime gameTime, Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch)
        {
            base.Draw(gameTime, spriteBatch);
        }

        public void Update(Vector direction, InputManager IM)
        {
            if (_playerState == PlayerStates.SwingRight && _currentFrame == 2)
            { //stop the swinging
                //switch to a right animation
                SpriteEffects = Microsoft.Xna.Framework.Graphics.SpriteEffects.None;
                _viewBox = new Rectangle(0, (int)_spriteSize.Y * 2, _viewBox.Width, ViewBox.Width);
                _numOfFrames = 6;
                _playerState = PlayerStates.MovingRight;

                _direction = Direction.Right;
            }
            else if (_playerState == PlayerStates.SwingLeft && _currentFrame == 2)
            {
                SpriteEffects = Microsoft.Xna.Framework.Graphics.SpriteEffects.FlipHorizontally;
                _viewBox = new Rectangle(0, (int)_spriteSize.Y * 2, _viewBox.Width, ViewBox.Width);
                _numOfFrames = 6;
                _playerState = PlayerStates.MovingLeft;

                _direction = Direction.Left;
            }
            else if (_playerState == PlayerStates.SwingDown && _currentFrame == 2)
            {
                //switch to down animation
                SpriteEffects = Microsoft.Xna.Framework.Graphics.SpriteEffects.None;
                _viewBox = new Rectangle(0, 0, _viewBox.Width, ViewBox.Width);
                _numOfFrames = 4;
                _playerState = PlayerStates.MovingDown;

                _direction = Direction.Down;
            } 
            else if(_playerState == PlayerStates.SwingUp && _currentFrame == 2)
            {
                //switch to up animation
                SpriteEffects = Microsoft.Xna.Framework.Graphics.SpriteEffects.None;
                _viewBox = new Rectangle(0, (int)_spriteSize.Y, _viewBox.Width, ViewBox.Width);
                _numOfFrames = 4;
                _playerState = PlayerStates.MovingUp;

                _direction = Direction.Up;
            }

            if (IM.CurrentGamePadState.Buttons.A == Microsoft.Xna.Framework.Input.ButtonState.Pressed &&
                IM.PreviousGamePadState.Buttons.A == Microsoft.Xna.Framework.Input.ButtonState.Released)
            {
                //swing your mighty hammer
                if (_direction == Direction.Right)
                {
                    //swing right
                    SpriteEffects = Microsoft.Xna.Framework.Graphics.SpriteEffects.None;
                    _viewBox = new Rectangle(0, (int)_spriteSize.Y * 5, _viewBox.Width, ViewBox.Width);
                    _numOfFrames = 3;
                    _playerState = PlayerStates.SwingRight;
                }
                else if (_direction == Direction.Left)
                {
                    SpriteEffects = Microsoft.Xna.Framework.Graphics.SpriteEffects.FlipHorizontally;
                    _viewBox = new Rectangle(0, (int)_spriteSize.Y * 5, _viewBox.Width, ViewBox.Width);
                    _numOfFrames = 3;
                    _playerState = PlayerStates.SwingLeft;
                }
                else if (_direction == Direction.Down)
                {
                    SpriteEffects = Microsoft.Xna.Framework.Graphics.SpriteEffects.None;
                    _viewBox = new Rectangle(0, (int)_spriteSize.Y * 3, _viewBox.Width, ViewBox.Width);
                    _numOfFrames = 3;
                    _playerState = PlayerStates.SwingDown;
                }
                else if (_direction == Direction.Up)
                {
                    SpriteEffects = Microsoft.Xna.Framework.Graphics.SpriteEffects.None;
                    _viewBox = new Rectangle(0, (int)_spriteSize.Y * 4, _viewBox.Width, ViewBox.Width);
                    _numOfFrames = 3;
                    _playerState = PlayerStates.SwingUp;
                }
            }

            if (direction.X > 0 && direction.X > Math.Abs(direction.Y) && _playerState != PlayerStates.MovingRight)
            {
                //switch to a right animation
                SpriteEffects = Microsoft.Xna.Framework.Graphics.SpriteEffects.None;
                _viewBox = new Rectangle(0, (int)_spriteSize.Y * 2, _viewBox.Width, ViewBox.Width);
                _numOfFrames = 6;
                _playerState = PlayerStates.MovingRight;

                _direction = Direction.Right;
            }
            else if (direction.X < 0 && Math.Abs(direction.X) > Math.Abs(direction.Y) && _playerState != PlayerStates.MovingLeft)
            {
                //switch to left animation
                SpriteEffects = Microsoft.Xna.Framework.Graphics.SpriteEffects.FlipHorizontally;
                _viewBox = new Rectangle(0, (int)_spriteSize.Y * 2, _viewBox.Width, ViewBox.Width);
                _numOfFrames = 6;
                _playerState = PlayerStates.MovingLeft;

                _direction = Direction.Left;
            }
            else if (direction.Y > 0 && Math.Abs(direction.Y) > Math.Abs(direction.X) && _playerState != PlayerStates.MovingDown)
            {
                //switch to down animation
                SpriteEffects = Microsoft.Xna.Framework.Graphics.SpriteEffects.None;
                _viewBox = new Rectangle(0, 0, _viewBox.Width, ViewBox.Width);
                _numOfFrames = 4;
                _playerState = PlayerStates.MovingDown;

                _direction = Direction.Down;
            }
            else if (direction.Y < 0 && Math.Abs(direction.Y) > Math.Abs(direction.X) && _playerState != PlayerStates.MovingUp)
            {
                //switch to up animation
                SpriteEffects = Microsoft.Xna.Framework.Graphics.SpriteEffects.None;
                _viewBox = new Rectangle(0, (int)_spriteSize.Y, _viewBox.Width, ViewBox.Width);
                _numOfFrames = 4;
                _playerState = PlayerStates.MovingUp;

                _direction = Direction.Up;
            }
            else if (direction.X == 0 && direction.Y == 0 && _playerState != PlayerStates.Idle && _playerState != PlayerStates.SwingDown
                && _playerState != PlayerStates.SwingRight && _playerState != PlayerStates.SwingLeft && _playerState != PlayerStates.SwingUp)
            {
                //keep the same direction but halt animation
                _numOfFrames = 1;
                _playerState = PlayerStates.Idle;
            }

            base.Update();
        }
    }
}
