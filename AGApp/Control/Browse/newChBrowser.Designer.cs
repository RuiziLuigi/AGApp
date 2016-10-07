namespace AGApp.Control.Browse
{
    partial class newChBrowser
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
            this.updateButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.titleListBox = new System.Windows.Forms.ListBox();
            this.readButton = new System.Windows.Forms.Button();
            this.chWebBrowser = new AGApp.ExWebBrowser();
            this.stateTextBox = new System.Windows.Forms.TextBox();
            this.updateThreadButton = new System.Windows.Forms.Button();
            this.waitLabel = new System.Windows.Forms.Label();
            this.trackBar = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // updateButton
            // 
            this.updateButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.updateButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.updateButton.Location = new System.Drawing.Point(514, 25);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(103, 36);
            this.updateButton.TabIndex = 2;
            this.updateButton.Text = "スレッド一覧更新";
            this.updateButton.UseVisualStyleBackColor = false;
            this.updateButton.Click += new System.EventHandler(this.updateButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 12);
            this.label2.TabIndex = 20;
            this.label2.Text = "【ラジオ実況】スレッド一覧";
            // 
            // titleListBox
            // 
            this.titleListBox.FormattingEnabled = true;
            this.titleListBox.ItemHeight = 12;
            this.titleListBox.Location = new System.Drawing.Point(8, 24);
            this.titleListBox.Name = "titleListBox";
            this.titleListBox.Size = new System.Drawing.Size(380, 112);
            this.titleListBox.TabIndex = 21;
            // 
            // readButton
            // 
            this.readButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.readButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.readButton.Location = new System.Drawing.Point(398, 25);
            this.readButton.Name = "readButton";
            this.readButton.Size = new System.Drawing.Size(103, 36);
            this.readButton.TabIndex = 23;
            this.readButton.Text = "スレッド読み込み";
            this.readButton.UseVisualStyleBackColor = false;
            this.readButton.Click += new System.EventHandler(this.readButton_Click);
            // 
            // chWebBrowser
            // 
            this.chWebBrowser.BeforeNavigateUrl = "about:blank";
            this.chWebBrowser.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.chWebBrowser.IsWebBrowserContextMenuEnabled = false;
            this.chWebBrowser.Location = new System.Drawing.Point(0, 140);
            this.chWebBrowser.Margin = new System.Windows.Forms.Padding(0);
            this.chWebBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.chWebBrowser.Name = "chWebBrowser";
            this.chWebBrowser.ScriptErrorsSuppressed = true;
            this.chWebBrowser.Size = new System.Drawing.Size(700, 420);
            this.chWebBrowser.TabIndex = 4;
            this.chWebBrowser.BeforeNavigate += new System.EventHandler(this.chWebBrowser_BeforeNavigate);
            this.chWebBrowser.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.chWebBrowser_DocumentCompleted);
            this.chWebBrowser.NewWindow += new System.ComponentModel.CancelEventHandler(this.chWebBrowser_NewWindow);
            // 
            // stateTextBox
            // 
            this.stateTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.stateTextBox.Location = new System.Drawing.Point(398, 118);
            this.stateTextBox.Name = "stateTextBox";
            this.stateTextBox.ReadOnly = true;
            this.stateTextBox.Size = new System.Drawing.Size(280, 19);
            this.stateTextBox.TabIndex = 24;
            // 
            // updateThreadButton
            // 
            this.updateThreadButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.updateThreadButton.Image = global::AGApp.Properties.Resources.update;
            this.updateThreadButton.Location = new System.Drawing.Point(636, 76);
            this.updateThreadButton.Margin = new System.Windows.Forms.Padding(0);
            this.updateThreadButton.Name = "updateThreadButton";
            this.updateThreadButton.Size = new System.Drawing.Size(34, 34);
            this.updateThreadButton.TabIndex = 25;
            this.updateThreadButton.UseVisualStyleBackColor = true;
            this.updateThreadButton.Click += new System.EventHandler(this.updateThreadButton_Click);
            // 
            // waitLabel
            // 
            this.waitLabel.Location = new System.Drawing.Point(398, 92);
            this.waitLabel.Name = "waitLabel";
            this.waitLabel.Size = new System.Drawing.Size(147, 23);
            this.waitLabel.TabIndex = 27;
            this.waitLabel.Text = "label2";
            this.waitLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // trackBar
            // 
            this.trackBar.Location = new System.Drawing.Point(398, 70);
            this.trackBar.Margin = new System.Windows.Forms.Padding(0);
            this.trackBar.Maximum = 100;
            this.trackBar.Name = "trackBar";
            this.trackBar.Size = new System.Drawing.Size(147, 45);
            this.trackBar.TabIndex = 26;
            this.trackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar.Scroll += new System.EventHandler(this.trackBar_Scroll);
            // 
            // newChBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.waitLabel);
            this.Controls.Add(this.trackBar);
            this.Controls.Add(this.updateThreadButton);
            this.Controls.Add(this.stateTextBox);
            this.Controls.Add(this.readButton);
            this.Controls.Add(this.updateButton);
            this.Controls.Add(this.titleListBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.chWebBrowser);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "newChBrowser";
            this.Size = new System.Drawing.Size(700, 560);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AGApp.ExWebBrowser chWebBrowser;
        private System.Windows.Forms.Button updateButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox titleListBox;
        private System.Windows.Forms.Button readButton;
        private System.Windows.Forms.TextBox stateTextBox;
        private System.Windows.Forms.Button updateThreadButton;
        private System.Windows.Forms.Label waitLabel;
        private System.Windows.Forms.TrackBar trackBar;
    }
}
