using System;
using System.Net.WebSockets;
using Websocket.Client;

namespace Shared.WeSocketClient
{
    public class WebsocketConnection
    {
        private WebsocketClient client;

        public WebsocketConnection()
        {

        }

        private void Init()
        {
            client = new WebsocketClient();
        }

        public ClientWebSocket GetClient()
        {
            var client = new ClientWebSocket
            {
                Options =
                    {
                        KeepAliveInterval = TimeSpan.FromSeconds(5),
                    }
            };
            
            return client;
        }

        private Func<ClientWebSocket> WebclientFactory(ClientWebSocketOptions options)
        {
            var client = new ClientWebSocket()
            {
                Options =
                {

                }
            };

            return new Func<ClientWebSocket>(() =>
            {
                return client;
            });
        }
    }
}