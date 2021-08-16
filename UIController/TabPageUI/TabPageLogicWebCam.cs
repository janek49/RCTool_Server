using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UIController.ClientUI;

namespace UIController.TabPageUI
{
    public class TabPageLogicWebCam : TabPageLogic
    {
        public TabPageLogicWebCam(ClientWindowLogic parent) : base(parent)
        {
        }

        private ICommandExt _iCmdOpenSocket;
        public ICommandExt ICmdOpenSocket
        {
            get { return _iCmdOpenSocket ?? (_iCmdOpenSocket = new ICommandExt(() => OpenSocket(), () => true)); }
        }


        private void OpenSocket()
        {
            MessageBox.Show(Parent.RcClient.IpAddress);
        }
    }
}
