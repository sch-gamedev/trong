using SharpDX;
using SharpDX.Toolkit.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trong
{
    class Bat
    {
        private Texture2D sprite;
        private Vector2 spriteOrigin = new Vector2(0.5f, 0.5f);

        private AngleSingle rotation;

        private Ring ring;

        private Player player;

        private Vector2 position
        {
            get { return Vector2.Zero; }
        }

        public Bat(Texture2D sprite)
        {
            if (sprite == null)
                throw new ArgumentNullException("sprite");

            this.sprite = sprite;
        }

        void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprite, position, null, Color.White, rotation.Radians, spriteOrigin, 1.0f, SpriteEffects.None, 0.0f);
        }
    }
}
