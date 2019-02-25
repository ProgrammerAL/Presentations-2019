using System;

namespace HardwareAbstractions
{
    public interface ILightSensor : IDisposable
    {
        /// <summary>
        ///     Last value read from the Light sensor.
        /// </summary>
        float Luminosity { get; }
    }
}
