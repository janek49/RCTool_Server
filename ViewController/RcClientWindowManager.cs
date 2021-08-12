using RCTool_Server.Client;
using RCTool_Server.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RCTool_Server.ViewController
{
    public class RcClientWindowManager
    {
        private RcViewController rcViewController;

        public Dictionary<RemoteClient, Window> ClientToWindowDict = new Dictionary<RemoteClient, Window>();

        public RcClientWindowManager(RcViewController rcv)
        {
            rcViewController = rcv;
        }

        public void OpenWindowForClient(RemoteClient rc)
        {
            if (ClientToWindowDict.ContainsKey(rc))
            {
                Window window = ClientToWindowDict[rc];

                if (window == null)
                    goto lbl_create;

                var propertyInfo = typeof(Window).GetProperty("IsDisposed", BindingFlags.NonPublic | BindingFlags.Instance);
                var isDisposed = (bool)propertyInfo.GetValue(window);

                if (isDisposed)
                    goto lbl_create;

                if (!window.IsVisible)
                    window.Show();

                window.Focus();
                window.BringIntoView();
                return;
            }

        lbl_create:
            CreateAndShowNewWindow(rc);
        }

        public RemoteClient FindClientForWindow(Window window)
        {
            return ClientToWindowDict.FirstOrDefault(x => x.Value == window).Key;
        }

        private void CreateAndShowNewWindow(RemoteClient rc)
        {
            ClientToWindowDict.Remove(rc);
            WindowClientController wcc = new WindowClientController(this);
            ClientToWindowDict.Add(rc, wcc);
            wcc.Show();
            wcc.Focus();
        }

    }
}
