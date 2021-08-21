using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCTool_Server.Client.WebCam
{
    public class RemoteWebCamException : Exception
    {
        public RemoteWebCamException(string msg) : base(msg) { }
    }
}
