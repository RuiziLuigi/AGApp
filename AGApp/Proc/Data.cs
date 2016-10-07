using System;
using System.Collections.Generic;
using System.Text;
using AGApp.Properties;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;

namespace AGApp.Proc
{
    /// <summary>
    /// タイムラインデータクラス
    /// </summary>
    [DataContract]
    public class TwitData
    {
        [DataMember(Name = "created_at")]
        public string _YMD { set; get; }
        [DataMember(Name = "text")]
        public string _Twit { set; get; }
        [DataMember(Name = "user")]
        public TwitDataUser _User { set; get; }
        [DataMember(Name = "id_str")]
        public string _TwitId { set; get; }
    }

    /// <summary>
    /// TwitData内Userデータ
    /// </summary>
    [DataContract]
    public class TwitDataUser
    {
        [DataMember(Name="name")]
        public string _Name {set;get;}
        [DataMember(Name = "screen_name")]
        public string _ScreenName { set; get; }
    }

    /// <summary>
    /// 検索ツイートデータクラス
    /// </summary>
    [DataContract]
    public class SearchData
    {
        [DataMember(Name="statuses")]
        public List<TwitData> _STATUSES { set; get; }
    }

    /// <summary>
    /// メールデータ
    /// </summary>
    public class MailData
    {
        #region [ プライベートインスタンス ]

        /// <summary>
        /// サービス名
        /// </summary>
        private string m_strService = string.Empty;

        /// <summary>
        /// SMTP
        /// </summary>
        private string m_strSMTPServer = string.Empty;

        /// <summary>
        /// ユーザ名
        /// </summary>
        private string m_strName = string.Empty;

        /// <summary>
        /// パスワード
        /// </summary>
        private string m_strPassword = string.Empty;

        /// <summary>
        /// ポート番号（デフォルト）
        /// </summary>
        private int m_iPort = 25;

        /// <summary>
        /// メールアドレス
        /// </summary>
        private string m_strMail = string.Empty;

        /// <summary>
        /// SSL使用フラグ
        /// </summary>
        private bool m_blSslFlg = false;

        /// <summary>
        /// 使用フラグ
        /// </summary>
        private bool m_blUseFlg = false;

        #endregion

        #region [ アクセサ ]

        /// <summary>
        /// サービス名
        /// </summary>
        public string _Service
        {
            set
            {
                this.m_strService = value;
            }
            get
            {
                return this.m_strService;
            }
        }

        /// <summary>
        /// SMTP
        /// </summary>
        public string _SMTPServer
        {
            set
            {
                this.m_strSMTPServer = value;
            }
            get
            {
                return this.m_strSMTPServer;
            }
        }

        /// <summary>
        /// ユーザ名
        /// </summary>
        public string _Name
        {
            set
            {
                this.m_strName = value;
            }
            get
            {
                return this.m_strName;
            }
        }

        /// <summary>
        /// パスワード
        /// </summary>
        public string _Password
        {
            set
            {
                this.m_strPassword = value;
            }
            get
            {
                return this.m_strPassword;
            }
        }

        /// <summary>
        /// ポート番号（デフォルト）
        /// </summary>
        public int _Port
        {
            set
            {
                this.m_iPort = value;
            }
            get
            {
                return this.m_iPort;
            }
        }

        /// <summary>
        /// メールアドレス
        /// </summary>
        public string _Mail
        {
            set
            {
                this.m_strMail = value;
            }
            get
            {
                return this.m_strMail;
            }
        }

        /// <summary>
        /// SSLフラグ
        /// </summary>
        public bool _SSLFlg
        {
            set
            {
                this.m_blSslFlg = value;
            }
            get
            {
                return this.m_blSslFlg;
            }
        }

        /// <summary>
        /// 使用フラグ
        /// </summary>
        public bool _UseFlg
        {
            set
            {
                this.m_blUseFlg = value;
            }
            get
            {
                return this.m_blUseFlg;
            }
        }


        #endregion
    }

