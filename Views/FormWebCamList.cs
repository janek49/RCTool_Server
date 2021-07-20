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
    public partial class FormWebCamList : Form
    {
        public Dictionary<string, string> WebCamDictionary;

        public FormWebCamList()
        {
            InitializeComponent();
        }

        public FormWebCamList(Dictionary<string, string> webCamDictionary)
        {
            WebCamDictionary = webCamDictionary;
        }

        private void FormWebCamList_Load(object sender, EventArgs e)
        {
            foreach (var keyPair in WebCamDictionary)
            {
                var lvi = new ListViewItem(new string[]{"", keyPair.Key, keyPair.Value});
                lvi.ImageIndex = 0;
                lvWebCams.Items.Add(lvi);
            }
        }
    }
}
