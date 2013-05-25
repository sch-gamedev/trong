using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpDX;

namespace Trong
{


    class Player
    {

        //private int paddle_position = 0;
        private int sensitivity = 4;
        private System.Windows.Forms.Keys UpKey;
        private System.Windows.Forms.Keys DownKey;
        private System.Windows.Forms.Keys ActionKey;
        private Paddle paddle;
        private string textureName;

        public Player(System.Windows.Forms.Keys ActionKey, System.Windows.Forms.Keys UpKey, System.Windows.Forms.Keys DownKey, Paddle paddle, string textureName)
        {
            this.ActionKey = ActionKey;
            this.UpKey = UpKey;
            this.DownKey = DownKey;
            this.paddle = paddle;
            this.paddle = paddle;
            this.textureName = textureName;
        }

        public void IncrementPaddlePos()
        {
            paddle.Move(sensitivity);
        }

        public void DecrementPaddlePos()
        {
            paddle.Move(-sensitivity);
        }

        public void PowerUpAction()
        {

        }

        public void ActionPerformed(SharpDX.RawInput.KeyboardInputEventArgs args)
        {
            if (args.Key == UpKey)
            {
                IncrementPaddlePos();
            }
            else if (args.Key == DownKey)
            {
                DecrementPaddlePos();
            }
            else if (args.Key == ActionKey)
            {
                PowerUpAction();
            }

        }

        public string GetTextureName
        {
            get { return textureName; }
        }
    }



}
