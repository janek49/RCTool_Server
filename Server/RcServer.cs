using System.Net;
using NetFrameworkServer;
using RCTool_Server.Client;

namespace RCTool_Server.Server
{
    public sealed class RcServer : TcpServer
    {
        public InboundPacketHandler InboundPacketHandler;

        public RcServer(IPAddress address, int port) : base(address, port) { }
        public RcServer(string address, int port) : base(address, port) { }
        public RcServer(IPEndPoint endpoint) : base(endpoint) { }

        protected override TcpSession CreateSession()
        {
            return new RcSession(this);
        }
 
        protected override void OnDisconnected(TcpSession session)
        {
            base.OnDisconnected(session);
            InboundPacketHandler.ClientHandler.UnregisterClient((RcSession)session);
        }
    }

}