    /// <summary>
    /// Twitterログインデータ
    /// </summary>
    public class TwitterLoginData
    {
        /// <summary>
        /// 使用レベル
        /// </summary>
        public enum _USE_LEVEL
        {
            /// <summary>
            /// 未承認
            /// </summary>
            NOT_USE,
            /// <summary>
            /// 使用可
            /// </summary>
            USE,
            /// <summary>
            /// メイン
            /// </summary>
            MAIN
        }


        /// <summary>
        /// キー（TODO 該当キーに書き直し）
        /// </summary>
        public const string _CONSUMER_KEY = "";
        /// <summary>
        /// 隠匿キー（TODO 該当キーに書き直し）
        /// </summary>
        public const string _CONSUMER_SECRET = "";

        /// <summary>
        /// リクエストトークン
        /// </summary>
        public string _TOKEN { set; get; }

        /// <summary>
        /// リクエストトークン
        /// </summary>
        public string _TOKEN_SECRET { set; get; }

        /// <summary>
        /// ユーザID
        /// </summary>
        public string _USER_ID { set; get; }

        /// <summary>
        /// 名前
        /// </summary>
        public string _NAME { set; get; }

        /// <summary>
        /// 使用フラグ
        /// </summary>
        public _USE_LEVEL _USELEVEL { set; get; }
    }

    /// <summary>
    /// 番組データ
    /// </summary>
    public class AGData
    {
        #region [ パブリック定数 ]

        /// <summary>
        /// 週データ
        /// </summary>
        public enum WeekDay
        {
            /// <summary>
            /// 月
            /// </summary>
            Monday = 0,
            /// <summary>
            /// 火
            /// </summary>
            Tuesday,
            /// <summary>
            /// 水
            /// </summary>
            Wednesday,
            /// <summary>
            /// 木
            /// </summary>
            Thursday,
            /// <summary>
            /// 金
            /// </summary>
            Friday,
            /// <summary>
            /// 土
            /// </summary>
            Saturday,
            /// <summary>
            /// 日
            /// </summary>
            Sunday
        }

        #endregion

        #region [ プライベートインスタンス ]

        /// <summary>
        /// 曜日
        /// </summary>
        private WeekDay m_weekDay = WeekDay.Monday;

        /// <summary>
        /// 時間
        /// </summary>
        private string m_strTime = string.Empty;

        /// <summary>
        /// 番組名
        /// </summary>
        private string m_strName = string.Empty;

        /// <summary>
        /// 生放送フラグ
        /// </summary>
        private bool m_blLive = false;

        /// <summary>
        /// リピート放送フラグ
        /// </summary>
        private bool m_blRepeat = false;

        /// <summary>
        /// 映像フラグ
        /// </summary>
        private bool m_blMovie = false;

        /// <summary>
        /// ブログURL
        /// </summary>
        private string m_strBlog = string.Empty;

        /// <summary>
        /// メールアドレス
        /// </summary>
        private string m_strMail = string.Empty;

        /// <summary>
        /// ハッシュタグ
        /// </summary>
        private string m_strHashTag = string.Empty;

        #endregion

        #region [ アクセサ ]

        /// <summary>
        /// 曜日
        /// </summary>
        public WeekDay _WeekDay
        {
            set
            {
                this.m_weekDay = value;
            }
            get
            {
                return this.m_weekDay;
            }
        }

        /// <summary>
        /// 時間
        /// </summary>
        public string _Time
        {
            set
            {
                this.m_strTime = value;
            }
            get
            {
                return this.m_strTime;
            }
        }

        /// <summary>
        /// 番組名
        /// </summary>
        public string _Name
        {
            set
            {
                this.m_strName = value;
            }
            get
            {
                return this.m_strName;
            }
        }

        /// <summary>
        /// 生放送フラグ
        /// </summary>
        public bool _Live
        {
            set
            {
                this.m_blLive = value;
            }
            get
            {
                return this.m_blLive;
            }
        }

        /// <summary>
        /// リピート放送フラグ
        /// </summary>
        public bool _Repeat
        {
            set
            {
                this.m_blRepeat = value;
            }
            get
            {
                return this.m_blRepeat;
            }
        }

        /// <summary>
        /// 映像フラグ
        /// </summary>
        public bool _Movie
        {
            set
            {
                this.m_blMovie = value;
            }
            get
            {
                return this.m_blMovie;
            }
        }

