using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RCTool_Server.Client;
using RCTool_Server.Client.InboundPackets;
using RCTool_Server.Client.OutboundPackets;
using RCTool_Server.Client.WebCam;
using RCTool_Server.Util;

namespace RCTool_Server.Views
{
    public partial class FormWebCamPreview : Form
    {
        public FormWebCamPreview()
        {
            InitializeComponent();
        }

        public RemoteWebCamClient RemoteWebCamClient;
        public string WebCamId;

        private byte[][] _imageParts;

        private void tsBtnSnap_Click(object sender, EventArgs e)
        {
            tsBtnSnap.Enabled = false;
            _imageParts = null;
            RemoteWebCamClient.SendPacket(new OutboundPacket02WebCam { Action = WebCamAction.TAKE_SNAPSHOT, CamId = WebCamId }).ListenForAnswer((packet) =>
            {
                if (packet is InboundPacket04ChunkTransfer transfer)
                {
                    _imageParts ??= new byte[transfer.PartAmount][];

                    _imageParts[transfer.CurrentPart - 1] = (transfer.Buffer);
                    if (transfer.CurrentPart == transfer.PartAmount)
                    {
                        this.InvokeAsync(() => tsBtnSnap.Enabled = true);

                        List<byte> bytes = new List<byte>();
                        foreach (var imagePart in _imageParts)
                        {
                            bytes.AddRange(imagePart);
                        }
                        using (var ms = new MemoryStream(bytes.ToArray()))
                            pictureBox1.Image = new Bitmap(ms);

                        return true;
                    }
                }
                return false;
            });
        }
    }
}
