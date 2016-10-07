using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using AGApp.Proc;
using Microsoft.Win32;

namespace AGApp.Control.Browse
{
    /// <summary>
    /// 番組情報タイマ
    /// </summary>
    /// <param name="strTitle">タイトル</param>
    /// <param name="strParson">人間</param>
    public delegate void TimerProc(string strTitle, string strParson);

    /// <summary>
    /// メールタブ起動デリゲート
    /// </summary>
    /// <param name="mail"></param>
    public delegate void OpenMailByAddress(string mail);


    public partial class infoBrowser : UserControl
    {
        /// <summary>
        /// タイマー処理デリゲート
        /// </summary>
        public TimerProc _TimerProc { set; get; }

        /// <summary>
        /// メールタブ起動
        /// </summary>
        public OpenMailByAddress OpenMailByAddress { set; get; }

        /// <summary>
        /// タイトル
        /// </summary>
        private string m_strInfoTitle = string.Empty;

        /// <summary>
        /// パーソナリティ
        /// </summary>
        private string m_strParson = string.Empty;

        /// <summary>
        /// 番組情報テキスト
        /// </summary>
        private string m_strInfoTxt = string.Empty;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public infoBrowser()
        {
            InitializeComponent();
            // タイマ設定（1分おき）
            this.timer.Interval = 60000;
            view();
        }

        /// <summary>
        /// 読込完了
        /// </summary>
        /// <param name="sender">オブジェクト</param>
        /// <param name="e">イベント</param>
        private void exWebBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            // タイマ停止
            this.timer.Enabled = false;
            // 番組情報の取得
            string strInfo1 = string.Empty;
            string strInfo2 = string.Empty;
            string strInfo3 = string.Empty;
            RTTimeTableProc.GetRealTimeData(out strInfo1, out strInfo2, out strInfo3);
            this.m_strInfoTitle = strInfo1;
            this.m_strParson = strInfo3;
            // 番組ラベル指定
            StringBuilder sb = new StringBuilder();
            sb.Append("<html>");
            sb.Append("<body bgcolor=\"#F0F0F0\">");
            sb.Append("<p>【番組名】" + strInfo1 + "<br />");
            sb.Append("【パーソナリティ】" + strInfo3 + "<br />");
            sb.Append("【番組説明】" + strInfo2);
            sb.Append("</body></html>");

            if (!string.IsNullOrEmpty(this.m_strInfoTxt))
                if (!compareInfoText(this.m_strInfoTxt, sb.ToString()))
                    // ballon処理
                    _TimerProc(this.m_strInfoTitle, this.m_strParson);

            this.exWebBrowser.Document.Write(sb.ToString());
            // タイマ再開
            this.timer.Enabled = true;
        }


        /// <summary>
        /// タイマ経過
        /// </summary>
        /// <param name="sender">オブジェクト</param>
        /// <param name="e">イベント</param>
        private void timer_Tick(object sender, EventArgs e)
        {
            this.m_strInfoTxt = this.exWebBrowser.DocumentText;
            view();
        }

        /// <summary>
        /// 番組表表示
        /// </summary>
        /// <param name="blSound">TRUE=音ON、FALSE=音OFF</param>
        private void view()
        {
            // カチカチ音を消す
            RegistryKey key = Registry.CurrentUser;
            key = key.OpenSubKey(@"AppEvents\Schemes\Apps\Explorer\Navigating\.Current", true);
            key.SetValue(null, "");
            key.Close();

            // navigate
            this.exWebBrowser.Navigate("about:blank");

            // カチカチ音復活
            key = Registry.CurrentUser;
            key = key.OpenSubKey(@"AppEvents\Schemes\Apps\Explorer\Navigating\.Default");
            string data = (string)key.GetValue(null);
            key.Close();
            key = Registry.CurrentUser;
            key = key.OpenSubKey(@"AppEvents\Schemes\Apps\Explorer\Navigating\.Current", true);
            key.SetValue(null, data);
            key.Close();
        }

        /// <summary>
        /// 情報テキストの比較
        /// </summary>
        /// <param name="strBefore">更新前テキスト</param>
        /// <param name="strAfter">更新後テキスト</param>
        /// <returns>BOOL</returns>
        private bool compareInfoText(string strBefore, string strAfter)
        {
            // 処理
            if (!strBefore.Equals(strAfter))
                return false;
            return true;
        }

        /// <summary>
        /// ブラウザ遷移イベント
        /// </summary>
        /// <param name="sender">オブジェクト</param>
        /// <param name="e">イベント</param>
        private void exWebBrowser_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            // リンクにおいて、メールアドレスの場合はメール起動する
            if (!string.IsNullOrEmpty(e.Url.ToString()))
            {
                string mail =
                ((Func<string>)(() =>
                {
                    string[] tmp = e.Url.ToString().Split(':');
                    if (tmp.Length == 2 && tmp[0] == "mailto")
                        return tmp[1];
                    else
                        return string.Empty;
                }))();
                if (!string.IsNullOrEmpty(mail))
                {
                    this.OpenMailByAddress(mail);
                    e.Cancel = true;
                }
            }
        }
    }
}
