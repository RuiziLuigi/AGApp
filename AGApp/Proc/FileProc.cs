using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml.Serialization;
using AGApp.Dialog;

namespace AGApp.Proc
{
    /// <summary>
    /// ファイル処理
    /// </summary>
    public static class FileProc
    {
        #region []

        public enum FileKind
        {
            TwitterLoginData,
        }

        #endregion

        #region [ パブリックメソッド ]

        /// <summary>
        /// Twitterデータ取得
        /// </summary>
        /// <param name="twitterData">twitterデータ</param>
        /// <returns>true=OK, false=NG</returns>
        public static bool GetTwitterData(ref List<TwitterLoginData> twitterData)
        {
            // ファイルフォルダパスの取得
            string strPath = GetTwitterLoginPath();
            // ファイルストリームの設定
            FileStream stream = null;
            try
            {
                stream = new FileStream(strPath, FileMode.Open);
                // シリアライズのオブジェクト作成
                XmlSerializer serial = new XmlSerializer(typeof(List<TwitterLoginData>));
                twitterData = (List<TwitterLoginData>)serial.Deserialize(stream);
            }
            catch (Exception e)
            {
                // オブジェクト生成
                twitterData = new List<TwitterLoginData>();
                // ファイル作成
                if (File.Exists(strPath))
                {
                    // 読込ファイル削除
                    File.Delete(strPath);
                }
                FileStream fs = File.Create(strPath);
                fs.Close();
                Console.WriteLine("Twitterデータ取得でのException：" + e.Message);
                return false;
            }
            finally
            {
                if (stream != null)
                    stream.Close();
            }
            return true;
        }

        /// <summary>
        /// Twitterデータ設定
        /// </summary>
        /// <param name="lstTimeTable">Twitterデータ</param>
        /// <returns>true=OK, false=NG</returns>
        public static bool SetTwitterData(List<TwitterLoginData> twitterData)
        {
            // データクラスからシリアル化して設定

            // ファイルフォルダパスの取得
            string strPath = GetTwitterLoginPath();
            // ファイルストリームの設定
            FileStream stream = null;
            try
            {
                stream = new FileStream(strPath, FileMode.OpenOrCreate);
                // 初期化
                stream.SetLength(0);
                // シリアライズのオブジェクト作成
                XmlSerializer serial = new XmlSerializer(typeof(List<TwitterLoginData>));

                serial.Serialize(stream, twitterData);
            }
            catch (Exception e)
            {
                Console.WriteLine("TwitterデータのException：" + e.Message);
                return false;
            }
            finally
            {
                if (stream != null)
                    stream.Close();
            }
            return true;
        }

        /// <summary>
        /// タイムテーブル取得
        /// </summary>
        /// <param name="lstTimeTable">タイムテーブルデータ</param>
        /// <returns>true=OK, false=NG</returns>
        public static bool GetTimeTable(ref List<AGData> lstTimeTable)
        {
            // XMLをデータクラスに逆シリアル化して設定

            // ファイルフォルダパスの取得
            string strPath = GetTimeTablePath();
            // ファイルストリームの設定
            FileStream stream = null;
            try
            {
                stream = new FileStream(strPath, FileMode.Open);
                // シリアライズのオブジェクト作成
                XmlSerializer serial = new XmlSerializer(typeof(List<AGData>));
                lstTimeTable = (List<AGData>)serial.Deserialize(stream);
            }
            catch (Exception e)
            {
                Console.WriteLine("タイムテーブルデータ取得でのException：" + e.Message);
                return false;
            }
            finally
            {
                if (stream != null)
                {
                    stream.Close();
                }
            }

            return true; 
        }

