using RCTool_Server.Client;
using RCTool_Server.Views.Tabs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCTool_Server.ViewController.ClientTab
{
    public class TabControllerBase
    {
        public ClientTabUC ClientTabView;
        public RemoteClient RemoteClient;

        public TabControllerBase(ClientTabUC cuc)
        {
            this.ClientTabView = cuc;
            RemoteClient = ClientTabView.masterWindow.windowManager.FindClientForWindow(ClientTabView.masterWindow);
        }
    }
}
