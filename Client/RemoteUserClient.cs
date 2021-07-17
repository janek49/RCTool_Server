using RCTool_Server.Client.InboundPackets;
using RCTool_Server.Client.OutboundPackets;
using RCTool_Server.Server;

namespace RCTool_Server.Client
{
    public class RemoteUserClient : RemoteClient
    {
        public class ClientFacts
        {
            public string Username;
            public string OperatingSystem;
            public string RAM;
            public string Language;
            public long Ping;
        }

        public ClientFacts LatestClientFacts;

        public RemoteUserClient(RcSession connection) : base(connection) { }

        public override void ReceivePacket(InboundPacket packet)
        {
            base.ReceivePacket(packet);

            if (packet is InboundPacket02DataResponse ip2dr && ip2dr.ReceivedClientFacts != null)
                LatestClientFacts = ip2dr.ReceivedClientFacts;
        }
         
        public override void OnClientRegistered()
        {
            SendPacket(new OutboundPacket00RequestData(OutboundPacket00RequestData.EnumDataType.CLIENT_LIST));
        }
    }
}
