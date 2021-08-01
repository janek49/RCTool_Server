
namespace RCTool_Server.Views.Tabs
{
    partial class UC_WebCam
    {
        /// <summary> 
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod wygenerowany przez Projektanta składników

        /// <summary> 
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować 
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsCmbCamList = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.pbCamImage = new System.Windows.Forms.PictureBox();
            this.tsBtnOpenSocket = new System.Windows.Forms.ToolStripButton();
            this.tsBtnRefreshList = new System.Windows.Forms.ToolStripButton();
            this.tsBtnSnapshot = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCamImage)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBtnOpenSocket,
            this.tsBtnRefreshList,
            this.toolStripSeparator1,
            this.toolStripLabel1,
            this.tsCmbCamList,
            this.toolStripSeparator2,
            this.tsBtnSnapshot});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(601, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsCmbCamList
            // 
            this.tsCmbCamList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tsCmbCamList.MaxDropDownItems = 100;
            this.tsCmbCamList.Name = "tsCmbCamList";
            this.tsCmbCamList.Size = new System.Drawing.Size(200, 25);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(94, 22);
            this.toolStripLabel1.Text = "Wybierz kamerę:";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // pbCamImage
            // 
            this.pbCamImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbCamImage.Location = new System.Drawing.Point(0, 25);
            this.pbCamImage.Name = "pbCamImage";
            this.pbCamImage.Size = new System.Drawing.Size(601, 447);
            this.pbCamImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbCamImage.TabIndex = 1;
            this.pbCamImage.TabStop = false;
            // 
            // tsBtnOpenSocket
            // 
            this.tsBtnOpenSocket.Image = global::RCTool_Server.Properties.Resources.connect;
            this.tsBtnOpenSocket.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnOpenSocket.Name = "tsBtnOpenSocket";
            this.tsBtnOpenSocket.Size = new System.Drawing.Size(61, 22);
            this.tsBtnOpenSocket.Text = "Połącz";
            this.tsBtnOpenSocket.Click += new System.EventHandler(this.tsBtnOpenSocket_Click);
            // 
            // tsBtnRefreshList
            // 
            this.tsBtnRefreshList.Image = global::RCTool_Server.Properties.Resources.refresh;
            this.tsBtnRefreshList.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnRefreshList.Name = "tsBtnRefreshList";
            this.tsBtnRefreshList.Size = new System.Drawing.Size(95, 22);
            this.tsBtnRefreshList.Text = "Odśwież listę";
            this.tsBtnRefreshList.Click += new System.EventHandler(this.tsBtnRefreshList_Click);
            // 
            // tsBtnSnapshot
            // 
            this.tsBtnSnapshot.Image = global::RCTool_Server.Properties.Resources.camera_black;
            this.tsBtnSnapshot.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnSnapshot.Name = "tsBtnSnapshot";
            this.tsBtnSnapshot.Size = new System.Drawing.Size(75, 22);
            this.tsBtnSnapshot.Text = "Migawka";
            this.tsBtnSnapshot.Click += new System.EventHandler(this.tsBtnSnapshot_Click);
            // 
            // UC_WebCam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pbCamImage);
            this.Controls.Add(this.toolStrip1);
            this.Name = "UC_WebCam";
            this.Size = new System.Drawing.Size(601, 472);
            this.Tag = "Kamera";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCamImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsBtnSnapshot;
        private System.Windows.Forms.PictureBox pbCamImage;
        private System.Windows.Forms.ToolStripButton tsBtnRefreshList;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox tsCmbCamList;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsBtnOpenSocket;
    }
}
