namespace AGApp.Control.Browse
{
    partial class chBrowser
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

        #region コンポーネント デザイナーで生成されたコード

        /// <summary> 
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を 
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.urlTextBox = new System.Windows.Forms.TextBox();
            this.chButton = new System.Windows.Forms.Button();
            this.commandPanel = new System.Windows.Forms.Panel();
            this.updateButton = new System.Windows.Forms.Button();
            this.backButton = new System.Windows.Forms.Button();
            this.goButton = new System.Windows.Forms.Button();
            this.chWebBrowser = new AGApp.ExWebBrowser();
            this.trackBar = new System.Windows.Forms.TrackBar();
            this.waitLabel = new System.Windows.Forms.Label();
            this.commandPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // urlTextBox
            // 
            this.urlTextBox.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.urlTextBox.Location = new System.Drawing.Point(84, 10);
            this.urlTextBox.Margin = new System.Windows.Forms.Padding(0);
            this.urlTextBox.Name = "urlTextBox";
            this.urlTextBox.Size = new System.Drawing.Size(380, 23);
            this.urlTextBox.TabIndex = 1;
            // 
            // chButton
            // 
            this.chButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chButton.Image = global::AGApp.Properties.Resources.home;
            this.chButton.Location = new System.Drawing.Point(506, 4);
            this.chButton.Name = "chButton";
            this.chButton.Size = new System.Drawing.Size(36, 36);
            this.chButton.TabIndex = 3;
            this.chButton.UseVisualStyleBackColor = true;
            this.chButton.Click += new System.EventHandler(this.chButton_Click);
            // 
            // commandPanel
            // 
            this.commandPanel.Controls.Add(this.updateButton);
            this.commandPanel.Controls.Add(this.backButton);
            this.commandPanel.Location = new System.Drawing.Point(0, 0);
            this.commandPanel.Name = "commandPanel";
            this.commandPanel.Size = new System.Drawing.Size(80, 42);
            this.commandPanel.TabIndex = 0;
            // 
            // updateButton
            // 
            this.updateButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.updateButton.Image = global::AGApp.Properties.Resources.update;
            this.updateButton.Location = new System.Drawing.Point(41, 3);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(36, 36);
            this.updateButton.TabIndex = 2;
            this.updateButton.UseVisualStyleBackColor = true;
            this.updateButton.Click += new System.EventHandler(this.updateButton_Click);
            // 
            // backButton
            // 
            this.backButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.backButton.Image = global::AGApp.Properties.Resources.left;
            this.backButton.Location = new System.Drawing.Point(3, 3);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(36, 36);
            this.backButton.TabIndex = 0;
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // goButton
            // 
            this.goButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.goButton.Image = global::AGApp.Properties.Resources.right;
            this.goButton.Location = new System.Drawing.Point(468, 4);
            this.goButton.Name = "goButton";
            this.goButton.Size = new System.Drawing.Size(36, 36);
            this.goButton.TabIndex = 1;
            this.goButton.UseVisualStyleBackColor = true;
            this.goButton.Click += new System.EventHandler(this.goButton_Click);
            // 
            // chWebBrowser
            // 
            this.chWebBrowser.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.chWebBrowser.Location = new System.Drawing.Point(0, 50);
            this.chWebBrowser.Margin = new System.Windows.Forms.Padding(0);
            this.chWebBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.chWebBrowser.Name = "chWebBrowser";
            this.chWebBrowser.ScriptErrorsSuppressed = true;
            this.chWebBrowser.Size = new System.Drawing.Size(680, 450);
            this.chWebBrowser.TabIndex = 4;
            this.chWebBrowser.BeforeNavigate += new System.EventHandler(this.chWebBrowser_BeforeNavigate);
            this.chWebBrowser.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.chWebBrowser_DocumentCompleted);
            this.chWebBrowser.NewWindow += new System.ComponentModel.CancelEventHandler(this.chWebBrowser_NewWindow);
            // 
            // trackBar
            // 
            this.trackBar.Location = new System.Drawing.Point(543, 5);
            this.trackBar.Margin = new System.Windows.Forms.Padding(0);
            this.trackBar.Maximum = 100;
            this.trackBar.Name = "trackBar";
            this.trackBar.Size = new System.Drawing.Size(130, 42);
            this.trackBar.TabIndex = 19;
            this.trackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar.Scroll += new System.EventHandler(this.trackBar_Scroll);
            // 
            // waitLabel
            // 
            this.waitLabel.Location = new System.Drawing.Point(553, 25);
            this.waitLabel.Name = "waitLabel";
            this.waitLabel.Size = new System.Drawing.Size(115, 23);
            this.waitLabel.TabIndex = 20;
            this.waitLabel.Text = "label2";
            this.waitLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.waitLabel);
            this.Controls.Add(this.goButton);
            this.Controls.Add(this.commandPanel);
            this.Controls.Add(this.chButton);
            this.Controls.Add(this.urlTextBox);
            this.Controls.Add(this.chWebBrowser);
            this.Controls.Add(this.trackBar);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "chBrowser";
            this.Size = new System.Drawing.Size(680, 500);
            this.commandPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox urlTextBox;
        private AGApp.ExWebBrowser chWebBrowser;
        private System.Windows.Forms.Button chButton;
        private System.Windows.Forms.Panel commandPanel;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Button goButton;
        private System.Windows.Forms.Button updateButton;
        private System.Windows.Forms.TrackBar trackBar;
        private System.Windows.Forms.Label waitLabel;
    }
}
