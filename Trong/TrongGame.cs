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
        private Texture2D testTexture;
        private Texture2D mapTexture;
        private Vector2 position = Vector2.Zero;
        private Vector2 velocity = Vector2.UnitX * 1000;
        private DrawingRectangle dRect;

        public TrongGame ()
        {
            graphicsDeviceManager = new GraphicsDeviceManager(this);

            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            Window.Title = "Trong";
            base.Initialize();
        }

        protected override void LoadContent()
        {
            testTexture = Content.Load<Texture2D>("disc.png");
            mapTexture = Content.Load<Texture2D>("map.png");
            dRect = new DrawingRectangle(200, 100, 300, 300);

            spriteBatch = new SpriteBatch(GraphicsDevice);
            base.LoadContent();
        }

        protected override void UnloadContent()
        {
            spriteBatch.Dispose();

            base.UnloadContent();
        }
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            spriteBatch.Draw(mapTexture, dRect, Color.White);
            spriteBatch.Draw(testTexture, position, Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }

        protected override void Update(GameTime gameTime)
        {
            if (position.X + 32 > Window.ClientBounds.Width
                || position.X < 0)
                velocity = new Vector2(-velocity.X, velocity.Y);

            position += velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;

            base.Update(gameTime);
        }
    }
}
