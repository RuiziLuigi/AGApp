using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AGApp.Dialog
{
    /// <summary>
    /// ブラウザダイアログ
    /// </summary>
    public partial class BrowserDialog : BaseDialog
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="strURL">URL</param>
        public BrowserDialog(string strURL)
        {
            InitializeComponent();
            this.chBrowser1.MovePage(strURL);
        }
    }
}
