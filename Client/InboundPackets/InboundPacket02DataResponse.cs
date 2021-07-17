using System.IO;
using RCTool_Server.Client.OutboundPackets;

namespace RCTool_Server.Client.InboundPackets
{
    public sealed class InboundPacket02DataResponse : InboundPacket
    {
        public InboundPacket02DataResponse() : base(2)
        {
        }

        public OutboundPacket00RequestData.EnumDataType DataType;

        public RemoteUserClient.ClientFacts ReceivedClientFacts;

        public override void ReadPacket(BinaryReader reader)
        {
            short type = reader.ReadInt16();
            DataType = (OutboundPacket00RequestData.EnumDataType)type;

            switch (DataType)
            {
                case OutboundPacket00RequestData.EnumDataType.CLIENT_LIST:
                    ReceivedClientFacts = new RemoteUserClient.ClientFacts
                    {
                        Username = reader.ReadString(),
                        OperatingSystem = reader.ReadString(),
                        RAM = reader.ReadString(),
                        Language = reader.ReadString(),
                        Ping = ((TimeReceived.Ticks - reader.ReadInt64()) / 10000)
                    };
                    break;
            }
        }
    }
}
