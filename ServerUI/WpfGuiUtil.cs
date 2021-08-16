using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ServerUI
{
    public static class WpfGuiUtil
    {
        public static void SetDataGridItemSource<T>(DataGrid dataGrid, IEnumerable<T> col)
        {
            dataGrid.ItemsSource = null;
            dataGrid.Items.Refresh();
            dataGrid.ItemsSource = col;
            dataGrid.Items.Refresh();
        }

        public static void SetListViewItemSource<T>(ListView dataGrid, IEnumerable<T> col)
        {
            dataGrid.ItemsSource = null;
            dataGrid.Items.Refresh();
            dataGrid.ItemsSource = col;
            dataGrid.Items.Refresh();
        }
    }
}
