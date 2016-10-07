using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace AGApp.Control.Parts
{
    public partial class MyToolTip : Form
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public MyToolTip(List<string> lstData)
        {
            InitializeComponent();

            int iSizeX = 0;
            int iSizeY = 5;

            for (int iIdx1 = 0; iIdx1 < lstData.Count; iIdx1++)
            {
                string[] strSplit = lstData[iIdx1].Split(new string[] { "<br>", "<br />" }, StringSplitOptions.None);
                // 最後の改行は無効にしたい
                for (int iLine = 0; iLine < strSplit.Length; iLine++)
                {
                    Label label = null;
                    // リンクがあるとき
                    if (linkCheck(strSplit[iLine]))
                    {
                        label = new MyLabel();
                        ((MyLabel)label).Text = strSplit[iLine];
                    }
                    else
                    {
                        label = new Label();
                        label.Text = strSplit[iLine];
                    }
                    label.AutoSize = true;
                    // 最大の幅を取得する
                    if (iSizeX < label.PreferredWidth)
                    {
                        iSizeX = label.PreferredWidth;
                    }
                    label.Location = new Point(5, iSizeY);
                    iSizeY += label.PreferredHeight;
                    // ラベルクリックのイベントハンドラもツールチップのイベントと併合する
                    label.Click += new EventHandler(MyToolTip_Click);
                    this.Controls.Add(label);
                }
                // レスを改行扱いする
                iSizeY += 12;
            }
            Size size = new Size();
            size.Width = iSizeX + 10;
            size.Height = iSizeY;
            this.Size = size;
        }

        /// <summary>
        /// 表示
        /// </summary>
        /// <param name="iX">X</param>
        /// <param name="iY">Y</param>
        public void ShowDialog(int iX, int iY)
        {
            this.StartPosition = FormStartPosition.Manual;
            this.DesktopLocation = new Point(this.Owner.Location.X + iX, this.Owner.Location.Y + iY);
            this.ShowDialog();
        }

        /// <summary>
        /// リンクチェック
        /// </summary>
        /// <param name="strText">検証テキスト</param>
        /// <returns>true=リンク、false=未リンク</returns>
        private bool linkCheck(string strText)
        {
            int iLinkS = strText.IndexOf("<a href");
            int iLinkE = strText.IndexOf("</a>");

            if (iLinkS == -1 && iLinkE == -1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// ツールチップクリック時イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MyToolTip_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.DialogResult = DialogResult.OK;
        }
    }

    /// <summary>
    /// マイラベル
    /// </summary>
    public class MyLabel : LinkLabel
    {
        public MyLabel()
            :base()
        {
        }

        public override string Text
        {
            set
            {
                setText(value);
            }
            get
            {
                return base.Text;
            }
        }

        /// <summary>
        /// 文字設定
        /// </summary>
        /// <param name="strText">文字列</param>
        private void setText(string strText)
        {
            while (true)
            {
                int iLinkS = strText.IndexOf("<a href");
                int iLinkE = strText.IndexOf("</a>");

                if (iLinkS == -1 && iLinkE == -1)
                {
                    base.Text = strText;
                    break;
                }
                // urlのみ抜出
                string strLink = strText.Substring(iLinkS, iLinkE + 4 - iLinkS);
                string[] strSplit = strLink.Split(new string[] { "<a href=\"", "\">", "</a>" }, StringSplitOptions.RemoveEmptyEntries);
                string strReplace = string.Empty;
                for (int iIdx = 1; iIdx < strSplit.Length; iIdx++)
                {
                    strReplace += strSplit[iIdx];
                }
                strText = strText.Replace(strLink, strReplace);
                this.Links.Add(new Link(iLinkS, strReplace.Length, strSplit[0]));
            }
        }
    }
}
