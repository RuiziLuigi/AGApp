using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using AGApp.Control.Browse;
using AGApp.Dialog;
using AGApp.Proc;
using AxShockwaveFlashObjects;
using Microsoft.Win32;

namespace AGApp
{
    /// <summary>
    /// 設定画面処理デリゲート
    /// </summary>
    public delegate void SettingProc();

    /// <summary>
    /// 再接続処理デリゲート
    /// </summary>
    public delegate void ReconnectProc();

    public partial class Form1 : Form
    {
        #region []
        private enum PostDataKey
        {
            AG_Ver = 0,
            Info_Ver,
            Live_Ver,
            AG_Hor,
            Info_Hor,
            Live_Hor
        }
        #endregion

        #region [ プライベート定数 ]

        /// <summary>
        /// Flashステータス
        /// </summary>
        private enum FlashState
        {
            /// <summary>
            /// 読込中
            /// </summary>
            Loading = 0,
            /// <summary>
            /// 初期化されていない
            /// </summary>
            Uninitialized,
            /// <summary>
            /// 読込完了
            /// </summary>
            Loaded,
            /// <summary>
            /// 相互操作可能
            /// </summary>
            Interactive,
            /// <summary>
            /// 完了
            /// </summary>
            Complete,
        }

        /// <summary>
        /// メニュー高さ
        /// </summary>
        private const int MENU_HEIGHT = 29;

        /// <summary>
        /// 縦置き、Formサイズ、高さ
        /// </summary>
        private const int VERTICAL_FORM_H = 915;

        /// <summary>
        /// 縦置き、Formサイズ、幅
        /// </summary>
        private const int VERTICAL_FORM_W = 860;

        /// <summary>
        /// 横置き、Formサイズ、高さ
        /// </summary>
        private const int HORIZONTAL_FORM_H = 600;

        /// <summary>
        /// 横置き、Formサイズ、幅
        /// </summary>
        private const int HORIZONTAL_FORM_W = 1250;

        /// <summary>
        /// Flashサイズ、幅
        /// </summary>
        private const int FLASH_W = 320;

        /// <summary>
        /// Flashサイズ、高さ
        /// </summary>
        private const int FLASH_H = 210;

        #endregion

        #region [ インスタンス ]

        private LoadDialog loadDialog;

        #endregion


        #region [ コンストラクタ ]

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public Form1()
        {
            this.loadDialog = new LoadDialog();
            this.loadDialog.Show();
            // イベントdispatch
            Application.DoEvents();

            InitializeComponent();
            Console.WriteLine("FORM LOAD");
        }

        #endregion

        /// <summary>
        /// バルーン表示
        /// </summary>
        /// <param name="strTitle"></param>
        /// <param name="strParson"></param>
        private void balloonView(string strTitle, string strParson)
        {
            this.notifyIcon.BalloonTipTitle = "番組開始";
            this.notifyIcon.BalloonTipText = strTitle + "（" + strParson + "）";
            this.toolTip.IsBalloon = true;
            this.notifyIcon.ShowBalloonTip(10000);
        }

        /// <summary>
        /// 情報ブラウザによるメーラー起動
        /// </summary>
        /// <param name="mail"></param>
        private void clickMailAddress(string mail)
        {
            this.liveControl.openMailTab(mail);
        }

        #region [ コントロールイベント ]

        /// <summary>
        /// ロードイベント
        /// </summary>
        /// <param name="sender">オブジェクト</param>
        /// <param name="e">イベント</param>
        private void Form1_Load(object sender, EventArgs e)
        {
            this.infoBrowser.OpenMailByAddress = clickMailAddress;

            this.Text += "   " + DataManager.GetVersion;

            // DesktopLocationを0,0に
            this.DesktopLocation = new Point(0, 0);

            // 接続デリゲート
            this.infoBrowser._TimerProc = new TimerProc(balloonView);

            this.liveControl._ReconnectProc = new ReconnectProc(reconnectProc);
            this.axShockwaveFlash.OnReadyStateChange += new _IShockwaveFlashEvents_OnReadyStateChangeEventHandler(axShockwaveFlash1_OnReadyStateChange);


            this.axShockwaveFlash.LoadMovie(0, @"http://www.uniqueradio.jp/agplayerf/LIVEPlayer-HD0318.swf");

            this.liveControl.onLoad();

            this.loadDialog.Close();
            this.Visible = true;
            Console.WriteLine("FORM LOAD");

            // 表示後にバージョン情報が出るよ
            if (!loadInitial())
                // error
                this.Close();
        }

        /// <summary>
        /// Flashプレーヤーすてたーす変更時
        /// </summary>
        /// <param name="sender">オブジェクト</param>
        /// <param name="e">イベント</param>
        private void axShockwaveFlash1_OnReadyStateChange(object sender, _IShockwaveFlashEvents_OnReadyStateChangeEvent e)
        {
            switch ((FlashState)e.newState)
            {
                case FlashState.Loading:
                    break;
                case FlashState.Uninitialized:
                    break;
                case FlashState.Loaded:
                    break;
                case FlashState.Interactive:
                    break;
                case FlashState.Complete:
                    break;
            }
        }

        #endregion

        #region [ パブリックイベント ]

        /// <summary>
        /// 初期化処理
        /// </summary>
        private bool loadInitial()
        {
            string strErrMsg = string.Empty;
            bool blResult = true;
            // バージョンチェック
            /****
             * VersionアップのときはCheckVersionを変更してね
             ****/
            if (!FileProc.CheckVersion(ref strErrMsg))
            {
                if (string.IsNullOrEmpty(strErrMsg))
                {
                    strErrMsg = "新しいバージョンがダウンロード可能です。";
                    blResult = true;
                }
                else
                {
                    strErrMsg = "バージョンチェックエラー";
                    blResult = false;
                }
            }
            if (strErrMsg.Length != 0)
                MessageBox.Show(strErrMsg);
            return blResult;
        }

        #endregion


        #region [ プライベートメソッド ]

        /// <summary>
        /// 再接続処理
        /// </summary>
        private void reconnectProc()
        {
            // 現在のものを破棄
            this.axShockwaveFlash.StopPlay();
            this.axShockwaveFlash.Dispose();

            // 再作成
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.axShockwaveFlash = new AxShockwaveFlash();
            ((System.ComponentModel.ISupportInitialize)(this.axShockwaveFlash)).BeginInit();
            this.axShockwaveFlash.Location = new System.Drawing.Point(5, 5);
            this.axShockwaveFlash.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axShockwaveFlash1.OcxState")));
            this.axShockwaveFlash.Size = new System.Drawing.Size(FLASH_W, FLASH_H);
            this.Controls.Add(this.axShockwaveFlash);
            ((System.ComponentModel.ISupportInitialize)(this.axShockwaveFlash)).EndInit();

            this.axShockwaveFlash.LoadMovie(0, @"http://www.uniqueradio.jp/agplayerf/LIVEPlayer-HD0318.swf");
            }

        #endregion
    }
}
