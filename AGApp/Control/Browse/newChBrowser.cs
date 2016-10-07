using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Threading;
using AGApp.Properties;
using Microsoft.Win32;
using System.Net;
using AGApp.Control.Parts;


namespace AGApp.Control.Browse
{
    public partial class newChBrowser : UserControl
    {
        #region [ プライベート定数 ]

        private enum ZoomReduceIdx
        {
            Zoom,
            Reduce
        }

        /// <summary>
        /// カレントパス
        /// </summary>
        private const string RegistKeyCurrent = @"AppEvents\Schemes\Apps\Explorer\Navigating\.Current";

        /// <summary>
        /// デフォルトパス
        /// </summary>
        private const string RegistKeyDefault = @"AppEvents\Schemes\Apps\Explorer\Navigating\.Default";

        /// <summary>
        /// アクセスタイマー上限
        /// </summary>
        private const int AccessTimerUpper = 60;

        /// <summary>
        /// ページ移動時待ち時間（ミリ秒）
        /// </summary>
        private const int PageMoveWaitTime = 500;

        /// <summary>
        /// InternetExplorerのオープン待ち時間（ミリ秒）
        /// </summary>
        private const int InternetExplorerWaitTime = 2000;

        /// <summary>
        /// ループ回数
        /// </summary>
        public const int LoopMax = 3;


        #endregion

        #region [ プライベートインスタンス ]

        /// <summary>
        /// 次の遷移先
        /// </summary>
        private string m_strNextNavi = string.Empty;

        /// <summary>
        /// ロード済みURL
        /// </summary>
        private string m_strLoadURL = string.Empty;

        /// <summary>
        /// リンククリックのURL
        /// </summary>
        private string m_strClickLink = string.Empty;

        /// <summary>
        /// ズーム比率
        /// </summary>
        private int m_iZoom = 100;

        /// <summary>
        /// リンクリスト
        /// </summary>
        private List<string> m_lstLinkData = new List<string>();

        /// <summary>
        /// 表示コメントリスト
        /// </summary>
        private Dictionary<int, chData> m_chData = new Dictionary<int, chData>();

        /// <summary>
        /// 表示位置（X）
        /// </summary>
        private int m_iLocationX = 0;

        /// <summary>
        /// 表示位置（Y）
        /// </summary>
        private int m_iLocationY = 0;

        #endregion

        #region [ アクセサ ]

        /// <summary>
        /// X
        /// </summary>
        public int LocationX
        {
            set
            {
                this.m_iLocationX = value;
            }
        }

        /// <summary>
        /// Y
        /// </summary>
        public int LocationY
        {
            set
            {
                this.m_iLocationY = value;
            }
        }

        #endregion

        #region [ コンストラクタ・デストラクタ ]

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public newChBrowser()
        {
            InitializeComponent();
        }

        #endregion

        #region [ パブリックメソッド ]

        /// <summary>
        /// ロード処理
        /// </summary>
        public void onLoad()
        {
            this.AutoScroll = true;
            setTitleList();
            // イベントを付加
            this.chWebBrowser.Navigate("about:blank");
            this.chWebBrowser.Document.Click += new HtmlElementEventHandler(Document_Click);

            // 表示時設定
            this.waitLabel.Text = "表示比率：100%";
            this.trackBar.Value = 50;

        }

        #endregion

        #region [ コントロールイベント ]

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
        }

