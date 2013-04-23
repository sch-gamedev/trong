using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SharpDX.RawInput;

namespace Trong
{
    interface IInputContext
    {
        void OnKeyboardInput(KeyboardInputEventArgs args);
        void OnMouseInput(MouseInputEventArgs args);
    }
}
