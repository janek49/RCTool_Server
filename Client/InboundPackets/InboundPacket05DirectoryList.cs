using RCTool_Server.Client.File;
using RCTool_Server.Client.OutboundPackets;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCTool_Server.Client.InboundPackets
{
    public class InboundPacket05DirectoryList : InboundPacket
    {
        public string DirectoryPath { get; set; }
        public List<FileSystemObject> Entries { get; set; }

        public InboundPacket05DirectoryList() : base(5)
        {
        }

        public override void ReadPacket(BinaryReader reader)
        {
            Entries = new List<FileSystemObject>();

            DirectoryPath = reader.ReadString();

            //amount of entries in dir
            uint children = reader.ReadUInt32();

            for (uint i = 0; i < children; i++)
            {
                byte entryType = reader.ReadByte();
                string name = reader.ReadString();
                ulong size = reader.ReadUInt64();
                long modified = reader.ReadInt64();

                FileSystemObject fso = new FileSystemObject()
                {
                    EntryType = (FileSystemObject.Type)entryType,
                    FilePath = name,
                    FileSize = size,
                    LastModified = modified
                };

                Entries.Add(fso);
            }
        }
    }
}