        /// <summary>
        /// ドキュメント読み込み完了イベント
        /// </summary>
        /// <param name="sender">オブジェクト</param>
        /// <param name="e">イベント</param>
        private void chWebBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            // zoom比率を維持
            this.chWebBrowser.Document.Body.Style = "zoom:" + this.m_iZoom.ToString() + "%";
        }

        /// <summary>
        /// 更新クリックイベント
        /// </summary>
        /// <param name="sender">オブジェクト</param>
        /// <param name="e">イベント</param>
        private void updateButton_Click(object sender, EventArgs e)
        {
            setTitleList();
        }

        /// <summary>
        /// トラックバースクロールイベント
        /// </summary>
        /// <param name="sender">オブジェクト</param>
        /// <param name="e">イベント</param>
        private void trackBar_Scroll(object sender, EventArgs e)
        {
            this.m_iZoom = this.trackBar.Value * 2;
            this.chWebBrowser.Document.Body.Style = "zoom:" + this.m_iZoom.ToString() + "%";
            this.waitLabel.Text = "表示比率：" + this.m_iZoom.ToString() + "%";
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

            // リンクをクリックしたときにリンク先を取得する
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

            // アンカーなら
            string strID = string.Empty;
            if (checkAncor(text, ref strID))
            {
                // リンク移動はキャンセル
                e.ReturnValue = false;
                // ID先のテキストを検索
                chData chData = new chData();
                if (this.m_chData.TryGetValue(int.Parse(strID), out chData))
                {
                    // tooltipに表示
                    List<string> lstData = new List<string>();
                    lstData.Add(getViewComment(strID, chData));
                    using (MyToolTip tip = new MyToolTip(lstData))
                    {
                        // 座標
                        Point p = System.Windows.Forms.Control.MousePosition;
                        // クリック位置
                        tip.ShowDialog(p.X,p.Y);
                    }
                }
            }
            // リンクが番号なら
            else if (checkNumber(text))
            {
                // リンク移動はキャンセル
                e.ReturnValue = false;
                // idのリンク先を回収
                List<string> lstData = getThreadNoData(int.Parse(text));
                if (lstData.Count > 0)
                {
                    // tip表示1
                    using (MyToolTip tip = new MyToolTip(lstData))
                    {
                        tip.Owner = (Form)this.ParentForm;
                        // 親ウインドウのXY位置
                        // コントロールのXY位置
                        // クリック位置
                        tip.ShowDialog(e.MousePosition.X + this.m_iLocationX + this.chWebBrowser.Location.X,
                            e.MousePosition.Y + this.m_iLocationY + this.chWebBrowser.Location.Y);
                    }
                }
            }
            // IDのクリックなら
            else if (checkID(text))
            {
                // リンク移動はキャンセル
                e.ReturnValue = false;
                // idのダブりを回収
                List<string> lstData = getIDData(text);
                if (lstData.Count > 0)
                {
                    // tip表示1
                    using (MyToolTip tip = new MyToolTip(lstData))
                    {
                        tip.Owner = (Form)this.ParentForm;
                        // 親ウインドウのXY位置
                        // コントロールのXY位置
                        // クリック位置
                        tip.ShowDialog(e.MousePosition.X + this.m_iLocationX + this.chWebBrowser.Location.X,
                            e.MousePosition.Y + this.m_iLocationY + this.chWebBrowser.Location.Y);
                    }
                }
            }
            // メールリンクなら起動はしない
            else if (link.IndexOf("mailto:") >= 0)
            {
                // リンク移動はキャンセル
                e.ReturnValue = false;
            }
            // リンク先が取得できたら
            else if (link != string.Empty)
            {
                //this.m_strClickLink = link;

                // リンク移動はキャンセル
                //e.ReturnValue = false;
                // 代わりにブラウザは外だし
                //BrowserDialog dialog = new BrowserDialog(this.m_strClickLink);
                //dialog.Show();
            }
        }

        /// <summary>
        /// 更新ボタン押下時処理
        /// </summary>
        /// <param name="sender">オブジェクト</param>
        /// <param name="e">イベント</param>
        private void updateThreadButton_Click(object sender, EventArgs e)
        {
            if (this.m_strLoadURL != string.Empty)
            {
                // スクロールポジションの確保
                int iTop = this.chWebBrowser.Document.Body.ScrollTop;
                int iLeft = this.chWebBrowser.Document.Body.ScrollLeft;
                this.stateTextBox.Text = "スレッド再読み込み中";
                this.stateTextBox.Refresh();
                loadThreadData();
                this.stateTextBox.Text = "スレッド再読み込み完了";
                this.stateTextBox.Refresh();
                this.chWebBrowser.Document.Body.ScrollLeft = iLeft;
                this.chWebBrowser.Document.Body.ScrollTop = iTop;
            }
        }

        /// <summary>
        /// 読み込みボタン押下時
        /// </summary>
        /// <param name="sender">オブジェクト</param>
        /// <param name="e">イベント</param>
        private void readButton_Click(object sender, EventArgs e)
        {
            // 現在選択されている項目を取得
            if (this.titleListBox.SelectedIndex >= 0)
            {
                this.stateTextBox.Text = "スレッドロード中";
                this.stateTextBox.Refresh();
                // ロード済みURLを取得しておく
                this.m_strLoadURL = this.m_lstLinkData[this.titleListBox.SelectedIndex];
                loadThreadData();
                this.stateTextBox.Text = "スレッドロード完了";
                this.stateTextBox.Refresh();
            }
            else
            {
                this.stateTextBox.Text = "ロードするスレッドを選択してください";
                this.stateTextBox.Refresh();
            }
        }


        #endregion

        /// <summary>
        /// スレッドデータ置き換え
        /// </summary>
        private void loadThreadData()
        {
            WebClient wc = new WebClient();
            wc.Proxy = null;
            wc.Encoding = System.Text.Encoding.GetEncoding("Shift_JIS");
            string html = wc.DownloadString(this.m_strLoadURL);
            wc.Dispose();

            // アンカー置き換え
            string strReplace = html.Replace("&gt;", ">");
            // データを解析しておく
            analyze(strReplace);
            // 表示側に反映
            this.chWebBrowser.Document.OpenNew(true);
            // アンカー置き換え
            this.chWebBrowser.Document.Write(changeLink(html));
        }

        /// <summary>
        /// アンカーチェック
        /// </summary>
        /// <param name="strID">対象文字列</param>
        /// <param name="strNum">番号</param>
        /// <returns>true=対象、false=非対象</returns>
        private bool checkAncor(string strID, ref string strNum)
        {
            Regex regex = new Regex("^>>[0-9]{1,4}$");
            if (regex.IsMatch(strID))
            {
                string[] strSplit = strID.Split(new string[] { ">>" }, StringSplitOptions.RemoveEmptyEntries);
                strNum = strSplit[0];
                return true;
            }
            return false;
        }

        /// <summary>
        /// スレッド番号チェック
        /// </summary>
        /// <param name="strNum">番号</param>
        /// <returns>true=対象、false=非対象</returns>
        private bool checkNumber(string strNum)
        {
            Regex regex = new Regex("^[0-9]{1,4}$");
            if (regex.IsMatch(strNum))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// ID番号チェック
        /// </summary>
        /// <param name="strID">ID</param>
        /// <returns>true=OK, false=NG</returns>
        private bool checkID(string strID)
        {
            // 2chIDは半角英数字と+/の出現のみ。桁数は8か9
            Regex regex = new Regex("^[0-9a-zA-Z+/]{8,9}$");
            if (regex.IsMatch(strID))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// リンク差し替え
        /// </summary>
        /// <param name="strHtml">html</param>
        /// <returns>差し替え後html</returns>
        private string changeLink(string strHtml)
        {
            StringBuilder sb = new StringBuilder();
            // まずは1スレッドずつ分割する
            string[] strSplit = strHtml.Split(new string[] { "<dt>", "</dl>" }, StringSplitOptions.RemoveEmptyEntries);
            // スレッド前は変更なし
            sb.Append(strSplit[0]);
            // スレッド番号をリンク化
            for (int iIdx = 1; iIdx < strSplit.Length - 1; iIdx++)
            {
                // スレ番号を取得
                string[] strThread = strSplit[iIdx].Split(new char[] { '：' }, StringSplitOptions.RemoveEmptyEntries);
                int iNo = int.Parse(strThread[0]);
                // idを取得
                string strID = this.m_chData[iNo].ID;
                StringBuilder sbBuf = new StringBuilder();
                // スレッド番号をリンクにおき直し
                sbBuf.Append("<dt><a href=\"");
                sbBuf.Append(iNo.ToString());
                sbBuf.Append("\">");
                sbBuf.Append(iNo.ToString());
                sbBuf.Append("</a> ");
                // 残りをいったん連結
                for (int iTh = 1; iTh < strThread.Length; iTh++)
                {
                    sbBuf.Append("：");
                    sbBuf.Append(strThread[iTh]);
                }
                sbBuf.Append("\n");

                // IDを置きなおす
                sbBuf = sbBuf.Replace(" ID:" + strID, " ID:<a href=\"" + strID + "\">" + strID + "</a>");
                // 置き直し後バッファに追加
                sb.Append(sbBuf);
            }
            sb.Append("</dl>");
            sb.Append(strSplit[strSplit.Length - 1]);
            return sb.ToString();
        }

        /// <summary>
        /// 解析
        /// </summary>
        /// <param name="strHTML">html</param>
        private void analyze(string strHTML)
        {
            // コメントと名前の
            this.m_chData = new Dictionary<int, chData>();

            // まずは1スレッドずつ分割する
            string[] strSplit = strHTML.Split(new string[] { "<dt>" }, StringSplitOptions.RemoveEmptyEntries);

            for (int iIdx = 1; iIdx < strSplit.Length; iIdx++)
            {
                chData chData = new chData();
                // スレ番号を取得
                string[] strThread = strSplit[iIdx].Split(new char[] { '：' }, StringSplitOptions.RemoveEmptyEntries);
                int iNo = int.Parse(strThread[0]);

                // 名前設定
                string[] strName = strSplit[iIdx].Split(new string[] { "<b>", "</b>" }, StringSplitOptions.RemoveEmptyEntries);
                if (strName.Length == 3)
                {
                    chData.Name = strName[1];
                }

                // 年月日設定
                string[] strYMD = strSplit[iIdx].Split(new string[]{"</a>：", "<dd>"}, StringSplitOptions.RemoveEmptyEntries);
                if (strYMD.Length == 3)
                {
                    chData.YMD = strYMD[1];
                }

                // ID設定
                string[] strBuf = strSplit[iIdx].Split(new string[] { "<dd>" }, StringSplitOptions.RemoveEmptyEntries);
                if (strBuf.Length >= 2)
                {
                    string[] strID = strBuf[0].Split(new string[] { "ID:" }, StringSplitOptions.RemoveEmptyEntries);
                    chData.ID = strID[strID.Length - 1];
                }

                // スレッド内容を取得
                string[] strData = strSplit[iIdx].Split(new string[] { "<dd>", "<br><br>" }, StringSplitOptions.RemoveEmptyEntries);
                chData.Comment = strData[1];
                this.m_chData.Add(iNo, chData);
            }
        }

        /// <summary>
        /// 実況板タイトルリスト設定
        /// </summary>
        private void setTitleList()
        {
            // 項目消去
            this.titleListBox.Items.Clear();

            // ステータス
            this.stateTextBox.Text = "実況板スレッド一覧取得中";
            this.stateTextBox.Refresh();
            this.m_lstLinkData.Clear();

            WebClient wc = new WebClient();
            wc.Proxy = null;

            // 接続失敗時エラー処理
            try
            {
                string html = wc.DownloadString(@"http://hayabusa2.2ch.net/liveradio/subback.html");
                wc.Dispose();

                string[] strLinkList = html.Split(new string[] { "<small id=\"trad\">", "</small>" }, StringSplitOptions.RemoveEmptyEntries);

                // リンクの一覧リストを作成する
                if (strLinkList.Length > 3)
                {
                    string strLink = strLinkList[2];

                    string[] strSpit = strLink.Split(new string[] { "</a>", "</A> ", "</A>" }, StringSplitOptions.RemoveEmptyEntries);
                    for (int iIdx = 0; iIdx < strSpit.Length; iIdx++)
                    {
                        Console.WriteLine(strSpit[iIdx].Trim('\n'));
                        string[] strBuf = strSpit[iIdx].Trim('\n').Split(new string[] { "<A href=\"", "<a href=\"", "\">" }, StringSplitOptions.RemoveEmptyEntries);
                        if (strBuf.Length == 2)
                        {
                            // リンクとタイトルのリストを作成する
                            string[] strID = strBuf[0].Split(new char[] { '/' });
                            this.m_lstLinkData.Add("http://hayabusa2.2ch.net/test/read.cgi/liveradio/" + strID[0]);
                            this.titleListBox.Items.Add(strBuf[1]);
                        }
                    }
                }

                // ステータス
                this.stateTextBox.Text = "実況板スレッド一覧取得完了";
            }
            catch (Exception e)
            {
                this.stateTextBox.Text = "2ch実況掲示板接続エラー : " + e.Message;
            }
            finally
            {
                this.stateTextBox.Refresh();
            }
        }

        /// <summary>
        /// 関連スレッドデータ取得
        /// </summary>
        /// <param name="iNo">No</param>
        /// <returns>true=OK, fakse=NG</returns>
        private List<string> getThreadNoData(int iNo)
        {
            List<string> lstRet = new List<string>();
            // Noのリンクデータが存在するなら、そのデータは取得するべし

            // 全コメントなめなめ
            foreach (int iKey in this.m_chData.Keys)
            {
                chData chBuf = this.m_chData[iKey];
                int iCheck = chBuf.Comment.IndexOf(">>" + iNo.ToString() + "</a>");
                // あるのなら
                if (iCheck != -1)
                {
                    lstRet.Add(getViewComment(iKey.ToString(), chBuf));
                }
            }
            return lstRet;
        }

        /// <summary>
        /// 関連IDデータ取得
        /// </summary>
        /// <param name="strID">ID</param>
        /// <returns>true=OK, fakse=NG</returns>
        private List<string> getIDData(string strID)
        {
            List<string> lstRet = new List<string>();

            // 全コメントなめなめ
            foreach (int iKey in this.m_chData.Keys)
            {
                chData chBuf = this.m_chData[iKey];
                // IDが一致しているデータなら
                if (chBuf.ID == strID)
                {
                    lstRet.Add(getViewComment(iKey.ToString(), chBuf));
                }
            }
            return lstRet;
        }

        /// <summary>
        /// 表示コメント取得
        /// </summary>
        /// <param name="strID">id</param>
        /// <param name="chData">コメント</param>
        /// <returns>コメント</returns>
        private string getViewComment(string strID, chData chData)
        {
            return strID + ":" + chData.Name + "：" + chData.YMD + "<br> " + chData.Comment;
        }

    }

    #region [ データクラス ]

    class chData
    {
        #region [ プライベートインスタンス ]

        /// <summary>
        /// 名前
        /// </summary>
        private string m_strName = string.Empty;

        /// <summary>
        /// 年月日
        /// </summary>
        private string m_strYMD = string.Empty;

        /// <summary>
        /// ID
        /// </summary>
        private string m_strID = string.Empty;

        /// <summary>
        /// コメント
        /// </summary>
        private string m_strComment = string.Empty;

        #endregion

        #region [ アクセサ ]

        /// <summary>
        /// 名前
        /// </summary>
        public string Name
        {
            set
            {
                this.m_strName = value;
            }
            get
            {
                return this.m_strName;
            }
        }

        /// <summary>
        /// 年月日
        /// </summary>
        public string YMD
        {
            set
            {
                this.m_strYMD = value;
            }
            get
            {
                return this.m_strYMD;
            }
        }

        /// <summary>
        /// コメント
        /// </summary>
        public string Comment
        {
            set
            {
                this.m_strComment = value;
            }
            get
            {
                return this.m_strComment;
            }
        }

        /// <summary>
        /// ID
        /// </summary>
        public string ID
        {
            set
            {
                this.m_strID = value;
            }
            get
            {
                return this.m_strID;
            }
        }

        #endregion


        /// <summary>
        /// コンストラクタ
        /// </summary>
        public chData()
        {
        }
    }

    #endregion

}
