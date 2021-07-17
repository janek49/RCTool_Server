using System.IO;

namespace RCTool_Server.Client.InboundPackets
{
    public sealed class InboundPacket00KeepAlive : InboundPacket
    {
        public long ClientSideTicks; 

        public InboundPacket00KeepAlive() : base(0x0)
        {
        }

        public override void ReadPacket(BinaryReader reader)
        {
            ClientSideTicks = reader.ReadInt64();
        }
    }
}
