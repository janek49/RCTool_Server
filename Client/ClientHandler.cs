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

            if (conType == RemoteClient.ClientConnectionType.USER)
            {
                RemoteUserClient ruc = new RemoteUserClient(client);
                ruc.ConnectionType = conType;
                AuthenticatedClients.TryAdd(client, ruc);
                ruc.OnClientRegistered();
                ClientRegisteredEvent?.Invoke(ruc);
            }
            else
            {
                client.Disconnect();
            }
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
            }
        }

        public void UnregisterClient(RcSession client)
        {
            AuthenticatedClients.TryRemove(client, out var rc);
            if (rc != null) ClientDisconnectedEvent?.Invoke(rc);
        }
    }
}
