using RCTool_Server.ViewController.ClientTab;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace RCTool_Server.Views.Tabs
{
    public class ClientTabUC : UserControl
    {
        public WindowClientController masterWindow;
        public TabControllerBase tabController;

        public ClientTabUC()
        {
            Loaded += ClientTabUC_Loaded;
        }

        private void ClientTabUC_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            masterWindow = (WindowClientController)Window.GetWindow(this);
        }
    }
}
