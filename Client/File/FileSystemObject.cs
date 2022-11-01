using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCTool_Server.Client.File
{
    public class FileSystemObject
    {
        public enum Type
        {
            DIR, FILE, ERROR, PARENT
        }

        public Type EntryType { get; set; }
        public string FilePath { get; set; }
        public ulong FileSize { get; set; }
        public long LastModified { get; set; }

        //for wpf
        public string Icon
        {
            get
            {
                if (EntryType == FileSystemObject.Type.DIR)
                    return "Images/folder.png";
                else if (EntryType == FileSystemObject.Type.FILE)
                    return "Images/file.png";
                else if (EntryType == FileSystemObject.Type.PARENT)
                    return "Images/arrow-up.png";
                else
                    return "Images/forbidden.png";
            }
        }

        public string LastModifiedDateStr
        {
            get
            {
                return new DateTime(LastModified).ToString("yyyy-MM-dd HH:mm:ss");
            }
        }

        public override string ToString()
        {
            return FilePath;
        }
    }
}
