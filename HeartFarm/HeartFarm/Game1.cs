#region Using Statements
using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Input;

#endregion

namespace HeartFarm
{
	/// <summary>
	/// This is the main type for your game
	/// </summary>
	public class Game1 : Game
	{
		GraphicsDeviceManager graphics;
		SpriteBatch spriteBatch;
		//Matrix SpriteScale = Matrix.Identity;
		
		ScreenManager screenManager;
		InputManager inputManager;

		public Game1 ()
		{
			graphics = new GraphicsDeviceManager (this);
			Content.RootDirectory = "Content";
			//graphics.IsFullScreen = true;
		}

		/// <summary>
		/// Allows the game to perform any initialization it needs to before starting to run.
		/// This is where it can query for any required services and load any non-graphic
		/// related content.  Calling base.Initialize will enumerate through any components
		/// and initialize them as well.
		/// </summary>
		protected override void Initialize ()
		{
			// TODO: Add your initialization logic here
			base.Initialize ();

//			graphics.IsFullScreen = true; //make it full screen!!
//			
//			graphics.PreferredBackBufferWidth = graphics.GraphicsDevice.DisplayMode.Width;
//			graphics.PreferredBackBufferHeight = graphics.GraphicsDevice.DisplayMode.Height;

			graphics.PreferMultiSampling = false;
			graphics.ApplyChanges();

			Drawer.Init(spriteBatch.GraphicsDevice);
			Engine.SoundManager.Init(Content);
			screenManager = new ScreenManager(Content, graphics.GraphicsDevice.DisplayMode.AspectRatio);
			inputManager = new InputManager();
		}

		/// <summary>
		/// LoadContent will be called once per game and is the place to load
		/// all of your content.
		/// </summary>
		protected override void LoadContent ()
		{
			// Create a new SpriteBatch, which can be used to draw textures.
			spriteBatch = new SpriteBatch (GraphicsDevice);
		}

		bool isMusicLoaded = false;
		protected override void Update (GameTime gameTime)
		{
			// For Mobile devices, this logic will close the Game when the Back button is pressed
			if (GamePad.GetState (PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
			{
				Exit ();
			}

			Engine.SoundManager.gameTime = gameTime;

			if (!isMusicLoaded)
			{
				//SoundManager.PlaySetList(new Musics[]{Musics.Chanter, Musics.Decisions});
				isMusicLoaded = true;
			}
			//updates...
			inputManager.update();
//			if (!screenManager.update(inputManager))
//				Exit();
					
			base.Update (gameTime);
		}

		protected override void Draw (GameTime gameTime)
		{
			graphics.GraphicsDevice.Clear (Color.CornflowerBlue);
            
			//spriteBatch.Begin(SpriteSortMode.FrontToBack, null, SamplerState.LinearClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise, null, SpriteScale);
			//spriteBatch.Begin(SpriteSortMode.FrontToBack, null, SamplerState.LinearClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise, null, SpriteScale);
			spriteBatch.Begin(SpriteSortMode.FrontToBack, null);
			screenManager.draw(spriteBatch, gameTime);
			spriteBatch.End();

			base.Draw (gameTime);
		}
	}
}

