using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AGApp.Dialog
{
    public partial class FlashBigMidDialog : Form
    {
        #region [ アクセサ ]

        /// <summary>
        /// サイズ
        /// </summary>
        public int _Size
        {
            get
            {
                return int.Parse(this.sizeTextBox.Text);
            }
        }

        #endregion

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="iY">サイズ</param>
        public FlashBigMidDialog(int iSize)
        {
            InitializeComponent();

            this.sizeTextBox.Text = iSize.ToString();
        }

        /// <summary>
        /// 確定ボタン押下イベント
        /// </summary>
        /// <param name="sender">オブジェクト</param>
        /// <param name="e">イベント</param>
        private void okBtn_Click(object sender, EventArgs e)
        {
            // 入力チェック
            int iBuf = 0;
            if (!int.TryParse(this.sizeTextBox.Text, out iBuf))
            {
                MessageBox.Show(this, "数値で入力してください");
            }
            else
            {
                this.DialogResult = DialogResult.OK;
            }
        }

        /// <summary>
        /// 元サイズリセットボタン押下イベント
        /// </summary>
        /// <param name="sender">オブジェクト</param>
        /// <param name="e">イベント</param>
        private void resetBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Ignore;
        }

        /// <summary>
        /// 閉じるボタンイベント
        /// </summary>
        /// <param name="sender">オブジェクト</param>
        /// <param name="e">イベント</param>
        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
