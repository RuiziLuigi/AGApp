namespace AGApp.Control.Browse
{
    partial class infoBrowser
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
            this.components = new System.ComponentModel.Container();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.exWebBrowser = new AGApp.ExWebBrowser();
            this.SuspendLayout();
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // exWebBrowser
            // 
            this.exWebBrowser.BeforeNavigateUrl = "about:blank";
            this.exWebBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.exWebBrowser.Location = new System.Drawing.Point(0, 0);
            this.exWebBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.exWebBrowser.Name = "exWebBrowser";
            this.exWebBrowser.ScriptErrorsSuppressed = true;
            this.exWebBrowser.ScrollBarsEnabled = false;
            this.exWebBrowser.Size = new System.Drawing.Size(380, 300);
            this.exWebBrowser.TabIndex = 7;
            this.exWebBrowser.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.exWebBrowser_DocumentCompleted);
            this.exWebBrowser.Navigating += new System.Windows.Forms.WebBrowserNavigatingEventHandler(this.exWebBrowser_Navigating);
            // 
            // infoBrowser
            // 
            this.AutoScroll = true;
            this.Controls.Add(this.exWebBrowser);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "infoBrowser";
            this.Size = new System.Drawing.Size(380, 300);
            this.ResumeLayout(false);

        }

        #endregion

        private ExWebBrowser exWebBrowser;
        private System.Windows.Forms.Timer timer;
    }
}
