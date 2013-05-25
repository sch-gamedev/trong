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
        private Texture2D paddleTexture;
        //private float splitRatio = 0.5f;
        private float rotate;
        private float radius;
        private Vector2 origin;
        private float scale;
        private Vector2 textureOrigin;
        private Vector2 position;
        private string textureName;
        //private float paddleRadius;
        private Vector2 uCorner;
        private Vector2 bCorner;

        public Paddle(GameWindow window, string textureName, int paddle_position)
        {
            this.textureName=textureName;
            scale = window.ClientBounds.Height / ReferenceViewportHeight;
            //paddleRadius = 328.0f * scale;
            origin = new Vector2(window.ClientBounds.Width * 0.5f, window.ClientBounds.Height * 0.5f);
            radius = ReferenceRadius * scale;
            rotate = MathUtil.Pi * paddle_position;
            position = (new Vector2 ( (float) - Math.Cos(rotate), (float)-Math.Sin(rotate) )) * radius + origin;
            bCorner = new Vector2(300, window.ClientBounds.Height/2);
        }

        public void LoadContent(ContentManager contentManager)
        {
            paddleTexture = contentManager.Load<Texture2D>(textureName);
            textureOrigin = new Vector2 (paddleTexture.Width * 0.5f, paddleTexture.Height * 0.5f);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(paddleTexture, position, null, Color.White, rotate, textureOrigin, scale, SpriteEffects.None, 0);
        }

        public void Update(GameTime gameTime)
        {
            position = (new Vector2((float)-Math.Cos(rotate), (float)-Math.Sin(rotate))) * radius + origin;
        }

        public void Move(int pos)
        {
            rotate += MathUtil.DegreesToRadians(pos);
        }

        public float GetRadius
        {
            get { return paddleTexture.Height/2*scale; }
        }

        public float GetPosX
        {
            get { return position.X; }
        }

        public float GetPosY
        {
            get { return position.Y; }
        }
    }

}
