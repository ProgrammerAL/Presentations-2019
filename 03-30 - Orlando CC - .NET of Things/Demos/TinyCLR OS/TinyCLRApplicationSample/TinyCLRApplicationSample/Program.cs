using System;
using System.Collections;
using System.Text;
using System.Threading;
using GHIElectronics.TinyCLR.Devices.Gpio;
using Utilities;
using FezPins = GHIElectronics.TinyCLR.Pins.FEZ;

namespace TinyCLRApplicationSample
{
    class Program
    {
        static void Main()
        {
            GpioPin led = GpioController.GetDefault().OpenPin(FezPins.GpioPin.D2);
            led.SetDriveMode(GpioPinDriveMode.Output);

            var sleepTimer = new SleepTimer(TimeSpan.FromMilliseconds(100));
            var ledControl = new LedControl(led, sleepTimer);

            while (true)
            {
                ledControl.Blink();
            }
        }
    }
}
