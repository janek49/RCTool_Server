using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RCTool_Server.Client;
using ServerUI;
using UIController.ClientUI;
using UIController.MainUI;

namespace UIController.MainUI
{
    public class MainWindowManager
    {
        [STAThread]
        static void Main(string[] args)
        {
            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
            new MainWindowManager().RunApp(args);
        }

        public MainWindowLogic MainWindowLogic;
        public WpfWindowMainForm WpfWindow;
        public ClientWindowManager ClientWindowMgr;

        public void RunApp(string[] args)
        {
            WpfWindow = new WpfWindowMainForm();
            MainWindowLogic = new MainWindowLogic(this);
            ClientWindowMgr = new ClientWindowManager();
            WpfWindow.DataContext = MainWindowLogic;
            MainWindowLogic.OnRemoteClientsUpdatedEvent += Mwc_OnRemoteClientsUpdatedEvent;
            WpfWindow.OnListViewItemDoubleClickedEvent += Window_OnListViewItemDoubleClickedEvent;
            new System.Windows.Application().Run(WpfWindow);

        }

        private void Window_OnListViewItemDoubleClickedEvent(object value)
        {
            if (value is RemoteUserClient ruc)
                ClientWindowMgr.OpenWindowForClient(ruc);
        }

        private void Mwc_OnRemoteClientsUpdatedEvent(ICollection<RCTool_Server.Client.RemoteClient> RemoteClients)
        {
            WpfWindow.SetListViewContent(RemoteClients);
        }


    }
}
