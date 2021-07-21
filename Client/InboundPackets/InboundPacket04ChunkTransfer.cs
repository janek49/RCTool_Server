using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCTool_Server.Client.InboundPackets
{
    public class InboundPacket04ChunkTransfer : InboundPacket
    {
        public int CurrentPart;
        public int PartAmount;
        public int BufferSize;
        public byte[] Buffer;

        public InboundPacket04ChunkTransfer() : base(4)
        {
        }

        public override void ReadPacket(BinaryReader reader)
        {
            CurrentPart = reader.ReadInt32();
            PartAmount = reader.ReadInt32();
            BufferSize = reader.ReadInt32();
            Buffer = reader.ReadBytes(BufferSize);
        }
    }
}
