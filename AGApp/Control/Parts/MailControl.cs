using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AGApp.Dialog;
using AGApp.Proc;
using System.Net.Mail;

namespace AGApp.Control.Parts
{
    public partial class MailControl : UserControl
    {
        #region [ プライベート定数 ]

        /// <summary>
        /// 送信済みボックスフォルダパス
        /// </summary>
        private const string OutBox_Path = @"/Outbox/";

        /// <summary>
        /// TO:
        /// </summary>
        private const string ToStart = "To:";

        /// <summary>
        /// TITLE:
        /// </summary>
        private const string TitleStart = "Title:";

        /// <summary>
        /// NSG:
        /// </summary>
        private const string MsgStart = "Msg:";

        #endregion

        #region [ プライベートインスタンス ]

        /// <summary>
        /// メール送信情報
        /// </summary>
        private string m_strInfo = string.Empty;

        #endregion


        /// <summary>
        /// コンストラクタ
        /// </summary>
        public MailControl()
        {
            InitializeComponent();
        }

        # region [イベント処理]

        /// <summary>
        /// ロード時処理
        /// </summary>
        /// <param name="sender">オブジェクト</param>
        /// <param name="e">イベント</param>
        private void MailControl_Load(object sender, EventArgs e)
        {
            setScreenFromMail();
        }

        /// <summary>
        /// 送信元情報設定
        /// </summary>
        /// <param name="sender">オブジェクト</param>
        /// <param name="e">イベント</param>
        private void fromSettingButton_Click(object sender, EventArgs e)
        {
            openSettingMailDialog();
            setScreenFromMail();
        }

        /// <summary>
        /// Fromメールアドレス変更時
        /// </summary>
        /// <param name="sender">オブジェクト</param>
        /// <param name="e">イベント</param>
        private void fromComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 使用フラグの変更
            string service = this.fromComboBox.SelectedItem.ToString().Split(new char[]{'[',']'})[1];
            for (int i = 0; i <DataManager._MailDataList.Count;i++)
                DataManager._MailDataList[i]._UseFlg = DataManager._MailDataList[i]._Service == service ? true : false;

            // ファイル書き込み
            FileProc.SetMailTable(DataManager._MailDataList);
        }


        /// <summary>
        /// 添付ファイル付加ボタン押下イベント
        /// </summary>
        /// <param name="sender">オブジェクト</param>
        /// <param name="e">イベント</param>
        private void attachButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog fd = new OpenFileDialog())
            {
                if (fd.ShowDialog() == DialogResult.OK)
                    this.attach1Label.Text = fd.FileName;
            }
        }


        /// <summary>
        /// リセットボタン押下時イベント
        /// </summary>
        /// <param name="sender">オブジェクト</param>
        /// <param name="e">イベント</param>
        private void resetButton_Click(object sender, EventArgs e)
        {
            // メール本文の初期化
            this.titleTextBox.Text = string.Empty;
            this.msgTextBox.Text = string.Empty;
            this.toTextBox.Text = string.Empty;
            this.attach1Label.Text = string.Empty;
        }

        /// <summary>
        /// 送信ボタン押下イベント
        /// </summary>
        /// <param name="sender">オブジェクト</param>
        /// <param name="e">イベント</param>
        private void sendButton_Click(object sender, EventArgs e)
        {
            // 画面入力チェック
            bool check = string.IsNullOrEmpty(this.titleTextBox.Text) &
                         string.IsNullOrEmpty(this.toTextBox.Text) &
                         string.IsNullOrEmpty(DataManager.GetNowMailData()._Mail) &
                        string.IsNullOrEmpty(this.msgTextBox.Text);
            if (!check)
            {
                MessageBox.Show("未入力項目が存在します");
                return;
            }
            
            string strTitle = this.titleTextBox.Text;
            string strMsg = this.msgTextBox.Text;

            try
            {
                // 使用メール送信情報
                MailData maildata = DataManager.GetNowMailData();

                // メール送信
                //smtpサーバ名を設定
                SmtpClient client = new SmtpClient(maildata._SMTPServer);
                // ポート番号設定
                client.Port = maildata._Port;
                //ユーザー名とパスワードを設定する
                client.Credentials = new System.Net.NetworkCredential(maildata._Name, maildata._Password);
                //現在は、EnableSslがtrueでは失敗する
                client.EnableSsl = maildata._SSLFlg;
                // 送信データ設定
                client.Send(((Func<MailMessage>)(() =>
                {
                    MailMessage msg = new MailMessage();
                    msg.To.Add(this.toTextBox.Text);
                    msg.From = new MailAddress(maildata._Mail);
                    msg.Subject = strTitle;
                    msg.Body = strMsg;
                    if (!string.IsNullOrEmpty(this.attach1Label.Text))
                        msg.Attachments.Add(new Attachment(this.attach1Label.Text));
                    return msg;
                }))());

                // 保存チェックが入っているのなら
                if (this.saveCheckBox.Checked)
                {
                    // 送信メールを保存する
                    if (FileProc.SaveMailData(
                        ((Func<SendMailData>)(() =>
                        {
                            SendMailData smd = new SendMailData();
                            smd._Title = strTitle;
                            smd._Msg = strMsg;
                            smd._Dt = DateTime.Now;
                            smd._Info = this.m_strInfo + " ::: " + this.toTextBox.Text;
                            return smd;
                        }))()))
                        MessageBox.Show("メールの送信に成功しました。");
                }
                else
                    MessageBox.Show("メールの送信に成功しました。");
            }
            catch (Exception ex)
            {
                // 送信失敗時はクローズしないように修正
                // 現状復活させる
                MessageBox.Show("メールの送信に失敗しました。" + ex.Message);
            }

        }

        #endregion

        /// <summary>
        /// TOメールアドレス設定
        /// </summary>
        /// <param name="agdata"></param>
        public void SetToMail(AGData agdata)
        {
            this.toTextBox.Text = agdata._Mail;
            this.m_strInfo = agdata._Name;
        }

        /// <summary>
        /// TOメールアドレス設定
        /// </summary>
        /// <param name="mail"></param>
        public void SetToMail(string mail)
        {
            this.toTextBox.Text = mail;
        }

        #region [ プライベートメソッド ]

        /// <summary>
        /// メール設定
        /// </summary>
        /// <returns>bool</returns>
        private bool openSettingMailDialog()
        {
            // 戻り値
            bool blResult = true;

            // ダイアログ表示
            using (SettingMailDialog dialog = new SettingMailDialog())
            {
                dialog.SettingScreenData();

                // 設定なら
                if (dialog.ShowDialog() == DialogResult.OK)
                    // ファイル書き込み
                    if (!FileProc.SetMailTable(DataManager._MailDataList))
                        blResult = false;
                dialog.DialogClosed();
            }

            return blResult;
        }


        /// <summary>
        /// 画面設定(From)
        /// </summary>
        private void setScreenFromMail()
        {
            // メールの初期化を行う;
            this.fromComboBox.Items.Clear();

            // メール送信元の設定
            foreach (MailData data in DataManager._MailDataList)
            {
                if (!string.IsNullOrEmpty(data._Mail))
                {
                    this.fromComboBox.Items.Add(data._Mail + "  [" + data._Service + "]");

                    // 使用フラグのものは選択
                    if (data._UseFlg)
                        this.fromComboBox.SelectedItem = data._Mail + "  [" + data._Service + "]";
                }
            }

            // 送信元情報がなければ、操作できないようにする
            this.fromComboBox.Enabled = this.fromComboBox.Items.Count == 0 ? false : true;
        }

        #endregion


    }
}
