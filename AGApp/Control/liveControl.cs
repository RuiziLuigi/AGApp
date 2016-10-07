using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using AGApp.Control.Browse;
using AGApp.Dialog;
using AGApp.Proc;

namespace AGApp.Control
{
    /// <summary>
    /// 実況クラスコントロール
    /// </summary>
    public partial class liveControl : UserControl
    {
        public SettingProc _SettingProc
        {
            set { this.settingPanel1._SettingProc = value; }
        }
        public ReconnectProc _ReconnectProc
        {
            set { this.settingPanel1._ReconnectProc = value; }
        }


        private enum TABIDX
        {
            Ch = 0,
            Twit,
            Mail,
            Setting,
            Info
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public liveControl()
        {
            InitializeComponent();

            // TAG設定
            this.tabControl.TabPages[(int)TABIDX.Ch].Tag = TABIDX.Ch;
            this.tabControl.TabPages[(int)TABIDX.Twit].Tag = TABIDX.Twit;
            this.tabControl.TabPages[(int)TABIDX.Mail].Tag = TABIDX.Mail;
            this.tabControl.TabPages[(int)TABIDX.Setting].Tag = TABIDX.Setting;
            this.tabControl.TabPages[(int)TABIDX.Info].Tag = TABIDX.Info;

            // メールアドレスクリック起動
            this.timeTableControl1.OpenMail = this.openMailTab;
        }

        #region [ パブリックメソッド ]

        /// <summary>
        /// ロード処理
        /// </summary>
        public void onLoad()
        {
            this.newChBrowser.onLoad();
        }

        /// <summary>
        /// メール送信タブ起動
        /// </summary>
        /// <param name="mail">番組データ</param>
        public void openMailTab(string mail)
        {
            this.tabControl.SelectedIndex = (int)TABIDX.Mail;
            this.mailControl1.SetToMail(mail);
        }

        /// <summary>
        /// メール送信タブ起動
        /// </summary>
        /// <param name="agData">番組データ</param>
        private void openMailTab(AGData agData)
        {
            this.tabControl.SelectedIndex = (int)TABIDX.Mail;
            this.mailControl1.SetToMail(agData);
        }

        #endregion
    }
}