        /// <summary>
        /// タイムテーブル設定
        /// </summary>
        /// <param name="lstTimeTable">タイムテーブルデータ</param>
        /// <returns>true=OK, false=NG</returns>
        public static bool SetTimeTable(List<AGData> lstTimeTable)
        {
            // データクラスからシリアル化して設定

            // ファイルフォルダパスの取得
            string strPath = GetTimeTablePath();
            // ファイルストリームの設定
            FileStream stream = null;
            try
            {
                stream = new FileStream(strPath, FileMode.OpenOrCreate);
                // 初期化
                stream.SetLength(0);
                // シリアライズのオブジェクト作成
                XmlSerializer serial = new XmlSerializer(typeof(List<AGData>));

                serial.Serialize(stream, lstTimeTable);
            }
            catch (Exception e)
            {
                Console.WriteLine("タイムテーブルデータのException：" + e.Message);
                return false;
            }
            finally
            {
                if (stream != null)
                {
                    stream.Close();
                }
            }
            return true;
        }

        /// <summary>
        /// 設定データ取得
        /// </summary>
        /// <param name="settingData">設定データ</param>
        /// <returns>true=OK, false=NG</returns>
        public static void GetSettingData(ref SettingData settingData)
        {
            // XMLをデータクラスに逆シリアル化して設定

            // ファイルフォルダパスの取得
            string strPath = getSettingDataPath();
            // ファイルストリームの設定
            FileStream stream = null;
            try
            {
                stream = new FileStream(strPath, FileMode.Open);
                // シリアライズのオブジェクト作成
                XmlSerializer serial = new XmlSerializer(typeof(SettingData));
                settingData = (SettingData)serial.Deserialize(stream);
                if (stream != null)
                    stream.Close();
            }
            catch (Exception e)
            {
                if (stream != null)
                    stream.Close();
                Console.WriteLine("設定データ取得でのException：" + e.Message);
                settingData = new SettingData();
                SetSettingData(settingData);
            }
        }

        /// <summary>
        /// 設定データ設定
        /// </summary>
        /// <param name="settingData">設定データ</param>
        /// <returns>true=OK, false=NG</returns>
        public static bool SetSettingData(SettingData settingData)
        {
            // データクラスからシリアル化して設定

            // ファイルフォルダパスの取得
            string strPath = getSettingDataPath();
            // ファイルストリームの設定
            FileStream stream = null;
            try
            {
                stream = new FileStream(strPath, FileMode.OpenOrCreate);
                // 初期化
                stream.SetLength(0);
                // シリアライズのオブジェクト作成
                XmlSerializer serial = new XmlSerializer(typeof(SettingData));
                serial.Serialize(stream, settingData);
            }
            catch (Exception e)
            {
                Console.WriteLine("設定データ設定でのException：" + e.Message);
                return false;
            }
            finally
            {
                if (stream != null)
                    stream.Close();
            }
            return true;
        }

        /// <summary>
        /// 番組表ファイルダウンロード
        /// </summary>
        /// <returns>true=OK, false=NG</returns>
        public static bool DownloadTimeTable()
        {
            DownloadFile download = new DownloadFile();
            Thread thread = new Thread(new ThreadStart(download.DownloadTimeTable));
            thread.Start();

            while (!download.FinFlg)
                Thread.Sleep(1000);
            thread.Join();

            if (download.ErrMsg != string.Empty)
                return false;
            else
                // ファイル書き込み
                if (!SetTimeTable(download.AgData))
                    return false;
            return true;
        }

