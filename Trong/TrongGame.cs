using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SharpDX;
using SharpDX.Toolkit;
using SharpDX.Toolkit.Graphics;

namespace Trong
{
    class TrongGame : SharpDX.Toolkit.Game
    {
        private GraphicsDeviceManager graphicsDeviceManager;
        private SpriteBatch spriteBatch;
        private Ring ring;
        private InputHandler inputHandler;
        private Player playerOne;
        private Player playerTwo;
        private Paddle paddleOne;
        private Paddle paddleTwo;
        private InputContextInGame input;
        private Disc disc;


        public TrongGame()
        {
            graphicsDeviceManager = new GraphicsDeviceManager(this);
            graphicsDeviceManager.PreferredBackBufferWidth = 1280;
            graphicsDeviceManager.PreferredBackBufferHeight = 720;

            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            Window.Title = "Trong";

            ring = new Ring(Window);
            inputHandler = new InputHandler();
            paddleOne = new Paddle(Window, "ring_separator.png",0);
            paddleTwo = new Paddle(Window, "ring_separator.png",1);
            playerOne = new Player(System.Windows.Forms.Keys.Space, System.Windows.Forms.Keys.Up, System.Windows.Forms.Keys.Down, paddleOne, "blue_disc.png");
            playerTwo = new Player(System.Windows.Forms.Keys.Shift, System.Windows.Forms.Keys.S, System.Windows.Forms.Keys.W, paddleTwo, "blue_disc.png");
            disc = new Disc(Window);
            inputHandler = new InputHandler();
            input = new InputContextInGame(playerOne, playerTwo);
            inputHandler.ChangeContext(input);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            disc.LoadContent(Content);
            ring.LoadContent(Content);
            paddleOne.LoadContent(Content);
            paddleTwo.LoadContent(Content);
            base.LoadContent();
        }

        protected override void UnloadContent()
        {
            spriteBatch.Dispose();

            base.UnloadContent();
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin(SpriteSortMode.Deferred, GraphicsDevice.BlendStates.NonPremultiplied);
            disc.Draw(spriteBatch);
            ring.Draw(spriteBatch);
            paddleOne.Draw(spriteBatch);
            paddleTwo.Draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }

        protected override void Update(GameTime gameTime)
        {
            ring.Update(gameTime);
            paddleOne.Update(gameTime);
            paddleTwo.Update(gameTime);
            disc.Update(gameTime, playerOne, playerTwo, paddleOne, paddleTwo, ring);
            base.Update(gameTime);
        }
    }
}
