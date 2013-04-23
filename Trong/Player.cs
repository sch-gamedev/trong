using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trong
{


    class Player
    {

        private int paddle_position = 90;

        private System.Windows.Forms.Keys UpKey;
        private System.Windows.Forms.Keys DownKey;
        private System.Windows.Forms.Keys ActionKey;
        private Paddle paddle;

        public Player(System.Windows.Forms.Keys ActionKey0, System.Windows.Forms.Keys UpKey0, System.Windows.Forms.Keys DownKey0, Paddle paddle0)
        {
            ActionKey = ActionKey0;
            UpKey = UpKey0;
            DownKey = DownKey0;
            paddle = paddle0;

        }
        public void IncrementPaddlePos()
        {
            paddle_position++;
        }
        public void DecrementPaddlePos()
        {
            paddle_position--;
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

    }



}
