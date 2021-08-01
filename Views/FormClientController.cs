using RCTool_Server.Client;
using RCTool_Server.Server;
using RCTool_Server.Views.Tabs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RCTool_Server.Views
{
    public partial class FormClientController : Form
    {
        public RemoteUserClient remoteClient;
        public RcServer rcServer;

        public FormClientController(RemoteUserClient ruc, RcServer rcServer) : this()
        {
            remoteClient = ruc;
            this.rcServer = rcServer;
        }

        private FormClientController()
        {
            InitializeComponent();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            switch (e.Node.Name)
            {
                case "nodeCam":
                    {
                        OpenTab(new UC_WebCam(this));
                        break;
                    }
            }
        }

        private void FormClientController_Load(object sender, EventArgs e)
        {
            treeView1.ExpandAll();
        }

        private void OpenTab(UCTabPageContent uc)
        {
            foreach (TabPage page in tabControl.TabPages)
                if (page.Text == uc.Tag.ToString()) return;

            tabControl.TabPages.Add(new UserControlTabPage(uc));
        }

        private void FormClientController_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (TabPage page in tabControl.TabPages)
            {
                if (page is UserControlTabPage utp)
                {
                    utp.UserTab.BeforeClosing();
                }
            }
        }

        private void tabControl_DoubleClick(object sender, EventArgs e)
        {
            UndockSelectedTab();
        }

        public void UndockSelectedTab()
        {
            var UserTab = (UserControlTabPage)tabControl.SelectedTab;
            Form frm = new Form();
            frm.Icon = Properties.Resources.Monitors;
            frm.Size = new System.Drawing.Size(UserTab.UserTab.Width, UserTab.UserTab.Height);
            frm.Controls.Add(UserTab.UserTab);
            frm.FormClosed += (e, a) => UserTab.Controls.Add(UserTab.UserTab);
            frm.Text = UserTab.UserTab.Tag.ToString() + " - [" + remoteClient.IpAddress + "]";
            frm.Show();
        }
    }
}
