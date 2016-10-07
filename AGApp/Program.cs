using System;
using System.Collections.Generic;
using System.Windows.Forms;
using AGApp.Proc;
using AGApp.Dialog;
using System.Threading;

namespace AGApp
{
    static class Program
    {

        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Form form = new Form1();
#if false
            List<MailData> lstData = new List<MailData>();
            // yahoo
            MailData data = new MailData();
            data._Service = "Yahoo!メール";
            data._Name = "";
            data._Password = "";
            data._Mail = "";
            data._SSLFlg = false;
            data._Port = 587;
            data._SMTPServer = "smtp.mail.yahoo.co.jp";
            data._UseFlg = false;
            lstData.Add(data);
            // gmail/livedoorメール
            data = new MailData();
            data._Service = "Gmail/livedoorメール";
            data._Name = "";
            data._Password = "";
            data._Mail = "";
            data._Port = 587;
            data._SSLFlg = true;
            data._SMTPServer = "smtp.gmail.com";
            data._UseFlg = false;
            lstData.Add(data);
            // hotmail/liveメール
            data = new MailData();
            data._Service = "hotmail/Windows Live";
            data._Name = "";
            data._Password = "";
            data._Mail = "";
            data._Port = 587;
            data._SSLFlg = true;
            data._SMTPServer = "smtp.live.com";
            data._UseFlg = false;
            lstData.Add(data);
            // origin
            data = new MailData();
            data._Service = "オリジナル";
            data._Name = "";
            data._Password = "";
            data._Mail = "";
            data._Port = 25;
            data._SMTPServer = "";
            data._UseFlg = false;
            lstData.Add(data);
            FileProc.SetMailTable(lstData);
#endif

            // ロード中には設定ファイルの再読み込みを実施
            // 番組表取得
            if (!FileProc.GetTimeTable(ref DataManager._AgDataList))
            {
                MessageBox.Show("番組表が取得できませんでした");
            // メールデータ取得
            }
            else if (!FileProc.GetMailTable(ref DataManager._MailDataList))
            {
                MessageBox.Show("メールデータが取得できませんでした。");
                // Twitterデータ取得
            } else if (!FileProc.GetTwitterData(ref DataManager._TwitterLoginData))
            {
                MessageBox.Show("Twitterデータが取得できませんでした。");
                // 設定データ取得
            }
            FileProc.GetSettingData(ref DataManager._SettingData);
            Console.WriteLine("READ OK");
            Application.Run(form);
        }
    }
}
