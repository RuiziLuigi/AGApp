using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using AGApp.Properties;

namespace AGApp.Control.Browse
{
    public partial class chBrowser : UserControl
    {
        #region [ プライベート定数 ]

        private enum GoBackIdx
        {
            Go,
            Back
        }

        private enum ZoomReduceIdx
        {
            Zoom,
            Reduce
        }

        #endregion

        #region [ プライベートインスタンス ]

        /// <summary>
        /// 次の遷移先
        /// </summary>
        private string m_strNextNavi = string.Empty;

        /// <summary>
        /// リンククリックのURL
        /// </summary>
        private string m_strClickLink = string.Empty;

        /// <summary>
        /// ズーム比率
        /// </summary>
        private int m_iZoom = 100;

        #endregion

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public chBrowser()
        {
            InitializeComponent();
            this.AutoScroll = true;

            // ブラウザにイベントを加算
            this.chWebBrowser.CanGoBackChanged += new EventHandler(chWebBrowser_CanGoBackChanged);
            // タグ設定
            this.goButton.Tag = GoBackIdx.Go;
            this.backButton.Tag = GoBackIdx.Back;
            // とりあえず最初は無効
            this.backButton.Enabled = false;
            this.backButton.Image = Resources.e_left;

            // 2chブラウザ
            this.chWebBrowser.Navigate(@"http://hayabusa2.2ch.net/liveradio/");

            // 表示時設定
            this.waitLabel.Text = "表示比率：100%";
            this.trackBar.Value = 50;
        }

        /// <summary>
        /// デストラクタ
        /// </summary>
        ~chBrowser()
        {
            this.chWebBrowser.CanGoBackChanged -= chWebBrowser_CanGoBackChanged;
        }

        /// <summary>
        /// ページ移動
        /// </summary>
        /// <param name="strURL">URL</param>
        public void MovePage(string strURL)
        {
            this.chWebBrowser.Navigate(strURL);
        }

        /// <summary>
        /// ラジオ実況版クリック
        /// </summary>
        /// <param name="sender">オブジェクト</param>
        /// <param name="e">イベント</param>
        private void chButton_Click(object sender, EventArgs e)
        {
            // 2chブラウザに接続
            this.chWebBrowser.Navigate(@"http://hayabusa2.2ch.net/liveradio/");
            // キャッシュが残るので再更新処理
            this.chWebBrowser.Refresh();
        }

        /// <summary>
        /// 遷移前イベント
        /// </summary>
        /// <param name="sender">オブジェクト</param>
        /// <param name="e">イベント</param>
        private void chWebBrowser_BeforeNavigate(object sender, EventArgs e)
        {
            WebBrowserExtendedNavigatingEventArgs exE =
                    (WebBrowserExtendedNavigatingEventArgs)e;

            // リンク先取得
            this.m_strNextNavi = exE.Url;
            // 取得リンク
            Console.WriteLine("遷移前URL：" + this.m_strNextNavi);
        }

        /// <summary>
        /// 新しいウインドウを開くとき
        /// </summary>
        /// <param name="sender">オブジェクト</param>
        /// <param name="e">イベント</param>
        private void chWebBrowser_NewWindow(object sender, CancelEventArgs e)
        {
            // 新しいウインドウはキャンセルする
            e.Cancel = true;
            // リダイレクト
            this.chWebBrowser.Navigate(this.m_strClickLink);
        }

        /// <summary>
        /// 進む・戻すボタン
        /// </summary>
        /// <param name="sender">オブジェクト</param>
        /// <param name="e">イベント</param>
        private void backButton_Click(object sender, EventArgs e)
        {
            this.chWebBrowser.GoBack();
        }

        /// <summary>
        /// 進むボタン
        /// </summary>
        /// <param name="sender">オブジェクト</param>
        /// <param name="e">イベント</param>
        private void goButton_Click(object sender, EventArgs e)
        {
            if (this.urlTextBox.Text != string.Empty)
            {
                // 2chブラウザに接続
                this.chWebBrowser.Navigate(this.urlTextBox.Text);
            }
            else
            {
                this.chWebBrowser.GoForward();
            }
        }



        /// <summary>
        /// ドキュメント読み込み完了イベント
        /// </summary>
        /// <param name="sender">オブジェクト</param>
        /// <param name="e">イベント</param>
        private void chWebBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            // URLテキストに反映
            this.urlTextBox.Text = this.chWebBrowser.Url.ToString();
            // イベントを付加
            this.chWebBrowser.Document.Click += new HtmlElementEventHandler(Document_Click);
            // zoom比率を維持
            this.chWebBrowser.Document.Body.Style = "zoom:" + this.m_iZoom.ToString() + "%";
        }

        /// <summary>
        /// 元に戻る変更時イベント
        /// </summary>
        /// <param name="sender">オブジェクト</param>
        /// <param name="e">イベント</param>
        private void chWebBrowser_CanGoBackChanged(object sender, EventArgs e)
        {
            if (!this.chWebBrowser.CanGoBack)
            {
                this.backButton.Image = Resources.e_left;
                this.backButton.Enabled = false;
            }
            else
            {
                this.backButton.Image = Resources.left;
                this.backButton.Enabled = true;
            }

        }

        /// <summary>
        /// 更新クリックイベント
        /// </summary>
        /// <param name="sender">オブジェクト</param>
        /// <param name="e">イベント</param>
        private void updateButton_Click(object sender, EventArgs e)
        {
            // 2chブラウザの更新
            this.chWebBrowser.Refresh();
        }

        /// <summary>
        /// スクロール
        /// </summary>
        /// <param name="sender">オブジェクト</param>
        /// <param name="e">イベント</param>
        private void trackBar_Scroll(object sender, EventArgs e)
        {
            this.m_iZoom = this.trackBar.Value * 2;
            this.chWebBrowser.Document.Body.Style = "zoom:" + this.m_iZoom.ToString() + "%";
            this.waitLabel.Text = "表示比率："  + this.m_iZoom.ToString() + "%";
        }


        /// <summary>
        /// HTMLドキュメントクリック時イベント
        /// </summary>
        /// <param name="sender">オブジェクト</param>
        /// <param name="e">イベント</param>
        private void Document_Click(object sender, HtmlElementEventArgs e)
        {
            HtmlElement clickedElement = this.chWebBrowser.Document.GetElementFromPoint(e.MousePosition);
            string text = string.Empty;
            string link = string.Empty;

            if (clickedElement.TagName == "a" || clickedElement.TagName == "A")
            {
                text = clickedElement.OuterText;
                link = clickedElement.GetAttribute("href");
            }
            else if (clickedElement.Parent != null)
            {
                if (clickedElement.Parent.TagName == "a" || clickedElement.Parent.TagName == "A")
                {
                    text = clickedElement.Parent.OuterText;
                    link = clickedElement.Parent.GetAttribute("href");
                }
            }

            if (link != string.Empty && link != string.Empty)
            {
                try
                {
                    this.m_strClickLink = link;
                    //e.ReturnValue = false;
                }
                catch
                {
                }
            }
        }


    }
}
