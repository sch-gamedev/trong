using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SharpDX.Multimedia;
using SharpDX.RawInput;

namespace Trong
{
    class InputHandler
    {
        private IInputContext activeContext;

        public IInputContext ActiveContext
        {
            get { return activeContext; }
        }

        public InputHandler(IInputContext inputContext = null)
        {
            activeContext = inputContext;

            Device.RegisterDevice(UsagePage.Generic, UsageId.GenericKeyboard, DeviceFlags.None);
            Device.RegisterDevice(UsagePage.Generic, UsageId.GenericMouse, DeviceFlags.None);

            Device.KeyboardInput += onKeyboardInput;
            Device.MouseInput += OnMouseInput;
        }

        private void OnMouseInput(object sender, MouseInputEventArgs e)
        {
            if (activeContext != null)
                activeContext.OnMouseInput(e);
        }

       
        private void onKeyboardInput(object sender, KeyboardInputEventArgs e)
        {
            if (activeContext != null)
                activeContext.OnKeyboardInput(e);
        }

        public void ChangeContext(IInputContext to)
        {
            activeContext = to;
        }



    }
}
