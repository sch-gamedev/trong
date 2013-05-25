using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpDX;
using SharpDX.Toolkit;
using SharpDX.Toolkit.Content;
using SharpDX.Toolkit.Graphics;

namespace Trong
{
    class Disc
    {
        private const float ReferenceViewportHeight = 1080.0f;
        private const float ReferenceRadius = 48.0f;
        private Texture2D texture;
        private Texture2D textureBlue;
        private Texture2D textureOrange;
        private Vector2 pos;
        private Vector2 velocity;
        private float radius;
        private float scale;
        private Vector2 textureOrigin;
        private Vector2 origin;

        public Disc(GameWindow window)
        {
            scale = window.ClientBounds.Height / ReferenceViewportHeight;
            pos = new Vector2(window.ClientBounds.Width * 0.5f, window.ClientBounds.Height * 0.5f);
            velocity = Vector2.UnitX * 600.0f + Vector2.UnitY * 400.0f;
            radius = scale * ReferenceRadius;
            origin = new Vector2(window.ClientBounds.Width * 0.5f, window.ClientBounds.Height * 0.5f);
            pos.X += 10;
        }

        public void LoadContent(ContentManager contentManager)
        {
            textureBlue = contentManager.Load<Texture2D>("blue_disc.png");
            textureOrange = contentManager.Load<Texture2D>("orange_disc.png");
            texture = textureBlue;
            textureOrigin = new Vector2(texture.Width * 0.5f, texture.Height * 0.5f);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, pos, null, Color.White, 0.0f, textureOrigin, scale, SpriteEffects.None, 0);
        }

        public void Update(GameTime gameTime, Player playerOne, Player playerTwo,Paddle paddleOne, Paddle paddleTwo, Ring ring)
        {
            pos += velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (Vector2.Distance(origin, pos) + radius > scale * 500.0f)
            {
                velocity = Vector2.Reflect(velocity, Vector2.Normalize(origin - pos));
            }
            //erősen bugos még a visszaverődés, gyakran beakad a labda az ütőbe
            if (Vector2.Distance(origin, pos) + radius > scale * 456.0f && Vector2.Distance(origin, pos) + radius < scale * 500.0f)
            {
                if  (Math.Pow(pos.X - paddleOne.GetPosX, 2) + Math.Pow(pos.Y - paddleOne.GetPosY, 2) - Math.Pow(paddleOne.GetRadius, 2) <= 0)
                {
                 velocity = Vector2.Reflect(velocity, Vector2.Normalize(origin - pos));
                 texture = textureBlue;
                }
                else if (Math.Pow(pos.X - paddleTwo.GetPosX, 2) + Math.Pow(pos.Y - paddleTwo.GetPosY, 2) - Math.Pow(paddleTwo.GetRadius, 2) <= 0)
                {
                 velocity = Vector2.Reflect(velocity, Vector2.Normalize(origin - pos));
                 texture = textureOrange;
                }
            }
        }
    }
}
