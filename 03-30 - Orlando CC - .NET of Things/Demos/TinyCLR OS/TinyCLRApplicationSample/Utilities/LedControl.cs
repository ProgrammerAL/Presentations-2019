using System;
using System.Collections;
using System.Text;
using System.Threading;
using GHIElectronics.TinyCLR.Devices.Gpio;

namespace Utilities
{
    public class LedControl
    {
        private readonly GpioPin _ledPin;
        private readonly int _onTimeMilliseconds;
        private readonly int _offTimeMilliseconds;
        private readonly ISleepTimer _blinkTimer;

        public LedControl(GpioPin ledPin, ISleepTimer blinkTimer)
        {
            _ledPin = ledPin;
            _blinkTimer = blinkTimer;
        }

        public void Blink()
        {
            _ledPin.Write(GpioPinValue.High);
            _blinkTimer.Run();
            _ledPin.Write(GpioPinValue.Low);
            _blinkTimer.Run();
        }
    }
}
