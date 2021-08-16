using RCTool_Server.Client;
using RCTool_Server.Views;
using ServerUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace UIController.ClientUI
{
    public class ClientWindowManager
    {
        public Dictionary<RemoteUserClient, ClientWindowLogic> MapClientToWindowCtx = new Dictionary<RemoteUserClient, ClientWindowLogic>();

        public ClientWindowManager()
        {
        }

        public void OpenWindowForClient(RemoteUserClient rc)
        {
            if (MapClientToWindowCtx.ContainsKey(rc))
            {
                Window window = MapClientToWindowCtx[rc].wpfWindow;

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
            return MapClientToWindowCtx.FirstOrDefault(x => x.Value.wpfWindow == window).Key;
        }

        private void CreateAndShowNewWindow(RemoteUserClient rc)
        {
            MapClientToWindowCtx.Remove(rc);
            WpfWindowClientManager wcc = new WpfWindowClientManager();
            MapClientToWindowCtx.Add(rc, new ClientWindowLogic(rc, wcc));
            wcc.Show();
            wcc.Focus();
        }

    }
}
