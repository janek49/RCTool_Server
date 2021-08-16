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

namespace ServerUI
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class WpfWindowMainForm : Window
    {

        public delegate void ListViewItemDoubleClicked(object value);
        public event ListViewItemDoubleClicked OnListViewItemDoubleClickedEvent;

        public WpfWindowMainForm()
        {
            InitializeComponent();
        }

        public void SetListViewContent<T>(IEnumerable<T> contents)
        {
            Dispatcher.Invoke(() => WpfGuiUtil.SetListViewItemSource(ListViewRemoteClients, contents));
        }

        private void ListViewRemoteClients_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if(ListViewRemoteClients.SelectedValue != null)
                OnListViewItemDoubleClickedEvent?.Invoke(ListViewRemoteClients.SelectedValue);
        }


    }
}