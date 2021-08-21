using RCTool_Server.Client.WebCam;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Threading;
using UIController.ClientUI;

namespace UIController.TabPageUI
{
    public class TabPageLogicWebCam : TabPageLogic
    {
        public WebCamHelper webCamHelper;

        public TabPageLogicWebCam(ClientWindowLogic parent) : base(parent)
        {
            webCamHelper = new WebCamHelper(parent.RcServer, parent.RcUClient);
            webCamHelper.OnConnectionStateChangedEvent += WebCamHelper_OnConnectionStateChangedEvent;
        }

        private void WebCamHelper_OnConnectionStateChangedEvent(bool isConnected)
        {
            ICmdOpenSocket.NotifyStateChange(Parent.wpfWindow);
            ICmdCloseSocket.NotifyStateChange(Parent.wpfWindow);
        }

        private ICommandExt _iCmdOpenSocket;
        public ICommandExt ICmdOpenSocket
        {
            get { return _iCmdOpenSocket ?? (_iCmdOpenSocket = new ICommandExt(() => webCamHelper.OpenSocket(), () => !webCamHelper.IsConnected())); }
        }

        private ICommandExt _iCmdCloseSocket;
        public ICommandExt ICmdCloseSocket
        {
            get { return _iCmdCloseSocket ?? (_iCmdCloseSocket = new ICommandExt(() => webCamHelper.CloseSocket(), () => webCamHelper.IsConnected())); }
        }
    }
}
