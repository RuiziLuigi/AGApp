using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Net;

namespace AGApp
{
    public partial class newChBUpper : UserControl
    {
        #region [ プライベートインスタンス ]

        /// <summary>
        /// リンクリスト
        /// </summary>
        private List<string> m_lstLinkData = new List<string>();

        #endregion

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public newChBUpper()
        {
            InitializeComponent();

            setTitleList();
        }

        #region [ コントロールイベント ]

        /// <summary>
        /// 更新クリックイベント
        /// </summary>
        /// <param name="sender">オブジェクト</param>
        /// <param name="e">イベント</param>
        private void updateButton_Click(object sender, EventArgs e)
        {
            setTitleList();
        }

        #endregion

        #region [ プライベートインスタンス ]

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

            WebClient wc = new WebClient();
            wc.Proxy = null;
            string html = wc.DownloadString(@"http://hayabusa2.2ch.net/liveradio/subback.html");
            wc.Dispose();

            string[] strLinkList = html.Split(new string[] { "<small id=\"trad\">", "</small>" }, StringSplitOptions.RemoveEmptyEntries);

            // リンクの一覧リストを作成する
            if (strLinkList.Length > 2)
            {
                string strLink = strLinkList[1];
                while (true)
                {
                    int iFind = strLink.IndexOf("\n");
                    // なくなれば
                    if (iFind < 0)
                    {
                        break;
                    }
                    strLink = strLink.Remove(iFind, 1);
                }


                string[] strSpit = strLink.Split(new string[] { "</a>", "</A> ", "</A>" }, StringSplitOptions.RemoveEmptyEntries);
                for (int iIdx = 0; iIdx < strSpit.Length; iIdx++)
                {
                    Console.WriteLine(strSpit[iIdx]);
                    string[] strBuf = strSpit[iIdx].Split(new string[] { "<A href=\"", "<a href=\"", "\">" }, StringSplitOptions.RemoveEmptyEntries);
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
            this.stateTextBox.Refresh();
        }

        #endregion
    }
}
