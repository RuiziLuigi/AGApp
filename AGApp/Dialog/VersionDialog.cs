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
    public partial class VersionDialog : AGApp.Dialog.BaseDialog
    {
        #region [ コンストラクタ ]

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public VersionDialog()
        {
            
            InitializeComponent();
            this.versionLabel.Text = DataManager.GetVersion;
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

        #endregion
    }
}
