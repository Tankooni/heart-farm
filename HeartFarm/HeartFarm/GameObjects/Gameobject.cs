using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;

namespace HeartFarm.Gameobjects
{
    class Gameobject : BaseSprite //an object with animation and possably collision
    {
        //funcky super-awesome collision here
        protected Rectangle _collisionBox; //is by default the square that is the objected lowest tile(s)
        protected bool _isCollidable = false;

        public  bool IsCollidable
        {
            get { return _isCollidable; }
            set { _isCollidable = value; }
        }
        public Rectangle CollisionBox
        {
            get { return _collisionBox; }
        }

        //animation below
        protected byte _framesPerSec;
        protected byte _numOfFrames;
        protected Vector _spriteSize;

        protected byte _currentFrame = 0;
        protected byte _currentCount = 0;

        public Gameobject(ContentManager CM, string assetName, Vector spriteSize, byte framesPerSec, byte numOfFrames)
            :base(CM, assetName)
        {
            _framesPerSec = framesPerSec;
            _numOfFrames = numOfFrames;

            _spriteSize = spriteSize;

            _layerDepth = 1f;

            ViewBox = new Rectangle((int)(_currentFrame * _spriteSize.X), ViewBox.Y, (int)_spriteSize.X, (int)_spriteSize.Y);

            //make the box as wide as the sprite but only up to 32 pixels high at the base
            _collisionBox = new Rectangle((int)_position.X, (int)(_position.Y + spriteSize.Y), (int)spriteSize.X, spriteSize.Y > 32 ? 32 : (int)spriteSize.Y);
            _origin = new Vector(_collisionBox.X, _collisionBox.Y);
        }

        public override void Update()
        {
            //collision
            _collisionBox = new Rectangle((int)_position.X, (int)(_position.Y + _spriteSize.Y), _collisionBox.Width, _collisionBox.Height);

            //animation
            if (_currentCount >= 60 / _framesPerSec)
            {
                _currentCount = 0;

                //advance the frame
                _currentFrame++;
                if (_currentFrame >= _numOfFrames)
                    _currentFrame = 0;
                
                //alter the viewbox based on the current frame
                ViewBox = new Rectangle((int)(_currentFrame * _spriteSize.X), ViewBox.Y, (int)_spriteSize.X, (int)_spriteSize.Y);
            }
            else
            {
                //raise the count
                _currentCount++;
            }
            base.Update();
        }
        public override void Draw(Microsoft.Xna.Framework.GameTime gameTime, Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch)
        {
            base.Draw(gameTime, spriteBatch);
        }
    }
}
