using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SharpDX;
using SharpDX.Toolkit;
using SharpDX.Toolkit.Content;
using SharpDX.Toolkit.Graphics;

namespace Trong
{
    class Disc
    {
        private const float ReferenceRadius = 48.0f;
        private Dictionary<Team, Texture2D> textures;
        private Vector2 textureOrigin;
        private Team lastTouchTeam; // this should reference the player instead of just the team
        private Vector2 position;
        private Vector2 velocity;
        private float scale;
        private Vector2 origin;
        private float radius;

        public Disc(GameWindow window, Vector2 posOffset)
        {
            textures = new Dictionary<Team, Texture2D>(2);
            scale = window.ClientBounds.Height / 1080.0f;
            origin = new Vector2(window.ClientBounds.Width * 0.5f, window.ClientBounds.Height * 0.5f);
            position = origin + posOffset;
            velocity = Vector2.UnitX * 500.0f;
            radius = scale * ReferenceRadius;
        }

        public void LoadContent(ContentManager contentManager)
        {
            textures.Add(Team.BlueTeam, contentManager.Load<Texture2D>("blue_disc.png"));
            textures.Add(Team.OrangeTeam, contentManager.Load<Texture2D>("orange_disc.png"));

            var texture = textures[Team.BlueTeam];
            textureOrigin = new Vector2(texture.Width * 0.5f, texture.Height * 0.5f);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(textures[lastTouchTeam], position, null, Color.White, 0.0f, textureOrigin, scale, SpriteEffects.None, 0);
        }

        public void Update(GameTime gameTime)
        {
            position += velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (Vector2.Distance(origin, position) + radius > scale * 456.0f)
            {
                velocity = Vector2.Reflect(velocity, Vector2.Normalize(origin - position));
                lastTouchTeam = lastTouchTeam == Team.BlueTeam ? Team.OrangeTeam : Team.BlueTeam;
            }
        }
    }
}
