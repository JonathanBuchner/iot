using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Wifi
{ 
    public class WifiProperties
    {
        public string WIFI_NAME { get; }
        public string WIFI_PASSWORD { get; }

        public TimeSpan WIFI_TIMOUT { get; set; } = new TimeSpan(0, 2, 0);

        public WifiProperties(string wifiName, string wifiPassword)
        {
            WIFI_NAME = wifiName;
            WIFI_PASSWORD = wifiPassword;
        }
    }
}
