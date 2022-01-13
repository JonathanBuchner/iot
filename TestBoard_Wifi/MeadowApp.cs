using Meadow;
using Meadow.Devices;
using Meadow.Foundation;
using Meadow.Foundation.Leds;
using System;
using System.Threading;
using Shared.Wifi;
using Shared.Logger;

namespace TestBoard_Wifi
{
    // Change F7MicroV2 to F7Micro for V1.x boards
    public class MeadowApp : App<F7MicroV2, MeadowApp>
    {
        RgbPwmLed onboardLed;
        private readonly ILoggerService logger;

        public MeadowApp(ILoggerService logger)
        {
            this.logger = logger;
            Initialize();
        }

        private void Initialize()
        {
            logger.Info("Initialize hardware...");

            onboardLed = new RgbPwmLed(device: Device,
                redPwmPin: Device.Pins.OnboardLedRed,
                greenPwmPin: Device.Pins.OnboardLedGreen,
                bluePwmPin: Device.Pins.OnboardLedBlue,
                3.3f, 3.3f, 3.3f,
                Meadow.Peripherals.Leds.IRgbLed.CommonType.CommonAnode);

            onboardLed.SetColor(Color.Red);

            var wifiProperties = new WifiProperties("NETGEAR03", "magicalchair057");

            var wifi = new WifiAdapter(Device.WiFiAdapter, wifiProperties);
            wifi.OnSuccessfulConnection += OnConnect;
            wifi.Connect();
        }

        private void OnConnect(object sender, EventArgs args)
        {
            onboardLed.SetColor(Color.Green);
        }
    }
}
