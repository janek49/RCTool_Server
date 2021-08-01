using RCTool_Server.Client;
using RCTool_Server.Client.InboundPackets;
using RCTool_Server.Client.OutboundPackets;
using RCTool_Server.Client.WebCam;
using RCTool_Server.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.Design;
using System.Windows.Forms;

namespace RCTool_Server.Views.Tabs
{
    public partial class UC_WebCam : UCTabPageContent
    {
        private class WebCamBoxEntry
        {
            public string Id, Name;

            public override string ToString()
            {
                return $"{Name} ({Id})";
            }
        }

        public UC_WebCam(FormClientController fcc) : base(fcc)
        {
            InitializeComponent();
            OnTabPageClosedEvent += UC_WebCam_OnTabPageClosedEvent;
        }

        private void UC_WebCam_OnTabPageClosedEvent()
        {
            CloseSocket();
        }

        private RemoteWebCamClient rwc;

        private void tsBtnRefreshList_Click(object sender, EventArgs e)
        {
            GetWebCamList();
        }

        private void tsBtnOpenSocket_Click(object sender, EventArgs e)
        {
            if (rwc == null)
            {
                OpenSocket();
                tsBtnOpenSocket.Text = "Rozłącz";
            }
            else
            {
                CloseSocket();
                tsBtnOpenSocket.Text = "Połącz";
            }
        }

        private void GetWebCamList()
        {
            rwc?.SendPacket(new OutboundPacket00RequestData(OutboundPacket00RequestData.EnumDataType.WEBCAM_LIST)).ListenForAnswer(
                    (packet) =>
                    {
                        if (packet is InboundPacket03WebCam ip && ip.CommandMode == (int)WebCamAction.REQUEST_LIST)
                        {
                            this.InvokeAsync(() => FillWebCamList(ip));
                            return true;
                        }
                        return false;
                    });
        }

        private void FillWebCamList(InboundPacket03WebCam ip)
        {
            tsCmbCamList.Items.Clear();

            foreach (KeyValuePair<string, string> kvp in ip.WebCamDictionary)
            {
                tsCmbCamList.Items.Add(new WebCamBoxEntry { Id = kvp.Key, Name = kvp.Value });
            }
        }

        private void OpenSocket()
        {
            if (rwc != null)
                return;

            var uuid = Guid.NewGuid().ToString();
            clientController.remoteClient.SendPacket(new OutboundPacket01OpenSocket()
            {
                ConnectionType = 3,
                Uuid = uuid
            });

            ClientHandler.OnClientRegistered eh = null;
            eh = (rc) =>
            {
                if (rc.ClientId == uuid)
                {
                    rwc = (RemoteWebCamClient)rc;
                    clientController.rcServer.InboundPacketHandler.ClientHandler.ClientRegisteredEvent -= eh;
                }
            };
            clientController.rcServer.InboundPacketHandler.ClientHandler.ClientRegisteredEvent += eh;
        }

        private void CloseSocket()
        {
            if (rwc == null) return;
            rwc.Connection.Disconnect();
            clientController.rcServer.InboundPacketHandler.ClientHandler.UnregisterClient(rwc.Connection);
            rwc = null;
        }

        private byte[][] _imageParts;

        private void DoSnapshot(WebCamBoxEntry wcbe)
        {
            _imageParts = null;
            rwc.SendPacket(new OutboundPacket02WebCam { Action = WebCamAction.TAKE_SNAPSHOT, CamId = wcbe.Id }).ListenForAnswer((packet) =>
            {
                if (packet is InboundPacket04ChunkTransfer transfer)
                {
                    _imageParts ??= new byte[transfer.PartAmount][];

                    _imageParts[transfer.CurrentPart - 1] = (transfer.Buffer);
                    if (transfer.CurrentPart == transfer.PartAmount)
                    {
                        this.InvokeAsync(() => tsBtnSnapshot.Enabled = true);

                        List<byte> bytes = new List<byte>();
                        foreach (var imagePart in _imageParts)
                        {
                            bytes.AddRange(imagePart);
                        }
                        using (var ms = new MemoryStream(bytes.ToArray()))
                            pbCamImage.Image = new Bitmap(ms);

                        return true;
                    }
                }
                return false;
            });
        }

        private void tsBtnSnapshot_Click(object sender, EventArgs e)
        {
            if (rwc != null && tsCmbCamList.SelectedItem is WebCamBoxEntry wc)
                DoSnapshot(wc);
        }

    }
}
