using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RCTool_Server.Views.Tabs
{
    public class UserControlTabPage : TabPage
    {
        public UCTabPageContent UserTab;

        public UserControlTabPage(UCTabPageContent tuc)
        {
            UserTab = tuc;
            Controls.Add(tuc);
            Text = tuc.Tag.ToString();
            tuc.Dock = DockStyle.Fill;

        }
 
    }
}
