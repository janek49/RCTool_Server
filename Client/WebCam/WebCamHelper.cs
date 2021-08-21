using RCTool_Server.Client.OutboundPackets;
using RCTool_Server.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCTool_Server.Client.WebCam
{
    public class WebCamHelper
    {
        public RemoteWebCamClient webCamClient;
        public RemoteUserClient userClient;
        public RcServer server;

        public delegate void ConnectionStateChanged(bool isConnected);
        public event ConnectionStateChanged OnConnectionStateChangedEvent;

        public WebCamHelper(RcServer server, RemoteUserClient ruc)
        {
            userClient = ruc;
            this.server = server;
        }

        public void OpenSocket()
        {
            if (webCamClient != null && webCamClient.Connection.IsConnected)
            {
                throw new RemoteWebCamException("Already connected");
            }

            var uuid = Guid.NewGuid().ToString();
            userClient.SendPacket(new OutboundPacket01OpenSocket()
            {
                ConnectionType = 3,
                Uuid = uuid
            });

            ClientHandler.OnClientRegistered eh = null;
            eh = (rc) =>
            {
                if (rc.ClientId == uuid)
                {
                    webCamClient = (RemoteWebCamClient)rc;
                    server.InboundPacketHandler.ClientHandler.ClientRegisteredEvent -= eh;
                    OnConnectionStateChangedEvent?.Invoke(true);
                }
            };
            server.InboundPacketHandler.ClientHandler.ClientRegisteredEvent += eh;
        }

        public bool IsConnected()
        {
            return webCamClient != null && webCamClient.Connection.IsConnected;
        }

        public void CloseSocket()
        {
            if (webCamClient == null || !webCamClient.Connection.IsConnected)
            {
                throw new RemoteWebCamException("Can't close connection already closed");
            }
            webCamClient.Connection.Disconnect();
            server.InboundPacketHandler.ClientHandler.UnregisterClient(webCamClient.Connection);
            webCamClient = null;
            OnConnectionStateChangedEvent?.Invoke(false);
        }
    }
}
