using System;
using System.Collections.Generic;
using System.Text;
using System.Net;

namespace AGApp.Proc
{
    /// <summary>
    /// リアルタイム、タイムテーブル処理
    /// </summary>
    public class RTTimeTableProc
    {
        /// <summary>
        /// リアルタイムデータ取得処理
        /// </summary>
        /// <param name="strName">番組名</param>
        /// <param name="strText">番組説明</param>
        /// <param name="strPersonality">パーソナリティ</param>
        public static void GetRealTimeData(out string strName, out string strText, out string strPersonality)
        {
            // 初期化
            strName = string.Empty;
            strText = string.Empty;
            strPersonality = string.Empty;

            HttpWebRequest req = (System.Net.HttpWebRequest)WebRequest.Create(
                @"http://www.uniqueradio.jp/aandg");

            req.Method = "GET";
            req.IfModifiedSince = new DateTime(1995,11,14,0,0,0);

            //サーバーからの応答を受信するためのWebResponseを取得
            System.Net.HttpWebResponse webres =
                (System.Net.HttpWebResponse)req.GetResponse();

            Encoding enc = Encoding.GetEncoding("Shift-JIS");
            if (webres.StatusCode == HttpStatusCode.OK)
            {
                //応答データを受信するためのStreamを取得
                System.IO.Stream st = webres.GetResponseStream();
                System.IO.StreamReader sr = new System.IO.StreamReader(st, enc);
                //受信して表示
                string html = sr.ReadToEnd();
                // varにてsplit
                string[] strVar = html.Split(new string[] { "var " },StringSplitOptions.RemoveEmptyEntries);
                foreach (string strBuf in strVar)
                {
                    // 取得したデータにより判定
                    if (strBuf.Length > 12 && strBuf.Substring(0, 12) == "Program_name")
                    {
                        string[] strSplit = strBuf.Substring(12).Split(new char[] { '\"' });
                        strName = Uri.UnescapeDataString(strSplit[1]);
                    }
                    else if (strBuf.Length > 12 && strBuf.Substring(0,12) == "Program_text")
                    {
                        string[] strSplit = strBuf.Substring(12).Split(new char[] { '\"' });
                        strText = Uri.UnescapeDataString(strSplit[1]);
                    }
                    else if (strBuf.Length > 19 && strBuf.Substring(0, 19) == "Program_personality")
                    {
                        string[] strSplit = strBuf.Substring(1).Split(new char[] { '\"' });
                        strPersonality = Uri.UnescapeDataString(strSplit[1]);
                    }
                }
                //閉じる
                sr.Close();
            }
        }

    }
}
