using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RCTool_Server.Client.InboundPackets;
using RCTool_Server.Server;
using RCTool_Server.Util;

namespace RCTool_Server.Client
{
    public class MultiPartPacketHandler
    {
        public Dictionary<RcSession, Dictionary<string, AwaitingMultiPacket>> MultiPartPacketDictionary =
            new Dictionary<RcSession, Dictionary<string, AwaitingMultiPacket>>();

        public delegate void OnReceivedAllPacketParts(RcSession rc, AwaitingMultiPacket awp);
        public event OnReceivedAllPacketParts OnReceivedAllPacketPartsEvent;

        public void HandlePacket(RcSession client, InboundPacket999MultiPacket multi)
        {
            if (!MultiPartPacketDictionary.ContainsKey(client))
                MultiPartPacketDictionary.Add(client, new Dictionary<string, AwaitingMultiPacket>());

            if (!MultiPartPacketDictionary[client].ContainsKey(multi.PacketUuid))
                MultiPartPacketDictionary[client][multi.PacketUuid] = new AwaitingMultiPacket()
                {
                    PacketChunks = new byte[multi.ChunkAmount][],
                    ReceivedChunks = 0,
                    TotalChunks = multi.ChunkAmount,
                    UUID = multi.PacketUuid
                };

            var awaiting = MultiPartPacketDictionary[client][multi.PacketUuid];
            awaiting.PacketChunks[multi.ChunkIndex - 1] = multi.Buffer;
            awaiting.ReceivedChunks++;

            if (awaiting.ReceivedChunks == awaiting.TotalChunks)
            {
                OnReceivedAllPacketPartsEvent?.Invoke(client, awaiting);
                MultiPartPacketDictionary[client].Remove(awaiting.UUID);
            }
        }
    }

    public class AwaitingMultiPacket
    {
        public string UUID;
        public short PacketId;
        public byte[][] PacketChunks;
        public int ReceivedChunks;
        public int TotalChunks;

        public byte[] GlueParts()
        {
            List<byte> bytes = new List<byte>();
            foreach (var chunk in PacketChunks)
            {
                bytes.AddRange(chunk);
            }

            return bytes.ToArray();
        }
    }
}

