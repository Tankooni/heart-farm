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
	public class Game1 : Game, Listener
	{
		public static Vector ScreenSize;
		public static ContentManager g_content;
		GraphicsDeviceManager graphics;
		SpriteBatch spriteBatch;
		public static GameTime g_gameTime;
		public static Random rand = new Random();
		//Matrix SpriteScale = Matrix.Identity;
		
		Scene currentScene;
		public static InputManager g_inputManager;

		public Game1 ()
		{
			graphics = new GraphicsDeviceManager (this);
			Content.RootDirectory = "Content";
			g_content = Content;
			//graphics.IsFullScreen = true;
			graphics.PreferredBackBufferHeight = 600;
		}
		
		protected override void Initialize ()
		{
			// TODO: Add your initialization logic here
			base.Initialize ();

			graphics.PreferMultiSampling = false;
			graphics.ApplyChanges();
			Game1.ScreenSize = new Vector(graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight);

			Drawer.Init(spriteBatch.GraphicsDevice);
			SoundManager.Init(Content);
			g_inputManager = new InputManager();

			EventManager.g_EM.AddListener(new ChangeScene(), this);

			//start our game on the title scene
			currentScene = new SceneTitle();
			SoundManager.PlayLoop(Musics.One);
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
			Game1.g_gameTime = gameTime;
			//Engine.SoundManager.gameTime = gameTime;

			if (!isMusicLoaded)
			{
				//SoundManager.PlaySetList(new Musics[]{Musics.Chanter, Musics.Decisions});
				isMusicLoaded = true;
			}
			//updates...
			g_inputManager.update();
			EventManager.g_EM.Update();
			currentScene.update();
//			if (!screenManager.update(inputManager))
//				Exit();
					
			base.Update (gameTime);
		}

		protected override void Draw (GameTime gameTime)
		{
			graphics.GraphicsDevice.Clear (Color.DarkViolet);
            
			//spriteBatch.Begin(SpriteSortMode.FrontToBack, null, SamplerState.LinearClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise, null, SpriteScale);
			//spriteBatch.Begin(SpriteSortMode.FrontToBack, null, SamplerState.LinearClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise, null, SpriteScale);
			spriteBatch.Begin(SpriteSortMode.Immediate, null);
			currentScene.draw(spriteBatch, gameTime);
			spriteBatch.End();

			base.Draw (gameTime);
		}

		public void OnEvent (Event e)
		{
			if (e is ChangeScene) {
				ChangeScene cs = (ChangeScene) e;

				//clean up a bit...(this should be done better but oh well
				EventManager.g_EM.ClearListeners();
				EventManager.g_EM.AddListener(new ChangeScene(), this);

				g_inputManager.clearActiveButtons();
				//Type t = ;
				//change to the given screen
				currentScene = (Scene)(Activator.CreateInstance(cs.scene.GetType()));
					//new cs.scene.GetType();

				cs.isDoneProcessing = true;
			}
		}
	}
}

