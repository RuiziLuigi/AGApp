namespace AGApp
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.Visible = false;
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.infoBrowser = new AGApp.Control.Browse.infoBrowser();
            this.axShockwaveFlash = new AxShockwaveFlashObjects.AxShockwaveFlash();
            this.liveControl = new AGApp.Control.liveControl();
            ((System.ComponentModel.ISupportInitialize)(this.axShockwaveFlash)).BeginInit();
            this.SuspendLayout();
            // 
            // notifyIcon
            // 
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Visible = true;
            // 
            // infoBrowser
            // 
            this.infoBrowser._TimerProc = null;
            this.infoBrowser.AutoScroll = true;
            this.infoBrowser.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.infoBrowser.Location = new System.Drawing.Point(5, 230);
            this.infoBrowser.Margin = new System.Windows.Forms.Padding(0);
            this.infoBrowser.Name = "infoBrowser";
            this.infoBrowser.Size = new System.Drawing.Size(320, 340);
            this.infoBrowser.TabIndex = 8;
            // 
            // axShockwaveFlash
            // 
            this.axShockwaveFlash.Enabled = true;
            this.axShockwaveFlash.Location = new System.Drawing.Point(5, 5);
            this.axShockwaveFlash.Margin = new System.Windows.Forms.Padding(0);
            this.axShockwaveFlash.Name = "axShockwaveFlash";
            this.axShockwaveFlash.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axShockwaveFlash.OcxState")));
            this.axShockwaveFlash.Size = new System.Drawing.Size(320, 210);
            this.axShockwaveFlash.TabIndex = 7;
            // 
            // liveControl
            // 
            this.liveControl.Location = new System.Drawing.Point(350, 3);
            this.liveControl.Margin = new System.Windows.Forms.Padding(0);
            this.liveControl.Name = "liveControl";
            this.liveControl.Size = new System.Drawing.Size(710, 600);
            this.liveControl.TabIndex = 10;
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(1074, 612);
            this.Controls.Add(this.infoBrowser);
            this.Controls.Add(this.axShockwaveFlash);
            this.Controls.Add(this.liveControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "A&G+実況";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.axShockwaveFlash)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AxShockwaveFlashObjects.AxShockwaveFlash axShockwaveFlash;
        private Control.Browse.infoBrowser infoBrowser;
        private Control.liveControl liveControl;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ToolTip toolTip;
    }
}

