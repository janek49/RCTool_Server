using System.IO;
using RCTool_Server.Client.InboundPackets;
using RCTool_Server.Client.OutboundPackets;
using RCTool_Server.Server;
using RCTool_Server.Util;

namespace RCTool_Server.Client
{
    public class RemoteClient
    {
        public enum ClientConnectionType : short
        {
            USER, AUX_FILE, AUX_RDP, AUX_WEBCAM
        }

        public ClientConnectionType ConnectionType;
        public RcSession Connection { get; }
        public string IpAddress;

        public delegate void OnPacketReceived(InboundPacket packet);
        public event OnPacketReceived OnPacketReceivedEvent;

        public RemoteClient(RcSession connection)
        {
            Connection = connection;
            IpAddress = NetUtil.GetIPAddressFromSocket(connection.Socket);
        }

        public IncomingPacketCallback SendPacket(OutboundPacket packet)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                using (BinaryWriter bw = new BinaryWriter(ms))
                {
                    bw.Write(packet.PacketId);
                    packet.WritePacket(bw);
                }

                Connection.SendAsync(ms.ToArray());
                Logger.Log(IpAddress, "Sent packet id: " + packet.PacketId + $" ({packet.GetType().Name})");
            }

            return new IncomingPacketCallback(this);
        }

        public virtual void ReceivePacket(InboundPacket packet)
        {
            OnPacketReceivedEvent?.Invoke(packet);
        }

        public virtual void OnClientRegistered()
        {

        }
    }
}
