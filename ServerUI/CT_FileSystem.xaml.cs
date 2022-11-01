using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
    /// Logika interakcji dla klasy CT_FileSystem.xaml
    /// </summary>
    public partial class CT_FileSystem : UserControl
    {
        public CT_FileSystem()
        {
            InitializeComponent();
        }

        public Action<object> OnListViewItemDoubleClicked = null;

        private void lstFileSystem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var selected = lstFileSystem.SelectedItems.Count == 1 ? lstFileSystem.SelectedItems[0] : null;
            if (selected != null)
                OnListViewItemDoubleClicked?.Invoke(selected);
        }
    }
}
