using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RCTool_Server.Client.InboundPackets;

namespace RCTool_Server.Client
{
    public class IncomingPacketCallback
    {
        public RemoteClient RemoteClient;
        public Func<InboundPacket, bool> Callback;

        public IncomingPacketCallback(RemoteClient remoteClient)
        {
            RemoteClient = remoteClient;
        }

        public void ListenForAnswer(Func<InboundPacket, bool> action)
        {
            Callback = action;
            RemoteClient.OnPacketReceivedEvent += RemoteClient_OnPacketReceivedEvent;
        }

        private void RemoteClient_OnPacketReceivedEvent(InboundPacket packet)
        {
            if (Callback?.Invoke(packet) ?? true)
            {
                RemoteClient.OnPacketReceivedEvent -= RemoteClient_OnPacketReceivedEvent;
            }
        }
    }
}
