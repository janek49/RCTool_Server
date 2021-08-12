using RCTool_Server.Client;
using RCTool_Server.Client.OutboundPackets;
using RCTool_Server.ViewController.ClientTab;
using RCTool_Server.Views;
using RCTool_Server.Views.Tabs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace RCTool_Server.ViewController
{
    public class TabControllerWebCam : TabControllerBase
    {
        public TabControllerWebCam(CT_WebCam tab) : base(tab)
        {
        }

        private ICommandExt _iCmdOpenConnection;

        public ICommandExt ICmdOpenConnection
        {
            get
            {
                return _iCmdOpenConnection ?? (_iCmdOpenConnection = new ICommandExt(() => OpenSocket(), () => true));
            }
        }


        private void OpenSocket()
        {
            MessageBox.Show(RemoteClient.IpAddress);
        }
    }
}