        /// <summary>
        /// バージョンチェック
        /// </summary>
        /// <param name="strErrMsg">エラーメッセージ</param>
        /// <returns>true=OK, false=NG</returns>
        public static bool CheckVersion(ref string strErrMsg)
        {
            strErrMsg = string.Empty;
            DownloadFile download = new DownloadFile();
            Thread thread = new Thread(new ThreadStart(download.DownloadVersion));
            thread.Start();

            while (!download.FinFlg)
            {
                Thread.Sleep(1000);
            }
            thread.Join();

            if (download.ErrMsg != string.Empty)
            {
                strErrMsg = download.ErrMsg;
                return false;
            }
            VersionData vd = download.VerData;
            if (vd._Version1st != DataManager.VER_1ST ||
                vd._Version2nd != DataManager.VER_2ND ||
                vd._Version3rd != DataManager.VER_3RD)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// メールテーブル取得
        /// </summary>
        /// <param name="lstMailTable">タイムテーブルデータ</param>
        /// <returns>true=OK, false=NG</returns>
        public static bool GetMailTable(ref List<MailData> lstMailTable)
        {
            // XMLをデータクラスに逆シリアル化して設定

            // ファイルフォルダパスの取得
            string strPath = GetMailTablePath();
            // ファイルストリームの設定
            FileStream stream = null;
            try
            {
                stream = new FileStream(strPath, FileMode.Open);
                // シリアライズのオブジェクト作成
                XmlSerializer serial = new XmlSerializer(typeof(List<MailData>));
                lstMailTable = (List<MailData>)serial.Deserialize(stream);
            }
            catch (Exception e)
            {
                Console.WriteLine("メールテーブル取得でのException：" + e.Message);
                return false;
            }
            finally
            {
                if (stream != null)
                    stream.Close();
            }
            return true;
        }

        /// <summary>
        /// メールテーブル設定
        /// </summary>
        /// <param name="lstMailTable">メールテーブルデータ</param>
        /// <returns>true=OK, false=NG</returns>
        public static bool SetMailTable(List<MailData> lstMailTable)
        {
            // データクラスからシリアル化して設定

            // ファイルフォルダパスの取得
            string strPath = GetMailTablePath();
            // ファイルストリームの設定
            FileStream stream = null;
            try
            {
                stream = new FileStream(strPath, FileMode.OpenOrCreate);
                // 初期化
                stream.SetLength(0);
                // シリアライズのオブジェクト作成
                XmlSerializer serial = new XmlSerializer(typeof(List<MailData>));

                serial.Serialize(stream, lstMailTable);
            }
            catch (Exception e)
            {
                Console.WriteLine("メールテーブル取得でのException：" + e.Message);
                return false;
            }
            finally
            {
                if (stream != null)
                    stream.Close();
            }
            return true;
        }

        /// <summary>
        /// 送信メールデータ保存
        /// </summary>
        /// <param name="sendMailData">送信メールデータ</param>
        /// <returns>true=OK, false=NG</returns>
        public static bool SaveMailData(SendMailData sendMailData)
        {
            // 保存パスは/Mail/年月/日_時間.txt
            string strPath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + getMailDataPath(sendMailData._Dt);

            // 本文は
            // 1行目　：番組名
            // 2行目　：年月日時分秒
            // 3行目　：タイトル
            // 4行目～：本文
            StringBuilder sb = new StringBuilder();
            sb.Append(sendMailData._Info);
            sb.Append("\r\n");
            sb.Append(sendMailData._Dt.ToString());
            sb.Append("\r\n");
            sb.Append(sendMailData._Title);
            sb.Append("\r\n");
            sb.Append(sendMailData._Msg);

            // 書込み処理
            try
            {
                // フォルダ作成
                Directory.CreateDirectory(
                    Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "/Mail/" + sendMailData._Dt.ToString("yyyyMM"));

                StreamWriter sw = new StreamWriter(strPath, false, Encoding.GetEncoding("shift_jis"));
                sw.Write(sb.ToString());
                sw.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("メール内容保存エラー：" + e.Message);
                return false;
            }
            return true;
        }

        #endregion

        /// <summary>
        /// タイムテーブル表パス
        /// </summary>
        /// <returns>ファイルパス</returns>
        public static string GetTimeTablePath()
        {
            // 指定フォルダ階層取得
            return Directory.GetParent(Application.ExecutablePath).FullName + "/NewTimeTable.xml";
        }

        /// <summary>
        /// タイムテーブル表パス
        /// </summary>
        /// <returns>ファイルパス</returns>
        private static string GetTimeTablePathNew()
        {
            return Directory.GetParent(Application.ExecutablePath).FullName + "/TT.xml";
        }

        /// <summary>
        /// メール設定パス
        /// </summary>
        /// <returns>ファイルパス</returns>
        private static string GetMailTablePath()
        {
            // 指定フォルダ階層取得
            return Directory.GetParent(Application.ExecutablePath).FullName + "/Mail.xml";
        }

        /// <summary>
        /// Twitter設定パス
        /// </summary>
        /// <returns>ファイルパス</returns>
        public static string GetTwitterLoginPath()
        {
            // 指定フォルダ階層取得
            return Directory.GetParent(Application.ExecutablePath).FullName + "/Twitter.xml";
        }

        /// <summary>
        /// メールデータパス
        /// </summary>
        /// <param name="dt">日付</param>
        /// <returns>ファイルパス</returns>
        private static string getMailDataPath(DateTime dt)
        {
            return "/Mail/" + dt.ToString("yyyyMM") + "/" + dt.ToString("dd_HHmmss") + ".txt";
        }

        /// <summary>
        /// 設定ファイルデータパス
        /// </summary>
        /// <returns>ファイルパス</returns>
        private static string getSettingDataPath()
        {
            return Directory.GetParent(Application.ExecutablePath).FullName + "/Setting.xml";
        }

    }

