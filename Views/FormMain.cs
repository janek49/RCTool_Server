using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;
using System.Threading;
using System.Windows.Forms;
using RCTool_Server.Client;
using RCTool_Server.Client.InboundPackets;
using RCTool_Server.Client.OutboundPackets;
using RCTool_Server.Client.WebCam;
using RCTool_Server.Server;
using RCTool_Server.Util;

namespace RCTool_Server.Views
{
    public partial class FormMain : Form
    {
        private RcServer _ServerObj;

        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {

        }


        private void btnStartServer_Click(object sender, EventArgs e)
        {
            try
            {
                _ServerObj = new RcServer(IPAddress.Any, (int)nudServerPort.Value);
                _ServerObj.InboundPacketHandler = new InboundPacketHandler(new ClientHandler(_ServerObj));
                _ServerObj.Start();

                btnStartServer.Enabled = false;
                btnStopServer.Enabled = true;

                AttachListView();

            }
            catch (Exception exception)
            {
                Logger.Error(exception);
            }
        }

        private void btnStopServer_Click(object sender, EventArgs e)
        {
            _ServerObj.Stop();
            objectListView1.ClearObjects();
            btnStopServer.Enabled = false;
            btnStartServer.Enabled = true;
        }

        private void AttachListView()
        {
            objectListView1.SmallImageList = new ImageList()
            {
                ImageSize = new Size(16, 16),
                ColorDepth = ColorDepth.Depth32Bit
            };
            objectListView1.SmallImageList.Images.Add(Properties.Resources.kdmconfig);

            lvcStatus.ImageGetter = row => 0;
            lvcIP.AspectGetter = row => (row as RemoteClient)?.IpAddress;
            lvcUser.AspectGetter = row => (row as RemoteUserClient)?.LatestClientFacts?.Username;
            lvcOS.AspectGetter = row => (row as RemoteUserClient)?.LatestClientFacts?.OperatingSystem;
            lvcRAM.AspectGetter = row => (row as RemoteUserClient)?.LatestClientFacts?.RAM + " GB";
            lvcLocale.AspectGetter = row => (row as RemoteUserClient)?.LatestClientFacts?.Language;
            lvcPing.AspectGetter = row => (row as RemoteUserClient)?.LatestClientFacts?.Ping + " ms";


            _ServerObj.InboundPacketHandler.ClientHandler.ClientRegisteredEvent += remoteClient =>
            {
                SetListViewObjects();
            };

            _ServerObj.InboundPacketHandler.ClientHandler.ClientDisconnectedEvent += remoteClient =>
            {
                SetListViewObjects();
            };

            _ServerObj.InboundPacketHandler.ClientHandler.ClientPacketReceivedEvent += (remoteClient, packet) =>
            {
                if (packet is InboundPacket02DataResponse dr && dr.ReceivedClientFacts != null)
                {
                    SetListViewObjects();
                }
            };

        }

        private void SetListViewObjects()
        {
            objectListView1.SetObjects(_ServerObj.InboundPacketHandler.ClientHandler.AuthenticatedClients.Values);
        }

        private void timerUI_Tick(object sender, EventArgs e)
        {
            tsLblThreads.Text = "Wątki: " + System.Diagnostics.Process.GetCurrentProcess().Threads.Count;
            tsLblConClients.Text = "Podłączone klienty: " + (_ServerObj?.InboundPacketHandler?.ClientHandler?.AuthenticatedClients?.Values.Count ?? 0);
        }

        private void objectListView1_DoubleClick(object sender, EventArgs e)
        {
            if (objectListView1.SelectedObject is RemoteUserClient ruc)
                new FormClientController(ruc, _ServerObj).ShowDialog();
        }

    }
}
