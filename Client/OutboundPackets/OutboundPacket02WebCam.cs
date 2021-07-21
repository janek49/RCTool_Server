using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RCTool_Server.Client.WebCam;

namespace RCTool_Server.Client.OutboundPackets
{
    public class OutboundPacket02WebCam : OutboundPacket
    {
        public WebCamAction Action;
        public string CamId;
        public OutboundPacket02WebCam() : base(2)
        {
        }

        public override void WritePacket(BinaryWriter writer)
        {
            writer.Write((short)Action);
            writer.Write(CamId);
        }
    }
}