    public class DownloadFile
    {

        /// <summary>
        /// 終わりフラグ
        /// </summary>
        private bool m_blFinFlg = false;

        /// <summary>
        /// エラーメッセージ
        /// </summary>
        private string m_strErrMsg = string.Empty;


        /// <summary>
        /// 番組表データ
        /// </summary>
        private List<AGData> m_lstAgData = new List<AGData>();

        /// <summary>
        /// バージョン情報
        /// </summary>
        private VersionData m_versionData = new VersionData();

        /// <summary>
        /// 終わりフラグ
        /// </summary>
        public bool FinFlg
        {
            get
            {
                return this.m_blFinFlg;
            }
        }

        /// <summary>
        /// エラーメッセージ
        /// </summary>
        public string ErrMsg
        {
            get
            {
                return this.m_strErrMsg;
            }
        }

        /// <summary>
        /// 番組表データ
        /// </summary>
        public List<AGData> AgData
        {
            get
            {
                return this.m_lstAgData;
            }
        }

        /// <summary>
        /// バージョンデータ
        /// </summary>
        public VersionData VerData
        {
            get
            {
                return this.m_versionData;
            }
        }

        /// <summary>
        /// 番組表ファイルダウンロード
        /// </summary>
        public void DownloadTimeTable()
        {
            // 固定URLからファイルダウンロード
            WebClient client = new WebClient();
            client.OpenReadCompleted += new OpenReadCompletedEventHandler(client_TTOpenReadCompleted);
            client.OpenReadAsync(new Uri(@"http://okya.webcrow.jp/dl/NewTimeTable.xml"));
#if false // 旧番組表ファイル
            client.OpenReadAsync(new Uri(@"http://okya.webcrow.jp/dl/TimeTable.xml"));
#endif
        }

        /// <summary>
        /// バージョンファイルダウンロード
        /// </summary>
        public void DownloadVersion()
        {
            WebClient client = new WebClient();
            client.OpenReadCompleted += new OpenReadCompletedEventHandler(client_VerOpenReadCompleted);
            client.OpenReadAsync(new Uri(@"http://okya.webcrow.jp/dl/chk.xml"));
        }

        /// <summary>
        /// ダウンロード完了イベント
        /// </summary>
        /// <param name="sender">オブジェクト</param>
        /// <param name="e">イベント</param>
        private void client_TTOpenReadCompleted(object sender, OpenReadCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                this.m_strErrMsg = e.Error.Message;
                this.m_blFinFlg = true;
                return;
            }
            using (Stream s = e.Result)
            {
                // シリアライズのオブジェクト作成
                XmlSerializer serial = new XmlSerializer(typeof(List<AGData>));
                this.m_lstAgData = (List<AGData>)serial.Deserialize(s);
                this.m_blFinFlg = true;
            }
        }

        /// <summary>
        /// ダウンロード完了イベント
        /// </summary>
        /// <param name="sender">オブジェクト</param>
        /// <param name="e">イベント</param>
        private void client_VerOpenReadCompleted(object sender, OpenReadCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                this.m_strErrMsg = e.Error.Message;
                this.m_blFinFlg = true;
                return;
            }
            using (Stream s = e.Result)
            {
                // シリアライズのオブジェクト作成
                XmlSerializer serial = new XmlSerializer(typeof(VersionData));
                this.m_versionData = (VersionData)serial.Deserialize(s);
                this.m_blFinFlg = true;
            }
        }
    }

}