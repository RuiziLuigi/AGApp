using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using AGApp.Proc;

namespace AGApp.Dialog
{
    /// <summary>
    /// メールタブ起動デリゲート
    /// </summary>
    /// <param name="agdata"></param>
    public delegate void OpenMail(AGData agdata);

    public partial class TimeTableInfoDialog : BaseDialog
    {
        private OpenMail openMail;

        private AGData agData;


        #region [ コンストラクタ ]

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public TimeTableInfoDialog()
        {
            InitializeComponent();
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="agdata">Ａ＆Ｇ番組データ</param>
        /// <param name="openMail">メールアドレス展開処理</param>
        public TimeTableInfoDialog(AGData agdata, OpenMail openMail)
        {
            InitializeComponent();

            this.openMail = openMail;
            this.agData = agdata;

            this.timeLabel.Text = agdata._Time;
            this.nameLabel.Text = agdata._Name;
            this.mailLabel.Text = agdata._Mail;
            this.linkLabel.Text = agdata._Blog;
            
            // その他情報の連結
            this.infoLabel.Text = 
                ((Func<string>)( () => {
                    StringBuilder sb = new StringBuilder();

                    // 映像あり
                    sb.Append(agdata._Live ? " [生放送] " : "");
                    sb.Append(agdata._Repeat ? " [再放送] " : "");
                    sb.Append(agdata._Movie ? " [映像あり] " : "");

                    return sb.ToString();
                }))();
        }

        #endregion

        #region [ コントロールイベント ]

        /// <summary>
        /// OKボタン押下ダイアログ
        /// </summary>
        /// <param name="sender">オブジェクト</param>
        /// <param name="e">イベント</param>
        private void okButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// メールアドレスリンクラベルクリック時イベント
        /// </summary>
        /// <param name="sender">オブジェクト</param>
        /// <param name="e">イベント</param>
        private void mailLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.DialogResult = DialogResult.OK;

            // 自身を閉じて、リンクの文字列を有効にしてメールフォームを展開する。
            this.openMail(this.agData);
        }

        #endregion

    }
}
