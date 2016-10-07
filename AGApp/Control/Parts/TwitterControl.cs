using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using AGApp.Proc;
using AGApp.Dialog;

namespace AGApp.Control.Parts
{
    public partial class TwitterControl : UserControl
    {
        #region [ 定数 ]

        /// <summary>
        /// Twitterロード設定
        /// </summary>
        private enum TwitterLoad
        {
            Load,
            Unload
        }

        #endregion

        #region [ プライベートインスタンス ]

        /// <summary>
        /// Twitter処理
        /// </summary>
        private OAuthProc m_authProc = null;

        /// <summary>
        /// twitter取得データ
        /// </summary>
        private List<TwitData> m_twitData = new List<TwitData>();

        /// <summary>
        /// 取得ツイート最大id
        /// </summary>
        private string m_strMaxId = string.Empty;

        /// <summary>
        /// エラーメッセージ
        /// </summary>
        private string m_strErrMsg = string.Empty;

        #endregion

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public TwitterControl()
        {
            InitializeComponent();
            // Tag設定
            this.autoLoadOKButton.Tag = TwitterLoad.Load;
            this.autoLoadNGButton.Tag = TwitterLoad.Unload;
            this.viewContentsAgqrButton.Tag = SettingData.TwitterView.AGQR;
            this.viewContentsTLButton.Tag = SettingData.TwitterView.TIMELINE;

            // ツイート初期化
            this.m_strMaxId = string.Empty;

            // 処理クラス設定
            this.m_authProc = new OAuthProc(DataManager.GetNowTwitterData());

            changeSettingItem(true);

            this.TimeLineLabel.Text = DataManager._SettingData._TwitterView == SettingData.TwitterView.AGQR ?
                "#agqr 実況" : "自分のタイムライン";
        }


        #region [ コントロールイベント ]

        /// <summary>
        /// タイマーにおける自動更新処理
        /// </summary>
        /// <param name="sender">オブジェクト</param>
        /// <param name="e">イベント</param>
        private void timer_Tick(object sender, EventArgs e)
        {
            getTwit();
            setTwit();
        }

        /// <summary>
        /// ツイート
        /// </summary>
        /// <param name="sender">オブジェクト</param>
        /// <param name="e">イベント</param>
        private void postButton_Click(object sender, EventArgs e)
        {
            this.postButton.Enabled = false;

            // ツイート
            OAuthProc proc = new OAuthProc(DataManager.GetNowTwitterData());
            proc.PostTwit(this.postTextBox.Text + " #agqr");
            
            // 1秒停止
            System.Threading.Thread.Sleep(1000);
            // ツイート後取得
            getTwit();
            setTwit();

            // 自信のついーとを消去
            this.postTextBox.Text = string.Empty;

            this.postButton.Enabled = true;
        }

        /// <summary>
        /// 更新ボタン押下時イベント
        /// </summary>
        /// <param name="sender">オブジェクト</param>
        /// <param name="e">イベント</param>
        private void updtButton_Click(object sender, EventArgs e)
        {
            getTwit();
            setTwit();
        }

        /// <summary>
        /// 手動ロードボタン押下時イベント
        /// </summary>
        /// <param name="sender">オブジェクト</param>
        /// <param name="e">イベント</param>
        private void manualLoadButton_Click(object sender, EventArgs e)
        {
            getTwit();
            setTwit();
        }


        /// <summary>
        /// 自動ロード変更ボタン押下時イベント
        /// </summary>
        /// <param name="sender">オブジェクト</param>
        /// <param name="e">イベント</param>
        private void autoLoadButton_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            DataManager._SettingData._TwitterLoad = (TwitterLoad)b.Tag == TwitterLoad.Load ? true : false;

            // 設定ファイル書込み
            FileProc.SetSettingData(DataManager._SettingData);
            // 画面変更
            changeSettingItem();
        }

        /// <summary>
        /// Twitterデータ設定ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void settingButton_Click(object sender, EventArgs e)
        {
            using (TwitterLoginDialog dialog = new TwitterLoginDialog())
            {
                dialog.ShowDialog();
            }
            this.m_authProc._OAuthData = DataManager.GetNowTwitterData();
        }

