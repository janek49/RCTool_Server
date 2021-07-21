using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using RCTool_Server.Client.InboundPackets;
using RCTool_Server.Server;
using RCTool_Server.Util;

namespace RCTool_Server.Client
{
    public class InboundPacketHandler
    {
        public ClientHandler ClientHandler { get; }
        public MultiPartPacketHandler MultiPacketHandler = new MultiPartPacketHandler();

        public InboundPacketHandler(ClientHandler clientHandler)
        {
            this.ClientHandler = clientHandler;
            MultiPacketHandler.OnReceivedAllPacketPartsEvent += MultiPacketHandlerOnReceivedAllPacketPartsEvent;
        }

        private readonly Dictionary<short, Type> _inboundPacketDict = new Dictionary<short, Type>
        {
            {0x0, typeof(InboundPacket00KeepAlive)},
            {0x1, typeof(InboundPacket01Identify)},
            {0x2, typeof(InboundPacket02DataResponse)},
            {0x3, typeof(InboundPacket03WebCam)},
            {0x4, typeof(InboundPacket04ChunkTransfer)},
            {999, typeof(InboundPacket999MultiPacket)}
        };

        public void HandleRawPacket(RcSession client, byte[] bytes, DateTime whenReceived)
        {
            try
            {
                string ip = NetUtil.GetIPAddressFromSocket(client.Socket);

                using (var stream = new BinaryReader(new MemoryStream(bytes)))
                {
                    var packetId = stream.ReadInt16();

                    if (packetId == 0)
                        client.LastKeepAliveReceived = DateTime.Now.Ticks;

                    if (!_inboundPacketDict.ContainsKey(packetId))
                        throw new InvalidOperationException("Invalid packet id: " + packetId);

                    var packetType = _inboundPacketDict[packetId];

                    Logger.Log(ip, "Received packet id: " + packetId.ToString("X") + " (" + packetType.Name + "), Size: " + bytes.Length + " bytes.");

                    object obj = Activator.CreateInstance(packetType);
                    ((InboundPacket)obj).TimeReceived = whenReceived;
                    ((InboundPacket)obj).ReadPacket(stream);

                    HandleInboundPacket(client, (InboundPacket)obj);
                }
            }
            catch (Exception e)
            {
                Logger.Error("Error handling packet", e);
            }
        }

        private void HandleInboundPacket(RcSession client, InboundPacket packet)
        {
            string ip = NetUtil.GetIPAddressFromSocket(client.Socket);

            if (packet is InboundPacket01Identify identify)
            {
                //TODO implement authentication system
                if (identify.Password == "123456")
                {
                    Logger.Log($"Client {ip} authenticated. Handing over to ClientHandler.");
                    ClientHandler.RegisterClient(client, identify);
                }
                else
                {
                    Logger.Error($"Client {ip} sent wrong password. Disconnecting.");
                    client.Disconnect();
                }
            }
            else if (packet is InboundPacket999MultiPacket multi)
                MultiPacketHandler.HandlePacket(client, multi);
            else
                ClientHandler.ReceivePacket(client, packet);
        }

        private void MultiPacketHandlerOnReceivedAllPacketPartsEvent(RcSession rc, AwaitingMultiPacket awp)
        {
            byte[] bytes = awp.GlueParts();
            HandleRawPacket(rc, bytes, DateTime.Now);
        }
    }
}
