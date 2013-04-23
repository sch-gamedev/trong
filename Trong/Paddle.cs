using SharpDX.Toolkit.Graphics;
using SharpDX.Toolkit.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpDX;
using SharpDX.Toolkit;

namespace Trong
{
    class Paddle
    {
        private const float ReferenceViewportHeight = 1080.0f;
        private const float ReferenceRadius = 480.0f;
        private Texture2D Paddletexture;
        private float splitRatio = 0.5f;
        float rotate;
        private float radius;
        private Vector2 origin;
        private float scale;
        private readonly GameWindow window;

        private Vector2 position;
        
        public Paddle(GameWindow window)
        {
            if (window == null)
                throw new ArgumentNullException("window");
            this.window = window;
            this.origin = new Vector2(window.ClientBounds.Width * 0.5f, window.ClientBounds.Height * 0.5f);
            this.rotate = MathUtil.Pi * splitRatio;

            this.position = origin + new Vector2((float)-Math.Cos(rotate), (float)-Math.Sin(rotate)) * radius;

            this.scale = window.ClientBounds.Height / ReferenceViewportHeight;
            this.radius = ReferenceRadius * scale;
        }

        public void LoadContent(ContentManager contentManager)
        {
            Paddletexture = contentManager.Load<Texture2D>("ring_separator.png");

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Paddletexture, origin, null, Color.White, -(MathUtil.PiOverTwo), new Vector2(35.0f, 164.0f), scale, SpriteEffects.None, 0);

        }

    }


}
