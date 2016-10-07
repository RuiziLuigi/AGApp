using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Configuration;
using System.Text;
using System.Xml;
using System.Net;
using System.Web;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
using System.Globalization;


namespace AGApp.Proc
{
    /// <summary>
    /// Twitter処理
    /// </summary>
    public class OAuthProc
    {
        /// <summary>
        /// リクエストトークンURL
        /// </summary>
        const string REQUEST_TOKEN_URL = "https://twitter.com/oauth/request_token";

        /// <summary>
        /// アクセストークンURL
        /// </summary>
        const string ACCESS_TOKEN_URL = "https://twitter.com/oauth/access_token";

        /// <summary>
        /// Auth認証URL
        /// </summary>
        const string AUTHORIZE_URL = "https://twitter.com/oauth/authorize";

        /// <summary>
        /// タイムライン取得URL
        /// </summary>
        const string TIMELINE_URL = @"https://api.twitter.com/1.1/statuses/home_timeline.json";

        /// <summary>
        /// ツイートURL
        /// </summary>
        const string TWIT_URL = @"https://api.twitter.com/1.1/statuses/update.json";

        /// <summary>
        /// 検索
        /// </summary>
        const string SEARCH_URL = @"https://api.twitter.com/1.1/search/tweets.json";

        /// <summary>
        /// UserStream対応URL
        /// </summary>
        const string USERSTREAM_URL = @"https://userstream.twitter.com/2/user.json";

        private enum DataType
        {
            TIMELINE,
            SEARCH
        }

        #region [ プライベートインスタンス ]

        private Random random = new Random();

        /// <summary>
        /// エラーメッセージ
        /// </summary>
        private string m_strErrMsg = string.Empty;

        #endregion

        #region [ アクセサ ]

        public TwitterLoginData _OAuthData { set; get; }

        /// <summary>
        /// エラー文
        /// </summary>
        public string _ErrMsg
        {
            get
            {
                return this.m_strErrMsg;
            }
        }

        #endregion

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="authData">AuthData</param>
        public OAuthProc(TwitterLoginData authData)
        {
            ServicePointManager.Expect100Continue = false;
            this._OAuthData = authData;
        }

        #region [ 承認処理 ]

