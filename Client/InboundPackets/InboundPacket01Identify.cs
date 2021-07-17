using System.IO;

namespace RCTool_Server.Client.InboundPackets
{
    public sealed class InboundPacket01Identify : InboundPacket
    {
        public short ConnectionType;
        public string ClientId;
        public string Password;

        public InboundPacket01Identify() : base(1) { }

        public override void ReadPacket(BinaryReader reader)
        {
            ConnectionType = reader.ReadInt16();
            ClientId = reader.ReadString();
            Password = reader.ReadString();
        }
    }
}
