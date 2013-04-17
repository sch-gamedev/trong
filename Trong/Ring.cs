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
    class Ring
    {
        // these values depend on the texture, so it should be stored with and loaded from the asset
        private const float ReferenceViewportHeight = 1080.0f;
        private const float ReferenceRadius = 480.0f;
        private static readonly Vector2 separatorOrigin = new Vector2(35.0f, 164.0f);

        private Texture2D separatorTexture;

        private Vector2 origin;
        private float scale;
        private readonly GameWindow window;
        private bool windowClientSizeDependentFieldsNeedUpdate;
        private float splitRatio = 0.5f;
        private float radius;

        public Ring(GameWindow window)
        {
            if (window == null)
                throw new ArgumentNullException("window");

            this.window = window;
            updateWindowClientSizeDependentFields();
            window.ClientSizeChanged += onWindowClientSizeChanged;
        }

        void onWindowClientSizeChanged(object sender, EventArgs e)
        {
            windowClientSizeDependentFieldsNeedUpdate = true;
        }

        public void LoadContent(ContentManager contentManager)
        {
            separatorTexture = contentManager.Load<Texture2D>("ring_separator.png");
        }

        private void updateWindowClientSizeDependentFields()
        {
            this.scale = window.ClientBounds.Height / ReferenceViewportHeight;
            this.origin = new Vector2(window.ClientBounds.Width * 0.5f, window.ClientBounds.Height * 0.5f);
            this.radius = ReferenceRadius * scale;

            windowClientSizeDependentFieldsNeedUpdate = false;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            var topRot = MathUtil.Pi * splitRatio;
            var bottomRot = MathUtil.Pi * (1.0f - splitRatio);

            var topPos = origin + new Vector2((float)-Math.Cos(topRot), (float)-Math.Sin(topRot)) * radius;
            var bottomPos = origin + new Vector2((float)-Math.Cos(topRot), (float)Math.Sin(topRot)) * radius;

            // draw "top" separator
            spriteBatch.Draw(separatorTexture, topPos, null, Color.White, topRot, separatorOrigin, scale, SpriteEffects.None, 0);
            // draw "bottom" separator
            spriteBatch.Draw(separatorTexture, bottomPos, null, Color.White, bottomRot, separatorOrigin, scale, SpriteEffects.FlipHorizontally, 0);
        }

        public void Update(GameTime gameTime)
        {
            if (windowClientSizeDependentFieldsNeedUpdate)
                updateWindowClientSizeDependentFields();
        }
    }
}
