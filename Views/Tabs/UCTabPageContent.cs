using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace RCTool_Server.Views.Tabs
{
    [Designer(typeof(ParentControlDesigner))]
    public class UCTabPageContent : UserControl
    {
        public FormClientController clientController;

        public UCTabPageContent(FormClientController fcc)  
        {
            clientController = fcc;
        }

        private UCTabPageContent()
        {

        }

        public delegate void OnTabPageClosed();
        public event OnTabPageClosed OnTabPageClosedEvent;

        public void BeforeClosing()
        {
            OnTabPageClosedEvent.Invoke();
        }
    }
}