        /// <summary>
        /// ブログURL
        /// </summary>
        public string _Blog
        {
            set
            {
                this.m_strBlog = value;
            }
            get
            {
                return this.m_strBlog;
            }
        }

        /// <summary>
        /// メールアドレス
        /// </summary>
        public string _Mail
        {
            set
            {
                this.m_strMail = value;
            }
            get
            {
                return this.m_strMail;
            }
        }

        /// <summary>
        /// ハッシュタグ
        /// </summary>
        public string _HashTag
        {
            set
            {
                this.m_strHashTag = value;
            }
            get
            {
                return this.m_strHashTag;
            }
        }

        #endregion

        #region [ パブリックメソッド ]

        /// <summary>
        /// 曜日設定
        /// </summary>
        /// <param name="strDate">日付</param>
        public void SetWeekDay(string strDate)
        {
            if (strDate == Resources.WEEK_MONDAY)
            {
                this.m_weekDay = WeekDay.Monday;
            }
            else if (strDate == Resources.WEEK_TUESDAY)
            {
                this.m_weekDay = WeekDay.Tuesday;
            }
            else if (strDate == Resources.WEEK_WEDNESDAY)
            {
                this.m_weekDay = WeekDay.Wednesday;
            }
            else if (strDate == Resources.WEEK_THURSDAY)
            {
                this.m_weekDay = WeekDay.Thursday;
            }
            else if (strDate == Resources.WEEK_FRIDAY)
            {
                this.m_weekDay = WeekDay.Friday;
            }
            else if (strDate == Resources.WEEK_SATURDAY)
            {
                this.m_weekDay = WeekDay.Saturday;
            }
            else if (strDate == Resources.WEEK_SUNDAY)
            {
                this.m_weekDay = WeekDay.Sunday;
            }
        }

        /// <summary>
        /// 曜日取得
        /// </summary>
        public string GetWeekDay()
        {
            if (this.m_weekDay == WeekDay.Monday)
            {
                return Resources.WEEK_MONDAY;
            }
            else if (this.m_weekDay == WeekDay.Tuesday)
            {
                return Resources.WEEK_TUESDAY;
            }
            else if (this.m_weekDay == WeekDay.Wednesday)
            {
                return Resources.WEEK_WEDNESDAY;
            }
            else if (this.m_weekDay == WeekDay.Thursday)
            {
                return Resources.WEEK_THURSDAY;
            }
            else if (this.m_weekDay == WeekDay.Friday)
            {
                return Resources.WEEK_FRIDAY;
            }
            else if (this.m_weekDay == WeekDay.Saturday)
            {
                return Resources.WEEK_SATURDAY;
            }
            else if (this.m_weekDay == WeekDay.Sunday)
            {
                return Resources.WEEK_SUNDAY;
            }
            return string.Empty;
        }

        /// <summary>
        /// 曜日確認
        /// </summary>
        /// <param name="strWeek">確認曜日</param>
        /// <returns>true=曜日一致, false=曜日不一致</returns>
        public bool CheckWeekDay(string strWeek)
        {
            if (this.m_weekDay == WeekDay.Monday && strWeek == Resources.WEEK_MONDAY)
            {
                return true;
            }
            else if (this.m_weekDay == WeekDay.Tuesday && strWeek == Resources.WEEK_TUESDAY)
            {
                return true;
            }
            else if (this.m_weekDay == WeekDay.Wednesday && strWeek == Resources.WEEK_WEDNESDAY)
            {
                return true;
            }
            else if (this.m_weekDay == WeekDay.Thursday && strWeek == Resources.WEEK_THURSDAY)
            {
                return true;
            }
            else if (this.m_weekDay == WeekDay.Friday && strWeek == Resources.WEEK_FRIDAY)
            {
                return true;
            }
            else if (this.m_weekDay == WeekDay.Saturday && strWeek == Resources.WEEK_SATURDAY)
            {
                return true;
            }
            else if (this.m_weekDay == WeekDay.Sunday && strWeek == Resources.WEEK_SUNDAY)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 曜日データ取得
        /// </summary>
        /// <returns>曜日リスト</returns>
        public static string[] GetWeekDayResource()
        {
            return new string[] { Resources.WEEK_MONDAY, Resources.WEEK_TUESDAY, Resources.WEEK_WEDNESDAY,
                    Resources.WEEK_THURSDAY, Resources.WEEK_FRIDAY, Resources.WEEK_SATURDAY, Resources.WEEK_SUNDAY};
        }

        #endregion
    }

