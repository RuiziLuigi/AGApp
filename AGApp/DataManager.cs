using System;
using System.Collections.Generic;
using System.Text;
using AGApp.Proc;

namespace AGApp
{
    /// <summary>
    /// データ・ダイアログマネージャー
    /// </summary>
    public static class DataManager
    {
        #region [ 定数 ]

        /// <summary>
        /// バージョン（メジャーバージョン）
        /// </summary>
        public const int VER_1ST = 2;

        /// <summary>
        /// バージョン（マイナーバージョン）
        /// </summary>
        public const int VER_2ND = 1;

        /// <summary>
        /// バージョン（ビルドバージョン）
        /// </summary>
        public const int VER_3RD = 0;

        #endregion

        /// <summary>
        /// 番組表データ
        /// </summary>
        public static List<AGData> _AgDataList = new List<AGData>();

        /// <summary>
        /// メールデータ
        /// </summary>
        public static List<MailData> _MailDataList = new List<MailData>();

        /// <summary>
        /// 画面データ
        /// </summary>
        public static SettingData _SettingData = new SettingData();

        /// <summary>
        /// Twitterログインデータ
        /// </summary>
        public static List<TwitterLoginData> _TwitterLoginData = new List<TwitterLoginData>();

        /// <summary>
        /// バージョン情報
        /// </summary>
        public static string GetVersion = "Version " + VER_1ST + "." + VER_2ND + "." + VER_3RD;

        /// <summary>
        /// ロードダイアログ
        /// </summary>
        private static AGApp.Dialog.LoadDialog _LoadDialog = null;

        /// <summary>
        /// 現在有効メールデータ取得
        /// </summary>
        /// <returns></returns>
        public static MailData GetNowMailData()
        {
            for (int iIdx = 0; iIdx < DataManager._MailDataList.Count; iIdx++)
                if (DataManager._MailDataList[iIdx]._UseFlg)
                    return DataManager._MailDataList[iIdx];
            return null;
        }

        /// <summary>
        /// 現在有効Twitterメールデータ取得
        /// </summary>
        /// <returns></returns>
        public static TwitterLoginData GetNowTwitterData()
        {
            for (int iIdx = 0; iIdx < DataManager._TwitterLoginData.Count; iIdx++)
            {
                if (DataManager._TwitterLoginData[iIdx]._USELEVEL == TwitterLoginData._USE_LEVEL.MAIN)
                {
                    return DataManager._TwitterLoginData[iIdx];
                }
            }
            return null;
        }

        /// <summary>
        /// ロードダイアログオープン
        /// </summary>
        public static void OpenLoadDialog()
        {
            DataManager._LoadDialog = new Dialog.LoadDialog();
            DataManager._LoadDialog.Show();
        }

        /// <summary>
        /// ロードダイアログクローズ
        /// </summary>
        public static void CloseLoadDialog()
        {
            DataManager._LoadDialog.Close();
        }
    }
}
