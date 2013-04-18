using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trong
{
    class FunkyInputContext : IInputContext
    {
        public int NumToAdd;

        public void OnKeyboardInput(SharpDX.RawInput.KeyboardInputEventArgs args)
        {
            if (args.Key == System.Windows.Forms.Keys.Space)
                ++NumToAdd;
        }
    }
}
