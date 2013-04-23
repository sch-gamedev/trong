using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trong
{
    class InputContextInGame : IInputContext
    {
        Player Player1;
        Player Player2;

        public InputContextInGame(Player Player1c, Player Player2c)
        {
            Player1 = Player1c;
            Player2 = Player2c;

        }

        public void OnKeyboardInput(SharpDX.RawInput.KeyboardInputEventArgs args)
        {
            Player1.ActionPerformed(args);
            Player2.ActionPerformed(args);
        }

        public void OnMouseInput(SharpDX.RawInput.MouseInputEventArgs args)
        {

        }
    }
}
