using RCTool_Server.Util;
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

namespace RCTool_Server.Views.Tabs
{
    /// <summary>
    /// Logika interakcji dla klasy CT_WebCam.xaml
    /// </summary>
    public partial class CT_WebCam : ClientTabUC
    {
        public CT_WebCam()
        {
            InitializeComponent();
        }
 
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            tabController = new TabControllerWebCam(this);
            DataContext = tabController;
        }
    }
}
