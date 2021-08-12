using RCTool_Server.Client;
using RCTool_Server.ViewController;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RCTool_Server.Views
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public RcViewController rcViewController;
        public RcClientWindowManager rcWindowManager;

        public MainWindow()
        {
            InitializeComponent();
            rcViewController = new RcViewController();
            DataContext = rcViewController;
            rcViewController.OnRemoteClientsUpdatedEvent += RcViewController_OnRemoteClientsUpdatedEvent;
            rcWindowManager = new RcClientWindowManager(rcViewController);
        }

        private void RcViewController_OnRemoteClientsUpdatedEvent(ICollection<RemoteClient> RemoteClients)
        {
            Dispatcher.Invoke(() => WpfGuiUtil.SetListViewItemSource(ListViewRemoteClients, RemoteClients));
        }

        private void ListViewRemoteClients_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if(ListViewRemoteClients.SelectedValue != null)
            {
                RemoteClient rc = (RemoteClient)ListViewRemoteClients.SelectedValue;
                rcWindowManager.OpenWindowForClient(rc);
            }
        }
    }
}