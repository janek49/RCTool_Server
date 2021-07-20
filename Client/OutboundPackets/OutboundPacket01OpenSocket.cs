using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCTool_Server.Client.OutboundPackets
{
    public class OutboundPacket01OpenSocket : OutboundPacket
    {
        public short ConnectionType;
        public string Uuid;

        public OutboundPacket01OpenSocket() : base(1)
        {
        }

        public override void WritePacket(BinaryWriter writer)
        {
            writer.Write(ConnectionType);
            writer.Write(Uuid);
        }
    }
}
