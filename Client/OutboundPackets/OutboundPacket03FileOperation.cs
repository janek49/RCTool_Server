using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCTool_Server.Client.OutboundPackets
{
    public sealed class OutboundPacket03FileOperation : OutboundPacket
    {
        public enum EnumOperation
        {
            LIST_DIR_CONTENT
        }

        public EnumOperation Operation { get; }

        public string FileSystemPath { get; }

        public OutboundPacket03FileOperation(EnumOperation op, string fileSystemPath) : base(3)
        {
            this.Operation = op;
            this.FileSystemPath = fileSystemPath;
        }

        public override void WritePacket(BinaryWriter writer)
        {
            writer.Write((short)this.Operation);
            writer.Write(this.FileSystemPath);
        }
    }
}
