using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCTool_Server.Client.InboundPackets
{
    public class InboundPacket999MultiPacket : InboundPacket
    {
        public string PacketUuid;
        public int ChunkIndex, ChunkAmount;
        public int BufferSize;
        public byte[] Buffer;

        public InboundPacket999MultiPacket() : base(999)
        {
        }

        public override void ReadPacket(BinaryReader reader)
        {
            PacketUuid = reader.ReadString();
            ChunkIndex = reader.ReadInt32();
            ChunkAmount = reader.ReadInt32();
            BufferSize = reader.ReadInt32();
            Buffer = reader.ReadBytes(BufferSize);
        }
    }
}
