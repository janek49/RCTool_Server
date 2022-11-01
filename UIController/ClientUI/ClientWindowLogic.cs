using RCTool_Server.Client;
using RCTool_Server.Server;
using ServerUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using UIController.TabPageUI;

namespace UIController.ClientUI
{
    public class ClientWindowLogic
    {
        public WpfWindowClientManager wpfWindow;
        public Dictionary<Control, TabPageLogic> TabPageLogicDict = new Dictionary<Control, TabPageLogic>();
        public RemoteUserClient RcUClient;
        public RcServer RcServer;

        public ClientWindowLogic(RemoteUserClient client, WpfWindowClientManager wpfWindow)
        {
            this.RcUClient = client;
            RcServer = client.Connection.RcServer;
            this.wpfWindow = wpfWindow;
            wpfWindow.OnTabPageInsertedEvent += WpfWindow_OnTabPageInsertedEvent;
        }

        private void WpfWindow_OnTabPageInsertedEvent(AvalonDock.Layout.LayoutDocument doc, Control content)
        {
            if (content is CT_WebCam ctWebcam)
                InsertTabLogic(ctWebcam, new TabPageLogicWebCam(this));
            else if(content is CT_FileSystem ctF) 
                InsertTabLogic(ctF, new TabPageLogicFileSystem(this));
        }


        private void InsertTabLogic(Control tab, TabPageLogic logic)
        {
            if (TabPageLogicDict.ContainsKey(tab))
                return;
            tab.DataContext = logic;
            logic.OnExposedToControl(tab);
            TabPageLogicDict.Add(tab, logic);
        }
    }
}