        /// <summary>
        /// agqr・TL切替設定ボタン
        /// </summary>
        /// <param name="sender">オブジェクト</param>
        /// <param name="e">イベント</param>
        private void viewContentsButton_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            DataManager._SettingData._TwitterView = (SettingData.TwitterView)b.Tag;

            this.TimeLineLabel.Text = DataManager._SettingData._TwitterView == SettingData.TwitterView.AGQR ?
                "#agqr 実況" : "自分のタイムライン";

            this.dataGridView.Rows.Clear();

            // ツイート初期化
            this.m_strMaxId = string.Empty;

            // 設定ファイル書込み
            FileProc.SetSettingData(DataManager._SettingData);
            // 画面変更
            changeSettingItem();
        }

        #endregion

        #region [ プライベートメソッド ]

        /// <summary>
        /// 設定アイテム変更処理
        /// <param name="initFlg">初期化フラグ</param>
        /// </summary>
        private void changeSettingItem(bool initFlg = false)
        {
            // 画面設定
            this.autoLoadOKButton.Enabled = DataManager._SettingData._TwitterLoad ? false : true;
            this.autoLoadNGButton.Enabled = DataManager._SettingData._TwitterLoad ? true : false;
            this.autoLoadOKButton.BackColor = this.autoLoadOKButton.Enabled ? 
                SystemColors.Control : Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.autoLoadNGButton.BackColor = this.autoLoadNGButton.Enabled ?
                SystemColors.Control : Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.viewContentsAgqrButton.Enabled = DataManager._SettingData._TwitterView == SettingData.TwitterView.AGQR ? false : true;
            this.viewContentsAgqrButton.BackColor = this.viewContentsAgqrButton.Enabled ?
                SystemColors.Control : Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.viewContentsTLButton.Enabled = DataManager._SettingData._TwitterView == SettingData.TwitterView.TIMELINE ? false : true;
            this.viewContentsTLButton.BackColor = this.viewContentsTLButton.Enabled ?
                SystemColors.Control : Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));

            // 処理
            if (DataManager._SettingData._TwitterLoad)
            {
                this.dataGridView.Rows.Clear();
                // タイマ実行（30秒間隔）
                this.timer.Interval = 30000;
                this.timer.Enabled = true;
                // ツイート後取得
                bool result = getTwit();
                if (result)
                    setTwit();
                // 初期化時以外が処理対象
                else if (!initFlg)
                {
                    MessageBox.Show(this.m_strErrMsg, "ERROR");
                    this.m_strErrMsg = string.Empty;
                }
            }
            else
                // タイマストップ
                this.timer.Enabled = false;
        }


        /// <summary>
        /// ツイート取得処理
        /// </summary>
        private bool getTwit()
        {
            // ユーザがあるかを確認
            if (DataManager.GetNowTwitterData() == null)
            {
                this.timer.Enabled = false;
                this.m_strErrMsg = "対象となるTwitterアカウントが登録・承認されていません";
                return false;
            }

            // タイムライン取得
            this.m_twitData = new List<TwitData>();
            bool result = DataManager._SettingData._TwitterView == SettingData.TwitterView.TIMELINE ? 
                this.m_authProc.GetTimeLine(ref this.m_twitData) : this.m_authProc.GetSearchLine(ref this.m_twitData, this.m_strMaxId);
            if (!result)
            {
                this.timer.Enabled = false;
                this.m_strErrMsg = this.m_authProc._ErrMsg;
                return false;
            }
            return true;
        }

        /// <summary>
        /// ツイート設定
        /// </summary>
        private void setTwit()
        {
            // 件数確認
            if (this.m_twitData.Count > 0)
            {
                // MaxIdを取得しておく
                this.m_strMaxId = this.m_twitData[0]._TwitId;
            }
            // 取得検索ツイート追加
            int iIdx, iIdx2 = 0;
            for (iIdx = 0; iIdx < this.m_twitData.Count; iIdx++)
            {
                var data = this.m_twitData[iIdx];
                this.dataGridView.Rows.Insert(iIdx, new string[] { data._User._Name, data._Twit });
            }
            // 取得済み検索ツイートはグレーアウト
            for (iIdx2 = iIdx; iIdx2 < this.dataGridView.Rows.Count; iIdx2++)
            {
                this.dataGridView.Rows[iIdx2].DefaultCellStyle.BackColor = Color.Gray;
            }
        }

        #endregion

    }
}
