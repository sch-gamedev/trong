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
        private Player playerone;
        private Player playertwo;
        private Paddle paddleone;
        private Paddle paddletwo;
        private InputContextInGame input;


        public TrongGame()
        {
            graphicsDeviceManager = new GraphicsDeviceManager(this);

            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            Window.Title = "Trong";

            ring = new Ring(Window);

            inputHandler = new InputHandler();
            paddleone = new Paddle(Window);
            paddletwo = new Paddle(Window);
            playerone = new Player(System.Windows.Forms.Keys.Space, System.Windows.Forms.Keys.Up, System.Windows.Forms.Keys.Down, paddleone);
            playertwo = new Player(System.Windows.Forms.Keys.Shift, System.Windows.Forms.Keys.W, System.Windows.Forms.Keys.S, paddletwo);
            input = new InputContextInGame(playerone, playertwo);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            ring.LoadContent(Content);
            paddleone.LoadContent(Content);
            paddletwo.LoadContent(Content);
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

            ring.Draw(spriteBatch);
            paddleone.Draw(spriteBatch);
            paddletwo.Draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }

        protected override void Update(GameTime gameTime)
        {
            ring.Update(gameTime);

            base.Update(gameTime);
        }
    }
}
