namespace AGApp.Control
{
    partial class liveControl
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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.chPage = new System.Windows.Forms.TabPage();
            this.newChBrowser = new AGApp.Control.Browse.newChBrowser();
            this.twiLivePage = new System.Windows.Forms.TabPage();
            this.twitterBrowseControl1 = new AGApp.Control.Parts.TwitterControl();
            this.mailPage = new System.Windows.Forms.TabPage();
            this.mailControl1 = new AGApp.Control.Parts.MailControl();
            this.timeTablePage = new System.Windows.Forms.TabPage();
            this.timeTableControl1 = new AGApp.Control.Parts.TimeTableControl();
            this.settingPage = new System.Windows.Forms.TabPage();
            this.settingPanel1 = new AGApp.Control.Parts.SettingControl();
            this.tabControl.SuspendLayout();
            this.chPage.SuspendLayout();
            this.twiLivePage.SuspendLayout();
            this.mailPage.SuspendLayout();
            this.timeTablePage.SuspendLayout();
            this.settingPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.chPage);
            this.tabControl.Controls.Add(this.twiLivePage);
            this.tabControl.Controls.Add(this.mailPage);
            this.tabControl.Controls.Add(this.timeTablePage);
            this.tabControl.Controls.Add(this.settingPage);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Margin = new System.Windows.Forms.Padding(0);
            this.tabControl.Name = "tabControl";
            this.tabControl.Padding = new System.Drawing.Point(6, 6);
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(710, 600);
            this.tabControl.TabIndex = 0;
            // 
            // chPage
            // 
            this.chPage.Controls.Add(this.newChBrowser);
            this.chPage.Location = new System.Drawing.Point(4, 28);
            this.chPage.Margin = new System.Windows.Forms.Padding(0);
            this.chPage.Name = "chPage";
            this.chPage.Size = new System.Drawing.Size(702, 568);
            this.chPage.TabIndex = 0;
            this.chPage.Text = "2chブラウザ";
            this.chPage.UseVisualStyleBackColor = true;
            // 
            // newChBrowser
            // 
            this.newChBrowser.AutoScroll = true;
            this.newChBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.newChBrowser.Location = new System.Drawing.Point(0, 0);
            this.newChBrowser.Margin = new System.Windows.Forms.Padding(0);
            this.newChBrowser.Name = "newChBrowser";
            this.newChBrowser.Size = new System.Drawing.Size(702, 568);
            this.newChBrowser.TabIndex = 1;
            // 
            // twiLivePage
            // 
            this.twiLivePage.Controls.Add(this.twitterBrowseControl1);
            this.twiLivePage.Location = new System.Drawing.Point(4, 28);
            this.twiLivePage.Name = "twiLivePage";
            this.twiLivePage.Padding = new System.Windows.Forms.Padding(3);
            this.twiLivePage.Size = new System.Drawing.Size(702, 568);
            this.twiLivePage.TabIndex = 1;
            this.twiLivePage.Text = "Twitter実況";
            this.twiLivePage.UseVisualStyleBackColor = true;
            // 
            // twitterBrowseControl1
            // 
            this.twitterBrowseControl1.Location = new System.Drawing.Point(0, 0);
            this.twitterBrowseControl1.Margin = new System.Windows.Forms.Padding(0);
            this.twitterBrowseControl1.Name = "twitterBrowseControl1";
            this.twitterBrowseControl1.Size = new System.Drawing.Size(700, 550);
            this.twitterBrowseControl1.TabIndex = 0;
            // 
            // mailPage
            // 
            this.mailPage.Controls.Add(this.mailControl1);
            this.mailPage.Location = new System.Drawing.Point(4, 28);
            this.mailPage.Name = "mailPage";
            this.mailPage.Padding = new System.Windows.Forms.Padding(3);
            this.mailPage.Size = new System.Drawing.Size(702, 568);
            this.mailPage.TabIndex = 3;
            this.mailPage.Text = "メール送信";
            this.mailPage.UseVisualStyleBackColor = true;
            // 
            // mailControl1
            // 
            this.mailControl1.Location = new System.Drawing.Point(0, 0);
            this.mailControl1.Name = "mailControl1";
            this.mailControl1.Size = new System.Drawing.Size(700, 550);
            this.mailControl1.TabIndex = 0;
            // 
            // timeTablePage
            // 
            this.timeTablePage.Controls.Add(this.timeTableControl1);
            this.timeTablePage.Location = new System.Drawing.Point(4, 28);
            this.timeTablePage.Name = "timeTablePage";
            this.timeTablePage.Padding = new System.Windows.Forms.Padding(3);
            this.timeTablePage.Size = new System.Drawing.Size(702, 568);
            this.timeTablePage.TabIndex = 4;
            this.timeTablePage.Text = "番組表";
            this.timeTablePage.UseVisualStyleBackColor = true;
            // 
            // timeTableControl1
            // 
            this.timeTableControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.timeTableControl1.Location = new System.Drawing.Point(3, 3);
            this.timeTableControl1.Name = "timeTableControl1";
            this.timeTableControl1.OpenMail = null;
            this.timeTableControl1.Size = new System.Drawing.Size(696, 562);
            this.timeTableControl1.TabIndex = 0;
            // 
            // settingPage
            // 
            this.settingPage.Controls.Add(this.settingPanel1);
            this.settingPage.Location = new System.Drawing.Point(4, 28);
            this.settingPage.Name = "settingPage";
            this.settingPage.Size = new System.Drawing.Size(702, 568);
            this.settingPage.TabIndex = 2;
            this.settingPage.Text = "設定";
            this.settingPage.UseVisualStyleBackColor = true;
            // 
            // settingPanel1
            // 
            this.settingPanel1._ReconnectProc = null;
            this.settingPanel1._SettingProc = null;
            this.settingPanel1.Location = new System.Drawing.Point(0, 0);
            this.settingPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.settingPanel1.Name = "settingPanel1";
            this.settingPanel1.Size = new System.Drawing.Size(550, 500);
            this.settingPanel1.TabIndex = 0;
            // 
            // liveControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "liveControl";
            this.Size = new System.Drawing.Size(710, 600);
            this.tabControl.ResumeLayout(false);
            this.chPage.ResumeLayout(false);
            this.twiLivePage.ResumeLayout(false);
            this.mailPage.ResumeLayout(false);
            this.timeTablePage.ResumeLayout(false);
            this.settingPage.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage chPage;
        private System.Windows.Forms.TabPage twiLivePage;
        private System.Windows.Forms.TabPage settingPage;
        private System.Windows.Forms.TabPage mailPage;
        private System.Windows.Forms.TabPage timeTablePage;
        private AGApp.Control.Parts.TwitterControl twitterBrowseControl1;
        private AGApp.Control.Browse.newChBrowser newChBrowser;
        private Parts.SettingControl settingPanel1;
        private AGApp.Control.Parts.MailControl mailControl1;
        private AGApp.Control.Parts.TimeTableControl timeTableControl1;
    }
}
