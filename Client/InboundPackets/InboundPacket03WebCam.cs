using System;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCTool_Server.Client.InboundPackets
{
    public class InboundPacket03WebCam : InboundPacket
    {
        public short CommandMode;
        public Dictionary<string, string> WebCamDictionary;
        public byte[] ImageBytes;

        public InboundPacket03WebCam() : base(3)
        {
        }

        public override void ReadPacket(BinaryReader reader)
        {
            CommandMode = reader.ReadInt16();
            switch (CommandMode)
            {
                case 0:
                    {
                        WebCamDictionary = new Dictionary<string, string>();
                        int cams = reader.ReadInt32();
                        for (int i = 0; i < cams; i++)
                            WebCamDictionary.Add(reader.ReadString(), reader.ReadString());
                        break;
                    }
                case 1:
                {
                    int length = reader.ReadInt32();
                    ImageBytes = reader.ReadBytes(length);
                    break;
                }
            }
        }
    }
}
