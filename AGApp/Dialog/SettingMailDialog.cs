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
    /// メール設定ダイアログ
    /// </summary>
    public partial class SettingMailDialog : BaseDialog
    {

        #region [ コンストラクタ ]

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public SettingMailDialog()
        {
            InitializeComponent();

            // コンボボックスの項目設定
            for (int iIdx = 0; iIdx < DataManager._MailDataList.Count; iIdx++)
            {
                this.mailComboBox.Items.Add(DataManager._MailDataList[iIdx]._Service);
            }

            // 先頭を選択
            if (this.mailComboBox.Items.Count > 0)
            {
                this.mailComboBox.SelectedIndex = 0;
            }
        }

        #endregion

        #region [ コントロールイベント ]


        /// <summary>
        /// コンボボックス変更時
        /// </summary>
        /// <param name="sender">オブジェクト</param>
        /// <param name="e">イベント</param>
        private void mailComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // テキストボックスはすべて初期化
            this.mailTextBox.Text = string.Empty;
            this.userTextBox.Text = string.Empty;
            this.passwordTextBox.Text = string.Empty;
            this.smtpTextBox.Text = string.Empty;
            this.portTextBox.Text = string.Empty;

            // オリジナルデータの場合
            MailData mailData = DataManager._MailDataList[this.mailComboBox.SelectedIndex];
            if (mailData._Service == "オリジナル")
            {
                // ポート番号とsmtpサーバ名を有効にする
                this.portTextBox.Enabled = true;
                this.smtpTextBox.Enabled = true;
            }
            else
            {
                // ポート番号とsmtpサーバ名を設定、無効にする
                this.portTextBox.Enabled = false;
                this.smtpTextBox.Enabled = false;
                this.portTextBox.Text = mailData._Port.ToString();
                this.smtpTextBox.Text = mailData._SMTPServer;
            }
            // デフォルト設定をする
            this.userTextBox.Text = mailData._Name;
            this.passwordTextBox.Text = mailData._Password;
            this.mailTextBox.Text = mailData._Mail;
        }

        /// <summary>
        /// 設定ボタン押下時イベント
        /// </summary>
        /// <param name="sender">オブジェクト</param>
        /// <param name="e">イベント</param>
        private void setButton_Click(object sender, EventArgs e)
        {
            int iOut = 0;
            if (!int.TryParse(this.portTextBox.Text, out iOut))
            {
                MessageBox.Show("ポート番号が適切ではありません。");
                return;
            }
            if (this.userTextBox.Text == string.Empty)
            {
                MessageBox.Show("ユーザ名が入力されていません");
                return;
            }
            if (this.passwordTextBox.Text == string.Empty)
            {
                MessageBox.Show("パスワードが入力されていません");
                return;
            }
            if (this.mailTextBox.Text == string.Empty)
            {
                MessageBox.Show("メールアドレスが入力されていません");
                return;
            }
            if (this.smtpTextBox.Text == string.Empty)
            {
                MessageBox.Show("SMTPサーバ名が入力されていません");
                return;
            }

            // 現在の選択を反映
            for (int iIdx = 0; iIdx < DataManager._MailDataList.Count; iIdx++)
            {
                // 選択が一致した場合
                if (iIdx == this.mailComboBox.SelectedIndex)
                {
                    // 使用フラグを立てて、画面情報を設定
                    DataManager._MailDataList[iIdx]._UseFlg = true;
                    DataManager._MailDataList[iIdx]._Port = iOut;
                    DataManager._MailDataList[iIdx]._Name = this.userTextBox.Text;
                    DataManager._MailDataList[iIdx]._Password = this.passwordTextBox.Text;
                    DataManager._MailDataList[iIdx]._Mail = this.mailTextBox.Text;
                    DataManager._MailDataList[iIdx]._SMTPServer = this.smtpTextBox.Text;  
                }
                else
                {
                    // 使用フラグをキャンセル
                    DataManager._MailDataList[iIdx]._UseFlg = false;
                }
            }

            this.DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// 中止ボタン押下時イベント
        /// </summary>
        /// <param name="sender">オブジェクト</param>
        /// <param name="e">イベント</param>
        private void stopButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        #endregion

        #region [ パブリックメソッド ]

        public void SettingScreenData()
        {
            for (int iIdx = 0; iIdx < DataManager._MailDataList.Count; iIdx++)
            {
                if (DataManager._MailDataList[iIdx]._UseFlg)
                {
                    this.mailComboBox.SelectedIndex = iIdx;
                    break;
                }
            }
        }

        #endregion
    }
}
