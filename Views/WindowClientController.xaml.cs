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
    /// Logika interakcji dla klasy WindowClientController.xaml
    /// </summary>
    public partial class WindowClientController : Window
    {
        public RcClientWindowManager windowManager;

        public WindowClientController(RcClientWindowManager windowManager)
        {
            InitializeComponent();
            this.windowManager = windowManager;
        }
    }
}
