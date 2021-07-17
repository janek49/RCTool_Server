using System.IO;

namespace RCTool_Server.Client.OutboundPackets
{
    public abstract class OutboundPacket
    {
        public short PacketId { get; }

        protected OutboundPacket(short id)
        {
            this.PacketId = id;
        }

        public abstract void WritePacket(BinaryWriter writer);
    }
}
