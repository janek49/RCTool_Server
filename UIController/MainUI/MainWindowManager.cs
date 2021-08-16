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
    class MainWindowManager
    {
        [STAThread]
        static void Main(string[] args)
        {
            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
            new MainWindowManager().RunApp(args);
        }

        private MainWindowLogic mwc;
        private WpfWindowMainForm window;
        private ClientWindowManager clientWdx;

        public void RunApp(string[] args)
        {
            window = new WpfWindowMainForm();
            mwc = new MainWindowLogic();
            clientWdx = new ClientWindowManager();
            window.DataContext = mwc;
            mwc.OnRemoteClientsUpdatedEvent += Mwc_OnRemoteClientsUpdatedEvent;
            window.OnListViewItemDoubleClickedEvent += Window_OnListViewItemDoubleClickedEvent;
            new System.Windows.Application().Run(window);

        }

        private void Window_OnListViewItemDoubleClickedEvent(object value)
        {
            if (value is RemoteUserClient ruc)
                clientWdx.OpenWindowForClient(ruc);
        }

        private void Mwc_OnRemoteClientsUpdatedEvent(ICollection<RCTool_Server.Client.RemoteClient> RemoteClients)
        {
            window.SetListViewContent(RemoteClients);
        }


    }
}
