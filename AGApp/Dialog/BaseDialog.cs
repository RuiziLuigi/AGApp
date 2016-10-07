using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AGApp.Dialog
{
    public partial class BaseDialog : Form
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public BaseDialog()
        {
            InitializeComponent();
            // 非表示
            this.Opacity = 0;
            // だんだん表示
            for (int i = 0; i <= 100; i++)
            {
                this.Opacity = (double)i / 100;
            }
        }

        #region [ パブリックメソッド ]

        /// <summary>
        /// 終了処理
        /// </summary>
        public void DialogClosed()
        {
            // だんだん非表示
            for (int i = 100; i > 0; i--)
            {
                this.Opacity = (double)i / 100;
            }
            // 非表示
            this.Opacity = 0;
        }

        #endregion
    }
}
