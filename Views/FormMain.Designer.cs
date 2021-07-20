namespace RCTool_Server.Views
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.objectListView1 = new BrightIdeasSoftware.ObjectListView();
            this.lvcStatus = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.lvcIP = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.lvcUser = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.lvcOS = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.lvcRAM = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.lvcLocale = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.lvcPing = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn8 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn9 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn10 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn11 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.label1 = new System.Windows.Forms.Label();
            this.nudServerPort = new System.Windows.Forms.NumericUpDown();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsLblConClients = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsLblThreads = new System.Windows.Forms.ToolStripStatusLabel();
            this.timerUI = new System.Windows.Forms.Timer(this.components);
            this.btnStopServer = new System.Windows.Forms.Button();
            this.btnStartServer = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.objectListView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudServerPort)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // objectListView1
            // 
            this.objectListView1.AllColumns.Add(this.lvcStatus);
            this.objectListView1.AllColumns.Add(this.lvcIP);
            this.objectListView1.AllColumns.Add(this.lvcUser);
            this.objectListView1.AllColumns.Add(this.lvcOS);
            this.objectListView1.AllColumns.Add(this.lvcRAM);
            this.objectListView1.AllColumns.Add(this.lvcLocale);
            this.objectListView1.AllColumns.Add(this.lvcPing);
            this.objectListView1.AllColumns.Add(this.olvColumn8);
            this.objectListView1.AllColumns.Add(this.olvColumn9);
            this.objectListView1.AllColumns.Add(this.olvColumn10);
            this.objectListView1.AllColumns.Add(this.olvColumn11);
            this.objectListView1.CellEditUseWholeCell = false;
            this.objectListView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.lvcStatus,
            this.lvcIP,
            this.lvcUser,
            this.lvcOS,
            this.lvcRAM,
            this.lvcLocale,
            this.lvcPing,
            this.olvColumn8,
            this.olvColumn9,
            this.olvColumn10,
            this.olvColumn11});
            this.objectListView1.Cursor = System.Windows.Forms.Cursors.Default;
            this.objectListView1.FullRowSelect = true;
            this.objectListView1.HideSelection = false;
            this.objectListView1.Location = new System.Drawing.Point(12, 68);
            this.objectListView1.Name = "objectListView1";
            this.objectListView1.Size = new System.Drawing.Size(776, 333);
            this.objectListView1.TabIndex = 0;
            this.objectListView1.UseCompatibleStateImageBehavior = false;
            this.objectListView1.View = System.Windows.Forms.View.Details;
            this.objectListView1.DoubleClick += new System.EventHandler(this.objectListView1_DoubleClick);
            // 
            // lvcStatus
            // 
            this.lvcStatus.Hideable = false;
            this.lvcStatus.IsEditable = false;
            this.lvcStatus.MaximumWidth = 20;
            this.lvcStatus.MinimumWidth = 20;
            this.lvcStatus.Text = "";
            this.lvcStatus.Width = 20;
            // 
            // lvcIP
            // 
            this.lvcIP.Text = "Adres IP";
            this.lvcIP.Width = 110;
            // 
            // lvcUser
            // 
            this.lvcUser.Text = "Użytkownik";
            this.lvcUser.Width = 110;
            // 
            // lvcOS
            // 
            this.lvcOS.Text = "System operacyjny";
            this.lvcOS.Width = 160;
            // 
            // lvcRAM
            // 
            this.lvcRAM.Text = "Pamięć RAM";
            this.lvcRAM.Width = 90;
            // 
            // lvcLocale
            // 
            this.lvcLocale.Text = "Język";
            this.lvcLocale.Width = 90;
            // 
            // lvcPing
            // 
            this.lvcPing.Text = "Ping";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Port do komunikacji:";
            // 
            // nudServerPort
            // 
            this.nudServerPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.nudServerPort.Location = new System.Drawing.Point(136, 18);
            this.nudServerPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.nudServerPort.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudServerPort.Name = "nudServerPort";
            this.nudServerPort.Size = new System.Drawing.Size(120, 21);
            this.nudServerPort.TabIndex = 2;
            this.nudServerPort.Value = new decimal(new int[] {
            9900,
            0,
            0,
            0});
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsLblConClients,
            this.toolStripStatusLabel1,
            this.tsLblThreads});
            this.statusStrip1.Location = new System.Drawing.Point(0, 412);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(800, 22);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsLblConClients
            // 
            this.tsLblConClients.Name = "tsLblConClients";
            this.tsLblConClients.Size = new System.Drawing.Size(118, 17);
            this.tsLblConClients.Text = "Podłączone klienty: 0";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(10, 17);
            this.toolStripStatusLabel1.Text = "|";
            // 
            // tsLblThreads
            // 
            this.tsLblThreads.Name = "tsLblThreads";
            this.tsLblThreads.Size = new System.Drawing.Size(87, 17);
            this.tsLblThreads.Text = "Ilość wątków: 0";
            // 
            // timerUI
            // 
            this.timerUI.Enabled = true;
            this.timerUI.Tick += new System.EventHandler(this.timerUI_Tick);
            // 
            // btnStopServer
            // 
            this.btnStopServer.Enabled = false;
            this.btnStopServer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnStopServer.Image = global::RCTool_Server.Properties.Resources.exit;
            this.btnStopServer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStopServer.Location = new System.Drawing.Point(472, 12);
            this.btnStopServer.Name = "btnStopServer";
            this.btnStopServer.Size = new System.Drawing.Size(133, 31);
            this.btnStopServer.TabIndex = 4;
            this.btnStopServer.Text = "Zatrzymaj serwer";
            this.btnStopServer.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnStopServer.UseVisualStyleBackColor = true;
            this.btnStopServer.Click += new System.EventHandler(this.btnStopServer_Click);
            // 
            // btnStartServer
            // 
            this.btnStartServer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnStartServer.Image = global::RCTool_Server.Properties.Resources.apply;
            this.btnStartServer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStartServer.Location = new System.Drawing.Point(334, 12);
            this.btnStartServer.Name = "btnStartServer";
            this.btnStartServer.Size = new System.Drawing.Size(132, 31);
            this.btnStartServer.TabIndex = 3;
            this.btnStartServer.Text = "Uruchom serwer";
            this.btnStartServer.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnStartServer.UseVisualStyleBackColor = true;
            this.btnStartServer.Click += new System.EventHandler(this.btnStartServer_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(611, 20);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(699, 22);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 434);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnStopServer);
            this.Controls.Add(this.btnStartServer);
            this.Controls.Add(this.nudServerPort);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.objectListView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormMain";
            this.Text = "FormMain";
            this.Load += new System.EventHandler(this.FormMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.objectListView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudServerPort)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private BrightIdeasSoftware.ObjectListView objectListView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nudServerPort;
        private System.Windows.Forms.Button btnStartServer;
        private System.Windows.Forms.Button btnStopServer;
        private BrightIdeasSoftware.OLVColumn lvcStatus;
        private BrightIdeasSoftware.OLVColumn lvcIP;
        private BrightIdeasSoftware.OLVColumn lvcUser;
        private BrightIdeasSoftware.OLVColumn lvcOS;
        private BrightIdeasSoftware.OLVColumn lvcRAM;
        private BrightIdeasSoftware.OLVColumn lvcLocale;
        private BrightIdeasSoftware.OLVColumn lvcPing;
        private BrightIdeasSoftware.OLVColumn olvColumn8;
        private BrightIdeasSoftware.OLVColumn olvColumn9;
        private BrightIdeasSoftware.OLVColumn olvColumn10;
        private BrightIdeasSoftware.OLVColumn olvColumn11;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tsLblConClients;
        private System.Windows.Forms.ToolStripStatusLabel tsLblThreads;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Timer timerUI;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}