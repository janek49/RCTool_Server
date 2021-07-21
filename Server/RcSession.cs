using System;
using System.Threading;
using NetFrameworkServer;
using RCTool_Server.Util;

namespace RCTool_Server.Server
{
    public sealed class RcSession : TcpSession
    {
        public long LastKeepAliveReceived;

        private readonly RcServer _RcServer;

        public RcSession(RcServer server) : base(server)
        {
            _RcServer = server;
        }

        protected override void OnReceived(byte[] buffer, long offset, long size)
        {
            new Thread(() => _RcServer.InboundPacketHandler.HandleRawPacket(this, buffer.ExtCopyRange(offset, size), DateTime.Now)).Start();
        }

        public override long Receive(byte[] buffer, long offset, long size)
        {
            return base.Receive(buffer, offset, size);
        }
    }
}
