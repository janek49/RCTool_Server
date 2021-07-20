using System.Collections.Concurrent;
using RCTool_Server.Client.InboundPackets;
using RCTool_Server.Server;
using RCTool_Server.Util;

namespace RCTool_Server.Client
{
    public class ClientHandler
    {
        public ConcurrentDictionary<RcSession, RemoteClient> AuthenticatedClients;

        public RcServer HandlingServer;

        public delegate void OnClientRegistered(RemoteClient rc);
        public event OnClientRegistered ClientRegisteredEvent;

        public delegate void OnClientDisconnected(RemoteClient rc);
        public event OnClientDisconnected ClientDisconnectedEvent;

        public delegate void OnClientPacketReceived(RemoteClient rc, InboundPacket ipacket);
        public event OnClientPacketReceived ClientPacketReceivedEvent;

        public ClientHandler(RcServer server)
        {
            HandlingServer = server;
            AuthenticatedClients = new ConcurrentDictionary<RcSession, RemoteClient>();
        }

        public void RegisterClient(RcSession client, InboundPacket01Identify packet)
        {
            var conType = (RemoteClient.ClientConnectionType)packet.ConnectionType;
            RemoteClient remoteClient;

            if (conType == RemoteClient.ClientConnectionType.USER)
            {
                remoteClient = new RemoteUserClient(client);
            }
            else if (conType == RemoteClient.ClientConnectionType.AUX_WEBCAM)
            {
                remoteClient = new RemoteWebCamClient(client);
            }
            else
            {
                client.Disconnect();
                UnregisterClient(client);
                return;
            }

            remoteClient.ConnectionType = conType;
            AuthenticatedClients.TryAdd(client, remoteClient);
            remoteClient.OnClientRegistered();
            ClientRegisteredEvent?.Invoke(remoteClient);
        }

        public void ReceivePacket(RcSession client, InboundPacket packet)
        {
            if (AuthenticatedClients.ContainsKey(client))
            {
                var rc = AuthenticatedClients[client];
                rc.ReceivePacket(packet);
                ClientPacketReceivedEvent?.Invoke(rc, packet);
            }
            else
            {
                Logger.Error($"Received packet {packet.PacketId} ({packet.GetType().Name}) from unauthenticated client {NetUtil.GetIPAddressFromSocket(client.Socket)} Disconnecting.");
                client.Disconnect();
                UnregisterClient(client);
            }
        }

        public void UnregisterClient(RcSession client)
        {
            AuthenticatedClients.TryRemove(client, out var rc);
            if (rc != null) ClientDisconnectedEvent?.Invoke(rc);
        }
    }
}
