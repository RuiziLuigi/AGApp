using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using AGApp.Proc;
using AGApp.Properties;

namespace AGApp.Dialog
{
    public partial class TwitterLoginDialog : Form
    {
        #region [ プライベート定数 ]

        private enum ColumnIdx
        {
            PIN,
            USER_ID,
            STATUS,
            PROCESS
        }

        #endregion

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public TwitterLoginDialog()
        {
            InitializeComponent();

            foreach (TwitterLoginData data in DataManager._TwitterLoginData) {
                string[] strRowsData = new string[4];
                strRowsData[(int)ColumnIdx.USER_ID] = data._NAME;
                switch (data._USELEVEL)
                {
                    case TwitterLoginData._USE_LEVEL.MAIN:
                        strRowsData[(int)ColumnIdx.STATUS] = Resources.TWIT_STATE_NOW;
                        strRowsData[(int)ColumnIdx.PIN] = "";
                        strRowsData[(int)ColumnIdx.PROCESS] = "";
                        break;
                    case TwitterLoginData._USE_LEVEL.USE:
                        strRowsData[(int)ColumnIdx.STATUS] = Resources.TWIT_STATE_FIN;
                        strRowsData[(int)ColumnIdx.PIN] = "";
                        strRowsData[(int)ColumnIdx.PROCESS] = "メインにする";
                        break;
                    case TwitterLoginData._USE_LEVEL.NOT_USE:
                        strRowsData[(int)ColumnIdx.STATUS] = Resources.TWIT_STATE_NOT;
                        strRowsData[(int)ColumnIdx.PIN] = "";
                        strRowsData[(int)ColumnIdx.PROCESS] = "承認する";
                        break;
                }
                this.twitDataGridView.Rows.Add(strRowsData);
                if (data._USELEVEL == TwitterLoginData._USE_LEVEL.MAIN)
                {
                    this.twitDataGridView[(int)ColumnIdx.PROCESS, this.twitDataGridView.RowCount - 1] = new DataGridViewTextBoxCell();
                }
            }
        }

        /// <summary>
        /// セルクリックイベント
        /// </summary>
        /// <param name="sender">オブジェクト</param>
        /// <param name="e">イベント</param>
        private void twitDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // ボタンのカラムなら
            if (e.ColumnIndex == (int)ColumnIdx.PROCESS)
            {
                // 承認済みならメインに振り替わり
                if (DataManager._TwitterLoginData[e.RowIndex]._USELEVEL == TwitterLoginData._USE_LEVEL.USE)
                {
                    // メインを解除
                    for (int iIdx = 0; iIdx < DataManager._TwitterLoginData.Count; iIdx++)
                    {
                        if (DataManager._TwitterLoginData[iIdx]._USELEVEL == TwitterLoginData._USE_LEVEL.MAIN)
                        {
                            DataManager._TwitterLoginData[iIdx]._USELEVEL = TwitterLoginData._USE_LEVEL.USE;
                            this.twitDataGridView[(int)ColumnIdx.STATUS, iIdx].Value = Resources.TWIT_STATE_FIN;
                            this.twitDataGridView[(int)ColumnIdx.PROCESS, iIdx].Value = "メインにする";
                            break;
                        }
                    }

                    // メイン設定
                    DataManager._TwitterLoginData[e.RowIndex]._USELEVEL = TwitterLoginData._USE_LEVEL.MAIN;
                    this.twitDataGridView[(int)ColumnIdx.STATUS, e.RowIndex].Value = Resources.TWIT_STATE_NOW;
                    this.twitDataGridView[(int)ColumnIdx.PROCESS, e.RowIndex].Value = "";
                }
                // 未承認データなら
                else if (DataManager._TwitterLoginData[e.RowIndex]._USELEVEL == TwitterLoginData._USE_LEVEL.NOT_USE)
                {
                    string strPin = (string)this.twitDataGridView[(int)ColumnIdx.PIN, e.RowIndex].Value;
                    TwitterLoginData data = DataManager._TwitterLoginData[e.RowIndex];
                    OAuthProc proc = new OAuthProc(data);
                    if (!string.IsNullOrEmpty(strPin))
                    {
                        // 承認
                        if (!proc.InitializePin(strPin))
                        {
                            // エラー
                        }
                        // 承認データ格納
                        proc._OAuthData._USELEVEL = TwitterLoginData._USE_LEVEL.USE;
                        DataManager._TwitterLoginData[e.RowIndex] = proc._OAuthData;
                        // 承認後再表示
                        this.twitDataGridView[(int)ColumnIdx.STATUS, e.RowIndex].Value = Resources.TWIT_STATE_FIN;
                        this.twitDataGridView[(int)ColumnIdx.USER_ID, e.RowIndex].Value = proc._OAuthData._NAME;
                        this.twitDataGridView[(int)ColumnIdx.PROCESS, e.RowIndex].Value = "メインにする";
                    }
                }
            }
        }

        /// <summary>
        /// 追加ボタン押下イベント
        /// </summary>
        /// <param name="sender">オブジェクト</param>
        /// <param name="e">イベント</param>
        private void addBtn_Click(object sender, EventArgs e)
        {
            if (checkAddData())
            {
                TwitterLoginData data = new TwitterLoginData();
                OAuthProc proc = new OAuthProc(data);
                if (!proc.Initialize())
                {
                    // エラー
                    MessageBox.Show("");
                    return;
                }
                DataManager._TwitterLoginData.Add(proc._OAuthData);

                // 行を追加
                this.twitDataGridView.Rows.Add();
                int iRow = this.twitDataGridView.RowCount - 1;
                this.twitDataGridView[(int)ColumnIdx.PIN, iRow] = new DataGridViewTextBoxCell();
                // 対象部分のステータスを変更
                this.twitDataGridView[(int)ColumnIdx.STATUS, iRow].Value = Resources.TWIT_STATE_NOT;
                this.twitDataGridView[(int)ColumnIdx.PROCESS, iRow].Value = "承認する";
            }
        }

        /// <summary>
        /// 削除ボタン押下時イベント
        /// </summary>
        /// <param name="sender">オブジェクト</param>
        /// <param name="e">イベント</param>
        private void delBtn_Click(object sender, EventArgs e)
        {
            int iIdx = this.twitDataGridView.SelectedCells[0].RowIndex;
            // データを削除
            DataManager._TwitterLoginData.RemoveAt(iIdx);
            // 画面から削除
            this.twitDataGridView.Rows.RemoveAt(iIdx);
        }

        /// <summary>
        /// 終了時イベント
        /// </summary>
        /// <param name="sender">オブジェクト</param>
        /// <param name="e">イベント</param>
        private void TwitterLoginDialog_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!checkAddData())
            {
                DataManager._TwitterLoginData.RemoveAt(DataManager._TwitterLoginData.Count - 1);
            }
            // Twitterデータ保存
            FileProc.SetTwitterData(DataManager._TwitterLoginData);
        }



        /// <summary>
        /// 追加データチェック
        /// </summary>
        /// <returns>BOOL型、追加しないときfalse</returns>
        private bool checkAddData()
        {
            if (DataManager._TwitterLoginData.Count > 0)
            {
                // 最後のデータが空かどうかを確認する
                TwitterLoginData data = DataManager._TwitterLoginData[DataManager._TwitterLoginData.Count - 1];

                if (data._USER_ID == string.Empty)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
