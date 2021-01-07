using System;
using System.Device.Gpio;

namespace OrchardCore.Themes.RaspberryPiTheme.Devices
{
    public class LedDevice : IDisposable
    {
        private const int LedPin = 17;

        private GpioController _controller;
        private bool disposedValue = false;
        private object _locker = new object();
        private bool ledSupported = true;
        public LedDevice()
        {
            try
            {
                _controller = new GpioController();
                _controller.OpenPin(LedPin, PinMode.Output);
                _controller.Write(LedPin, PinValue.Low);
                IsLedOn = false;
            }
            catch (Exception ex)
            {
                ledSupported = false;
                Console.WriteLine(ex.Message);
            }
            finally
            {
                IsLedSupported = ledSupported;
            }
        }

        public bool IsLedSupported { get; private set; }
        public bool IsLedOn { get; private set; }

        public void LedOn()
        {
            lock (_locker)
            {
                if (ledSupported) _controller.Write(LedPin, PinValue.High);

                IsLedOn = true;
            }
        }

        public void LedOff()
        {
            lock (_locker)
            {
                if (ledSupported) _controller.Write(LedPin, PinValue.Low);

                IsLedOn = false;
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    if (ledSupported) _controller.Dispose();
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
    }
}
