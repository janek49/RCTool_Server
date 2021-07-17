using System;
using System.IO;

namespace RCTool_Server.Client.InboundPackets
{
    public abstract class InboundPacket
    {
        public int PacketId { get; }
        public DateTime TimeReceived { get; set; }

        protected InboundPacket(int id)
        {
            this.PacketId = id;
        }

        public abstract void ReadPacket(BinaryReader reader);
    }
}
