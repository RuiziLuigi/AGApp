using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AGApp.Properties;
using AGApp.Proc;
using AGApp.Dialog;

namespace AGApp.Control.Parts
{
    public partial class TimeTableControl : UserControl
    {

        #region [ プライベート定数 ]

        /// <summary>
        /// 画像サイズ
        /// </summary>
        private const int IMAGE_SIZE = 16;

        /// <summary>
        /// 画像スパン
        /// </summary>
        private const int IMAGE_SPAN = 2;

        /// <summary>
        /// カラムインデックス
        /// </summary>
        private enum ColumnIdx
        {
            /// <summary>
            /// 時間
            /// </summary>
            Time = 0,
            /// <summary>
            /// その他
            /// </summary>
            Other,
            /// <summary>
            /// 番組名
            /// </summary>
            Name,
            /// <summary>
            /// メールアドレス
            /// </summary>
            Mail,
            /// <summary>
            /// ホームページ
            /// </summary>
            Homepage,
            /// <summary>
            /// ハッシュタグ
            /// </summary>
            HashTag
        }

        #endregion

        public OpenMail OpenMail
        {
            set;
            get;
        }


        /// <summary>
        /// コンストラクタ
        /// </summary>
        public TimeTableControl()
        {
            InitializeComponent();

            // コンボボックス設定
            string[] strDayR = AGData.GetWeekDayResource();

            for (int iIdx = 0; iIdx < strDayR.Length; iIdx++)
            {
                this.dayComboBox.Items.Add(strDayR[iIdx]);
            }
        }

        #region [ コントロールイベント ]

        /// <summary>
        /// 曜日
        /// </summary>
        /// <param name="sender">オブジェクト</param>
        /// <param name="e">イベント</param>
        private void dayComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.loadTimeTableInfo();
        }

        /// <summary>
        /// グリッドのダブルクリックイベント
        /// </summary>
        /// <param name="sender">オブジェクト</param>
        /// <param name="e">イベント</param>
        private void dataGridView_DoubleClick(object sender, EventArgs e)
        {
            /*
            // 現在ポジション取得
            Point point = this.dataGridView.PointToClient(Cursor.Position);

            // セル位置取得
            DataGridView.HitTestInfo info = this.dataGridView.HitTest(point.X, point.Y);

            // 選択番組データ取得
            int iIdx = int.Parse(this.dataGridView.Rows[info.RowIndex].Tag.ToString());
            AGData agData = DataManager._AgDataList[iIdx];

            // メールアドレスの場合
            if (info.ColumnIndex == (int)ColumnIdx.Mail)
            {
                if (agData._Mail != string.Empty)
                {
                    // メール送信起動
                    // 表示されている場合
                    using (SendMailDialog dialog = new SendMailDialog(agData))
                    {
                        this.Visible = false;
                        dialog.ShowDialog();
                        dialog.DialogClosed();
                        this.Visible = true;
                    }
                }
            }
            // ホームページの場合
            else if (info.ColumnIndex == (int)ColumnIdx.Homepage)
            {
                if (agData._Blog != string.Empty)
                {
                    // ホームページオープン
                    //Process.Start(agData._Blog);
                }
            }
            // ハッシュタグの場合
            else if (info.ColumnIndex == (int)ColumnIdx.HashTag)
            {
                // #agqrとの並行検索の対応
                string strSearch = agData._HashTag;
                if (MessageBox.Show("【#agqr】とOR検索を行いますか？", "確認", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    strSearch += "+OR+#agqr";
                }
            }
            */
            // セル位置取得
            Point point = this.dataGridView.PointToClient(Cursor.Position);
            DataGridView.HitTestInfo info = this.dataGridView.HitTest(point.X, point.Y);

            using (TimeTableInfoDialog dialog = new TimeTableInfoDialog(
                DataManager._AgDataList[int.Parse(this.dataGridView.Rows[info.RowIndex].Tag.ToString())], this.OpenMail))
            {
                dialog.StartPosition = FormStartPosition.CenterParent;
                dialog.ShowDialog();
            }
        }

        /// <summary>
        /// ロード時処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TimeTableControl_Load(object sender, EventArgs e)
        {
            this.dayComboBox.SelectedIndex = 0;
        }

        /// <summary>
        /// 最新番組表取得ボタンクリック時イベント
        /// </summary>
        /// <param name="sender">オブジェクト</param>
        /// <param name="e">イベント</param>
        private void timetableBtn_Click(object sender, EventArgs e)
        {
            // 番組表自動更新
            if (!FileProc.DownloadTimeTable())
            {
                MessageBox.Show("番組表更新に失敗しました");
                return;
            }

            // ダイアログ・データマネージャーの設定
            // 番組表取得
            if (!FileProc.GetTimeTable(ref DataManager._AgDataList))
            {
                MessageBox.Show("番組表が取得できませんでした");
                return;
            }

            // 番組表更新後、画面を再描画する
            this.loadTimeTableInfo();

            MessageBox.Show("番組表の更新が完了しました。");
        }

        #endregion

        /// <summary>
        /// 番組表情報ロード処理
        /// </summary>
        private void loadTimeTableInfo()
        {
            // リスト初期化
            this.dataGridView.Rows.Clear();

            // 選択中のコンボボックスを取得
            string strDay = this.dayComboBox.SelectedItem.ToString();
            for (int iIdx = 0; iIdx < DataManager._AgDataList.Count; iIdx++)
            {
                if (DataManager._AgDataList[iIdx].CheckWeekDay(strDay))
                {
                    AGData data = DataManager._AgDataList[iIdx];
                    this.dataGridView.Rows.Add(new string[] { data._Time, data._Name });
                    // データのインデックスをタグとして行につけておく
                    this.dataGridView.Rows[this.dataGridView.Rows.Count - 1].Tag = iIdx;
                }
            }
        }

    }
}
