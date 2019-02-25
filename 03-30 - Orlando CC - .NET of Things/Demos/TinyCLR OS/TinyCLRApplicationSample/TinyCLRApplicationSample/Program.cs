using System;
using System.Threading;
using GHIElectronics.TinyCLR.Devices.Gpio;
using GHIElectronics.TinyCLR.Devices.I2c;
using GHIElectronics.TinyCLR.Devices.I2c.Provider;
using HardwareDrivers;
using HardwareDrivers.LightSensor.APDS9301;
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

            SleepTimer sleepTimer = new SleepTimer(TimeSpan.FromMilliseconds(100));
            LedControl ledControl = new LedControl(led, sleepTimer);

            //while (true)
            //{
            //    ledControl.Blink();
            //}

            int sdaPin = FezPins.GpioPin.A0;
            int slcPin = FezPins.GpioPin.A1;
            int ledDeviceAddress = 0x39;
            I2cConnectionSettings ledDeviceConnectionSettings = new I2cConnectionSettings(ledDeviceAddress, I2cAddressFormat.SevenBit, I2cBusSpeed.StandardMode);

            I2cControllerSoftwareProvider i2cProvider = new I2cControllerSoftwareProvider(sdaPin, slcPin, false);
            I2cController i2cController = I2cController.FromProvider(i2cProvider);
            I2cDevice lightSensorDevice = i2cController.GetDevice(ledDeviceConnectionSettings);

            var lightSensor = new APDS9301_LightSensor(lightSensorDevice, APDS9301_LightSensor.MinimumPollingPeriod);

            float lastLuminosity = float.MinValue;
            while (true)
            {
                float currentLuminosity = lightSensor.Luminosity;
                if (lastLuminosity != lightSensor.Luminosity)
                {
                    System.Diagnostics.Debug.WriteLine(currentLuminosity.ToString());
                    lastLuminosity = currentLuminosity;
                }
                Thread.Sleep(100);
            }
        }
    }
}