        /// <summary>
        /// 初期化処理
        /// </summary>
        /// <returns>BOOL型</returns>
        public bool Initialize()
        {
            // [リクエストトークン取得処理]

            // デフォルトパラメータ取得
            SortedDictionary<string, string> p_parameters =
                new SortedDictionary<string, string>(getGenerateParameter());
            // シグネチャパラメータ追加
            p_parameters.Add("oauth_signature",
                encodeProc(GenerateSignature("", "GET", REQUEST_TOKEN_URL, p_parameters)));
            // 実行・レスポンス取得
            Dictionary<string, string> dic = GetResponseParameter(HttpGet(REQUEST_TOKEN_URL, p_parameters));
            string strOut = string.Empty;
            if (dic.TryGetValue("oauth_token", out strOut))
            {
                this._OAuthData._TOKEN = strOut;
            }
            if (dic.TryGetValue("oauth_token_secret", out strOut))
            {
                this._OAuthData._TOKEN_SECRET = strOut;
            }

            // [リクエストトークン取得処理]終了

            // urlにアクセス
            string strUrl = AUTHORIZE_URL + "?oauth_token=" + this._OAuthData._TOKEN;

            // アクセスしたページからpinを取得する
            try
            {
                System.Diagnostics.Process.Start("iexplore.exe", strUrl);
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// PIN承認処理
        /// </summary>
        /// <param name="strPin">PIN番号</param>
        public bool InitializePin(string strPin)
        {
            // [アクセストークン取得処理]開始

            // デフォルトパラメータ取得
            SortedDictionary<string, string> p_parameters =
                new SortedDictionary<string, string>(getGenerateParameter());
            // リクエストトークン追加
            p_parameters.Add("oauth_token", this._OAuthData._TOKEN);
            // pin情報追加
            p_parameters.Add("oauth_verifier", strPin);
            // シグネチャパラメータ追加
            p_parameters.Add("oauth_signature", encodeProc(GenerateSignature(
                this._OAuthData._TOKEN_SECRET, "GET", ACCESS_TOKEN_URL, p_parameters)));
            // 実行・レスポンス取得
            Dictionary<string, string> dic = GetResponseParameter(HttpGet(ACCESS_TOKEN_URL, p_parameters));
#if DEBUG
            foreach (string strKey in dic.Keys)
            {
                Console.WriteLine("Key:{0} Value:{1}", new string[] { strKey, dic[strKey] });
            }
#endif
            string strOut = string.Empty;
            if (dic.TryGetValue("oauth_token", out strOut))
                this._OAuthData._TOKEN = strOut;
            if (dic.TryGetValue("oauth_token_secret", out strOut))
                this._OAuthData._TOKEN_SECRET = strOut;
            if (dic.TryGetValue("user_id", out strOut))
                this._OAuthData._USER_ID = strOut;
            if (dic.TryGetValue("screen_name", out strOut))
                this._OAuthData._NAME = strOut;
            // [アクセストークン取得処理]終了
            return true;
        }

        #endregion

        #region [ パブリックメソッド ]

        /// <summary>
        /// タイムライン取得処理
        /// </summary>
        /// <returns>タイムラインデータ</returns>
        public bool GetTimeLine(ref List<TwitData> lstTwitData)
        {
            this.m_strErrMsg = string.Empty;
            Dictionary<string, string> dicBuf = new Dictionary<string, string>();
            dicBuf.Add("count", "20");
            try
            {
                SortedDictionary<string, string> p_parameter = getBase(dicBuf, TIMELINE_URL, "GET");
                lstTwitData = decodeJson(HttpGet(TIMELINE_URL, p_parameter), DataType.TIMELINE);
                return true;
            }
            catch (Exception e)
            {
                this.m_strErrMsg = e.Message;
                return false;
            }
        }

        /// <summary>
        /// 検索ワード取得処理
        /// </summary>
        /// <returns>BOOL型</returns>
        public bool GetSearchLine(ref List<TwitData> lstTwitData, string strMaxId)
        {
            this.m_strErrMsg = string.Empty;
            Dictionary<string, string> dicBuf = new Dictionary<string, string>();
            dicBuf.Add("q", encodeProc("#agqr"));   // 検索文字列
            dicBuf.Add("result_type","recent");     // 検索タイプ（最新から取得する）
            dicBuf.Add("count", "100");             // 件数
            dicBuf.Add("include_entities", "true"); // 画像データ取得
            try
            {
                // MaxIDの設定がある場合は設定する
                if (!string.IsNullOrEmpty(strMaxId))
                {
                    dicBuf.Add("since_id", strMaxId);
                }
                SortedDictionary<string, string> p_parameter = getBase(dicBuf, SEARCH_URL, "GET");
                string strHttpGet = HttpGet(SEARCH_URL, p_parameter);
                if (string.IsNullOrEmpty(strHttpGet) && !string.IsNullOrEmpty(this.m_strErrMsg))
                {
                    return false;
                }
                else
                {
                    lstTwitData = decodeJson(strHttpGet, DataType.SEARCH);
                    return true;
                }
            }
            catch (Exception e)
            {
                this.m_strErrMsg = e.Message;
                return false;
            }
        }

        /// <summary>
        /// ツイート処理
        /// </summary>
        /// <param name="strTwit">ツイート文</param>
        public void PostTwit(string strTwit)
        {
            Dictionary<string, string> dicBuf = new Dictionary<string, string>();
            dicBuf.Add("status", encodeProc(strTwit));
            SortedDictionary<string, string> p_parameter = getBase(dicBuf, TWIT_URL, "POST");
            httpPost(TWIT_URL, p_parameter);
        }

        /// <summary>
        /// UserStream対応処理
        /// </summary>
        /// <param name="strTwit">ツイート文</param>
        public void GetUserStream(string strTwit)
        {
            // 参照url : http://kokudori.blog69.fc2.com/blog-entry-58.html
        }

        /// <summary>
        /// レートリミット取得
        /// </summary>
        public void GetRateLimit()
        {
            // レートリミット取得処理
            // 呼び出し回数　　　　　　：　X-Rate-Limit-Remaining
            // アカウントリセット時間　：　X-Rate-Limit-Reset

            // 1アカウント当たりツイート1000件
            // エンドポイント（種類）ごとに呼び出し60回/h
            // ツイート表示、プロフィール表示、ユーザーの検索は720回/h
        }

        #endregion

        private SortedDictionary<string, string> getBase(
            Dictionary<string,string> dicAddParam, string strUrl, string strMethod)
        {
            SortedDictionary<string, string> p_parameters =
                    new SortedDictionary<string, string>(getGenerateParameter());
            foreach (string strKey in dicAddParam.Keys)
            {
                p_parameters.Add(strKey, dicAddParam[strKey]);
            }
            // アクセストークン追加
            p_parameters.Add("oauth_token", this._OAuthData._TOKEN);
            // シグネチャ追加
            p_parameters.Add("oauth_signature", encodeProc(GenerateSignature(
                this._OAuthData._TOKEN_SECRET, strMethod, strUrl, p_parameters)));

            return p_parameters;
        }

        /// <summary>
        /// HTTPレスポンス取得処理
        /// </summary>
        /// <param name="url">取得対象URL</param>
        /// <param name="parameters">GETパラメータ</param>
        /// <returns>取得文字列</returns>
        private string HttpGet(string url, Dictionary<string, string> parameters)
        {
            WebRequest req = WebRequest.Create(url + '?' + JoinParameters(parameters));
            WebResponse res = req.GetResponse();
            Stream stream = res.GetResponseStream();
            StreamReader reader = new StreamReader(stream);
            string result = reader.ReadToEnd();
            reader.Close();
            stream.Close();
            return result;
        }

        private string httpPost(string url, IDictionary<string, string> parameters)
        {
            byte[] data = Encoding.ASCII.GetBytes(JoinParameters(parameters));
            WebRequest req = WebRequest.Create(url);
            req.Method = "POST";
            req.ContentType = "application/x-www-form-urlencoded";
            req.ContentLength = data.Length;
            Stream reqStream = req.GetRequestStream();
            reqStream.Write(data, 0, data.Length);
            reqStream.Close();
            WebResponse res = req.GetResponse();
            Stream resStream = res.GetResponseStream();
            StreamReader reader = new StreamReader(resStream, Encoding.UTF8);
            string result = reader.ReadToEnd();
            reader.Close();
            resStream.Close();
            return result;
        }

        private string GenerateSignature(
            string strTokenSecret, string strMethod, string strUrl, SortedDictionary<string, string> parameters)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(strMethod);
            sb.Append('&');
            sb.Append(encodeProc(strUrl));
            sb.Append('&');
            sb.Append(encodeProc(JoinParameters(parameters)));
            // ハッシュデータ生成
            HMACSHA1 hmacsha1 = new HMACSHA1();
            hmacsha1.Key = Encoding.ASCII.GetBytes(
                encodeProc(TwitterLoginData._CONSUMER_SECRET) + '&' + encodeProc(strTokenSecret));
            return Convert.ToBase64String(hmacsha1.ComputeHash(
                Encoding.ASCII.GetBytes(sb.ToString())));
        }


        /// <summary>
        /// HTTP戻り値取得処理
        /// </summary>
        /// <param name="url">アクセスURL</param>
        /// <param name="parameters">設定パラメータ</param>
        /// <returns>戻り文字列（Empty=エラー）</returns>
        private string HttpGet(string url, IDictionary<string, string> parameters)
        {
            string strResult = string.Empty;
            Stream stream = null;
            StreamReader reader = null;
            try
            {
                WebRequest req = WebRequest.Create(url + '?' + JoinParameters(parameters));
                WebResponse res = req.GetResponse();
                stream = res.GetResponseStream();
                reader = new StreamReader(stream);
                strResult = reader.ReadToEnd();
            }
            catch (Exception e)
            {
                this.m_strErrMsg = e.Message;
            }
            finally
            {
                if (reader != null) reader.Close();
                if (stream != null) stream.Close();
            }
            return strResult;
        }

        /// <summary>
        /// 戻り値情報取得
        /// </summary>
        /// <param name="strResponse">戻り値</param>
        /// <returns>戻り値情報</returns>
        private Dictionary<string, string> GetResponseParameter(string strResponse)
        {
            Dictionary<string, string> dicResult = new Dictionary<string, string>();
            foreach (string s in strResponse.Split('&'))
            {
                int iIdx = s.IndexOf('=');
                if (iIdx == -1) { dicResult.Add(s, ""); }
                else { dicResult.Add(s.Substring(0, iIdx), s.Substring(iIdx + 1)); }
            }
            return dicResult;
        }

        /// <summary>
        /// パラメータ連結
        /// </summary>
        /// <param name="parameters">パラメータ一覧</param>
        /// <returns>連結パラメータ</returns>
        private string JoinParameters(IDictionary<string, string> parameters)
        {
            StringBuilder result = new StringBuilder();
            bool first = true;
            foreach (var parameter in parameters)
            {
                if (first)
                    first = false;
                else
                    result.Append('&');
                result.Append(parameter.Key);
                result.Append('=');
                result.Append(parameter.Value);
            }
            return result.ToString();
        }

        /// <summary>
        /// エンコード処理
        /// </summary>
        /// <param name="strValue">対象文字列</param>
        /// <returns>エンコード後文字列</returns>
        private string encodeProc(string strValue)
        {
            // エンコード対象外文字列
            string strUnreserved = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-_.~";
            StringBuilder sb = new StringBuilder();
            byte[] data = Encoding.UTF8.GetBytes(strValue);
            foreach (byte b in data)
            {
                if (b < 0x80 && strUnreserved.IndexOf((char)b) != -1) { sb.Append((char)b); }
                else { sb.Append('%' + String.Format("{0:X2}", (int)b)); }
            }
            return sb.ToString();
        }

        /// <summary>
        /// JSONデータ、デコード
        /// </summary>
        /// <param name="strValue">JSONデータ</param>
        /// <param name="dt">データタイプ</param>
        /// <returns>デコード情報</returns>
        private List<TwitData> decodeJson(string strValue, DataType dt)
        {
            StringBuilder sb = new StringBuilder();
            int iAdd = 0;
            // Unicodeのコンバート
            for (int iIdx = 0; iIdx < strValue.Length - 1; iIdx += iAdd)
            {
                char[] cBuf = strValue.Substring(iIdx, 2).ToCharArray();
                if (cBuf[0] == '\\' && cBuf[1] == 'u')
                {
                    sb.Append(Convert.ToChar(
                        Convert.ToInt32(strValue.Substring(iIdx + 2, 4),16)).ToString());
                    iAdd = 6;
                }
                else
                {
                    sb.Append(strValue[iIdx]);
                    iAdd = 1;
                }
            }
            sb.Append(strValue[strValue.Length - 1]);

            // htmlデコード
            string strHtmlDecode = HttpUtility.HtmlDecode(sb.ToString());

            // Jsonデータシリアライズ
            DataContractJsonSerializer dcjs = null;
            if (dt == DataType.TIMELINE)
            {
                dcjs = new DataContractJsonSerializer(typeof(List<TwitData>));
            }
            else
            {
                dcjs = new DataContractJsonSerializer(typeof(SearchData));
            }
            byte[] bData = Encoding.Unicode.GetBytes(strHtmlDecode);
            MemoryStream ms = new MemoryStream(bData);
            List<TwitData> lstData = new List<TwitData>();
            if (dt == DataType.TIMELINE)
            {
                lstData = (List<TwitData>)dcjs.ReadObject(ms);
            }
            else
            {
                lstData = ((SearchData)dcjs.ReadObject(ms))._STATUSES;
            }
            // タイムゾーン変更
            foreach (var data in lstData)
            {
                data._YMD = replaceTimeZone(data._YMD);
            }

            return lstData;
        }

        /// <summary>
        /// 共通パラメータ設定
        /// </summary>
        /// <returns>パラメータリスト</returns>
        private SortedDictionary<string, string> getGenerateParameter()
        {
            SortedDictionary<string, string> parameter = new SortedDictionary<string, string>();
            // 付随パラメータ設定
            string strLetters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            StringBuilder sb = new StringBuilder(8);
            for (int i = 0; i < 8; ++i)
            {
                sb.Append(strLetters[random.Next(strLetters.Length)]);
            }
            // タイムスタンプパラメータ追加
            parameter.Add("oauth_timestamp",
                Convert.ToInt64((DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0)).TotalSeconds).ToString());
            parameter.Add("oauth_consumer_key", TwitterLoginData._CONSUMER_KEY);
            parameter.Add("oauth_signature_method", "HMAC-SHA1");
            parameter.Add("oauth_nonce", sb.ToString());
            parameter.Add("oauth_version", "1.0");
            return parameter;
        }

        /// <summary>
        /// タイムゾーン変換データ
        /// </summary>
        /// <param name="strData">時間データ</param>
        /// <returns>変換データ</returns>
        private string replaceTimeZone(string strData)
        {
            try
            {
                //Thu Apr 18 09:29:55 +0000 2013
                DateTime time = DateTime.ParseExact(strData,
                    "ddd MMM d HH':'mm':'ss zzz yyyy",
                    DateTimeFormatInfo.InvariantInfo,
                    System.Globalization.DateTimeStyles.None);
                return time.ToString("yyyy-MM-dd HH:mm:ss");
            }
            catch (Exception e)
            {
                Console.WriteLine("タイムゾーン変換エラー【" + strData + "】：" + e.Message);
                return string.Empty;
            }
        }
    }
}
