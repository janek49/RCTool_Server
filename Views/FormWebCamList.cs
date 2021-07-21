using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RCTool_Server.Util;

namespace RCTool_Server.Views
{
    public partial class FormWebCamList : CallbackForm
    {
        public Dictionary<string, string> WebCamDictionary;

        public FormWebCamList()
        {
            InitializeComponent();
        }

        public FormWebCamList(Dictionary<string, string> webCamDictionary) : this()
        {
            WebCamDictionary = webCamDictionary;
        }

        private void FormWebCamList_Load(object sender, EventArgs e)
        {
            foreach (var keyPair in WebCamDictionary)
            {
                var lvi = new ListViewItem(new string[] { "", keyPair.Value, keyPair.Key });
                lvi.ImageIndex = 0;
                lvWebCams.Items.Add(lvi);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
