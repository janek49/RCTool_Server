using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace RCTool_Server.Util
{
    [Designer(typeof(ControlDesigner))]
    public class CallbackForm : Form
    {
        public CallbackForm()
        {
            FormClosed += CallbackForm_FormClosed;
        }

        private object _callback;

        public Form WhenClosed<T>(Action<T> t) where T : Form
        {
            _callback = t;
            return this;
        }

        private void CallbackForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            _callback?.GetType().GetMethod("Invoke").Invoke(_callback, new object[] { this });
        }


    }
}
