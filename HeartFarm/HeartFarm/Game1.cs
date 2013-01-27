#region Using Statements
using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

#endregion

namespace HeartFarm
{
	public class Game1 : Game
	{
		public static Vector ScreenSize;
		public static ContentManager g_content;
		GraphicsDeviceManager graphics;
		SpriteBatch spriteBatch;
		//Matrix SpriteScale = Matrix.Identity;
		
		Scene screenManager;
		InputManager inputManager;

		public Game1 ()
		{
			graphics = new GraphicsDeviceManager (this);
			Content.RootDirectory = "Content";
			g_content = Content;
			graphics.PreferredBackBufferHeight = 600;
			//graphics.IsFullScreen = true;
		}
		
		protected override void Initialize ()
		{
			// TODO: Add your initialization logic here
			base.Initialize ();

			graphics.PreferMultiSampling = false;

			graphics.ApplyChanges();
			//graphics.IsFullScreen = true;
			//graphics.ToggleFullScreen();
			if(graphics.IsFullScreen)
				Game1.ScreenSize = new Vector(graphics.GraphicsDevice.Viewport.Width, graphics.GraphicsDevice.Viewport.Width, 0);
			else
				Game1.ScreenSize = new Vector(graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight);

			Drawer.Init(spriteBatch.GraphicsDevice);
			Engine.SoundManager.Init(Content);
			screenManager = new Scene(Content);
			inputManager = new InputManager();

			//Level level1 = new Level();

			//screenManager.pushScreen(level1);

			//screenManager.pushScreen(level1.beetList);

			//screenManager.pushScreen(new UI(Content));

			screenManager.pushScreen(new MainMenu());

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
			EventManager.g_EM.Update();
			if (screenManager.update())
				Exit();
					
			base.Update (gameTime);
		}

		protected override void Draw (GameTime gameTime)
		{
			graphics.GraphicsDevice.Clear (Color.CornflowerBlue);
            
			//spriteBatch.Begin(SpriteSortMode.FrontToBack, null, SamplerState.LinearClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise, null, SpriteScale);
			//spriteBatch.Begin(SpriteSortMode.FrontToBack, null, SamplerState.LinearClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise, null, SpriteScale);
			spriteBatch.Begin(SpriteSortMode.Immediate, null);
			screenManager.draw(spriteBatch, gameTime);
			spriteBatch.End();

			base.Draw (gameTime);
		}
	}
}

