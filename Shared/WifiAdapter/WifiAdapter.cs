using Meadow.Gateway.WiFi;
using Meadow.Gateways;
using System;
using System.Threading.Tasks;

namespace Shared.Wifi
{
    public class WifiAdapter
    { 
        public IWiFiAdapter adapter { get; }
        private WifiProperties properties;

        public WifiAdapter(IWiFiAdapter wifiAdapter, WifiProperties wifiSecrets)
        {
            this.adapter = wifiAdapter;
            this.properties = wifiSecrets;
            adapter.WiFiConnected += OnConnect;
        }

        public async Task Connect()
        {
            Console.WriteLine($"Connecting to {properties.WIFI_NAME}");

            var result = await adapter.Connect(properties.WIFI_NAME, properties.WIFI_PASSWORD);

            if (result.ConnectionStatus != ConnectionStatus.Success)
            {
                Console.WriteLine($"Cannot connect to Network.  Error: {result.ConnectionStatus}");
            }
        }

        public event EventHandler OnSuccessfulConnection;

        protected virtual void OnConnect(object sender, EventArgs args)
        {
            Console.WriteLine("Connection Successful");

            if (OnSuccessfulConnection != null)
            {
                OnSuccessfulConnection(this, args);
            }
        }

        public void LogAccessPoints()
        {
            Console.WriteLine("Scanning for Access Points");
            var networks = adapter.Scan();

            if (networks.Count > 0)
            {
                Console.WriteLine("|-------------------------------------------------------------|---------|");
                Console.WriteLine("|         Network Name             | RSSI |       BSSID       | Channel |");
                Console.WriteLine("|-------------------------------------------------------------|---------|");
                foreach (WifiNetwork accessPoint in networks)
                {
                    Console.WriteLine($"| {accessPoint.Ssid,-32} | {accessPoint.SignalDbStrength,4} | {accessPoint.Bssid,17} |   {accessPoint.ChannelCenterFrequency,3}   |");
                }
            }
            else
            {
                Console.WriteLine($"No access points detected.");
            }
        }
    }
}