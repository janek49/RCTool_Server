using System.IO;

namespace RCTool_Server.Client.OutboundPackets
{
    public sealed class OutboundPacket00RequestData : OutboundPacket
    {
        public enum EnumDataType
        {
            CLIENT_LIST, SYSTEM_DATA, NETWORK_DATA
        }

        public EnumDataType DataType;

        public OutboundPacket00RequestData() : base(0)
        {
        }

        public OutboundPacket00RequestData(EnumDataType edt) : this()
        {
            this.DataType = edt;
        }

        public override void WritePacket(BinaryWriter writer)
        {
            writer.Write((short)DataType);
        }
    }
}
