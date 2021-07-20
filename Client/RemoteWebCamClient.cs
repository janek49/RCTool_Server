using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RCTool_Server.Server;

namespace RCTool_Server.Client
{
    public class RemoteWebCamClient:RemoteClient
    {
        public RemoteWebCamClient(RcSession connection) : base(connection)
        {
        }
    }
}
