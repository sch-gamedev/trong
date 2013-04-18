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
        private List<Disc> discs = new List<Disc>();

        public TrongGame ()
        {
            graphicsDeviceManager = new GraphicsDeviceManager(this);

            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            Window.Title = "Trong";

            inputHandler = new InputHandler();

            ring = new Ring(Window);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            ring.LoadContent(Content);

            foreach (var disc in discs)
                disc.LoadContent(Content);

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

            foreach (var disc in discs)
                disc.Draw(spriteBatch);
            
            spriteBatch.End();

            base.Draw(gameTime);
        }

        protected override void Update(GameTime gameTime)
        {
            ring.Update(gameTime);

            foreach (var disc in discs)
                disc.Update(gameTime);

            base.Update(gameTime);
        }
    }
}
