using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using RCTool_Server.Client.InboundPackets;

namespace RCTool_Server.Client
{
    public class SentPacketCallback
    {
        public RemoteClient RemoteClient;
        public Func<InboundPacket, bool> Callback;

        public SentPacketCallback(RemoteClient remoteClient)
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
                RemoteClient.OnPacketReceivedEvent -= RemoteClient_OnPacketReceivedEvent;
        }

        
    }
}