    /// <summary>
    /// バージョンデータ
    /// </summary>
    public class VersionData
    {
        #region [ プライベートインスタンス ]

        /// <summary>
        /// バージョン（メジャーバージョン）
        /// </summary>
        private int m_iVersion_1st = 0;

        /// <summary>
        /// バージョン（マイナーバージョン）
        /// </summary>
        private int m_iVersion_2nd = 0;

        /// <summary>
        /// バージョン（ビルドバージョン）
        /// </summary>
        private int m_iVersion_3rd = 0;

        #endregion

        #region [ アクセサ ]

        /// <summary>
        /// バージョン（メジャーバージョン）
        /// </summary>
        public int _Version1st
        {
            set
            {
                this.m_iVersion_1st = value;
            }
            get
            {
                return this.m_iVersion_1st;
            }
        }

        /// <summary>
        /// バージョン（マイナーバージョン）
        /// </summary>
        public int _Version2nd
        {
            set
            {
                this.m_iVersion_2nd = value;
            }
            get
            {
                return this.m_iVersion_2nd;
            }
        }

        /// <summary>
        /// バージョン（ビルドバージョン）
        /// </summary>
        public int _Version3rd
        {
            set
            {
                this.m_iVersion_3rd = value;
            }
            get
            {
                return this.m_iVersion_3rd;
            }
        }

        #endregion
    }

    /// <summary>
    /// 送信メールデータ
    /// </summary>
    public class SendMailData
    {
        #region [ プライベートインスタンス ]

        /// <summary>
        /// 送信日付
        /// </summary>
        private DateTime m_dt = new DateTime();

        /// <summary>
        /// タイトル
        /// </summary>
        private string m_strTitle = string.Empty;

        /// <summary>
        /// メッセージ
        /// </summary>
        private string m_strMsg = string.Empty;

        /// <summary>
        /// 送信先番組名
        /// </summary>
        private string m_strInfo = string.Empty;

        #endregion

        #region [ アクセサ ]

        /// <summary>
        /// 送信日付
        /// </summary>
        public DateTime _Dt
        {
            set
            {
                this.m_dt = value;
            }
            get
            {
                return this.m_dt;
            }
        }

        /// <summary>
        /// タイトル
        /// </summary>
        public string _Title
        {
            set
            {
                this.m_strTitle = value;
            }
            get
            {
                return this.m_strTitle;
            }
        }

        /// <summary>
        /// 本文
        /// </summary>
        public string _Msg
        {
            set
            {
                this.m_strMsg = value;
            }
            get
            {
                return this.m_strMsg;
            }
        }

        /// <summary>
        /// 送信先番組
        /// </summary>
        public string _Info
        {
            set
            {
                this.m_strInfo = value;
            }
            get
            {
                return this.m_strInfo;
            }
        }

        #endregion
    }

    /// <summary>
    /// 画面データ
    /// </summary>
    [DataContract]
    public class SettingData
    {
        #region [ 定数 ]

        /// <summary>
        /// Twitter表示
        /// </summary>
        public enum TwitterView
        {
            AGQR,
            TIMELINE
        }

        #endregion

        #region [ アクセサ ]

        /// <summary>
        /// Twitter表示内容
        /// </summary>
        [DataMember(Name = "twitterview")]
        public TwitterView _TwitterView { set; get; }

        /// <summary>
        /// Twitterロードフラグ
        /// </summary>
        [DataMember(Name = "twitterload")]
        public bool _TwitterLoad { set; get; }

        #endregion

        #region [ コンストラクタ ]

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public SettingData()
        {
            this._TwitterLoad = false;
            this._TwitterView = TwitterView.AGQR;
        }

        #endregion
    }

}
