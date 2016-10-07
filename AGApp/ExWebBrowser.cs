using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace AGApp
{
    /// <summary>
    /// 拡張ナビゲートイベント
    /// </summary>
    public class WebBrowserExtendedNavigatingEventArgs : CancelEventArgs
    {
        #region [ プライベートインスタンス ]

        /// <summary>
        /// URL
        /// </summary>
        private string strURL;

        /// <summary>
        /// フレーム名
        /// </summary>
        private string strFrame;

        #endregion

        #region [ アクセサ ]

        /// <summary>
        /// URL
        /// </summary>
        public string Url
        {
            get
            {
                return this.strURL;
            }
        }

        /// <summary>
        /// フレーム名
        /// </summary>
        public string Frame
        {
            get
            {
                return this.strFrame;
            }
        }

        #endregion

        #region [ コンストラクタ ]

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="url">URL</param>
        /// <param name="frame">フレーム名</param>
        public WebBrowserExtendedNavigatingEventArgs(string url, string frame)
            : base()
        {
            this.strURL = url;
            this.strFrame = frame;
        }

        #endregion
    }

    /// <summary>
    /// 拡張WebBrowser
    /// </summary>
    public partial class ExWebBrowser : WebBrowser
    {
        #region [ プライベートインスタンス ]

        /// <summary>
        /// Cookie
        /// </summary>
        private AxHost.ConnectionPointCookie cookie;

        /// <summary>
        /// 拡張イベント
        /// </summary>
        private WebBrowserExtendedEvents events;

        public string BeforeNavigateUrl
        {
            set;
            get;
        }

        #endregion

        #region [ 内部クラス、拡張イベント ]

        /// <summary>
        /// 拡張イベント
        /// </summary>
        class WebBrowserExtendedEvents : StandardOleMarshalObject, DWebBrowserEvents2
        {
            #region [ プライベートインスタンス ]

            /// <summary>
            /// 拡張ブラウザ
            /// </summary>
            ExWebBrowser browser;

            #endregion

            #region [ コンストラクタ ]

            /// <summary>
            /// コンストラクタ
            /// </summary>
            /// <param name="browser">拡張ブラウザ</param>
            public WebBrowserExtendedEvents(ExWebBrowser browser)
            {
                this.browser = browser;
            }

            #endregion

            #region [ イベント ]

            /// <summary>
            /// Navigate2イベント
            /// </summary>
            /// <param name="pDisp"></param>
            /// <param name="URL"></param>
            /// <param name="flags"></param>
            /// <param name="targetFrameName"></param>
            /// <param name="postData"></param>
            /// <param name="headers"></param>
            /// <param name="cancel"></param>
            public void BeforeNavigate2(object pDisp, ref object URL, ref object flags, ref object targetFrameName, ref object postData, ref object headers, ref bool cancel)
            {
                this.browser.OnBeforeNavigate((string)URL, (string)targetFrameName, out cancel);
            }

            /// <summary>
            /// NewWindow
            /// </summary>
            /// <param name="pDisp"></param>
            /// <param name="cancel"></param>
            /// <param name="flags"></param>
            /// <param name="URLContext"></param>
            /// <param name="URL"></param>
            public void NewWindow3(object pDisp, ref bool cancel, ref object flags, ref object URLContext, ref object URL)
            {
                this.browser.OnBeforeNewWindow((string)URL, out cancel);
            }

            #endregion

        }

        #endregion

        [ComImport(), Guid("34A715A0-6587-11D0-924A-0020AFC7AC4D"),
        InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch),
        TypeLibType(TypeLibTypeFlags.FHidden)]
        public interface DWebBrowserEvents2
        {

            [DispId(250)]
            void BeforeNavigate2(
                [In,
                MarshalAs(UnmanagedType.IDispatch)] object pDisp,
                [In] ref object URL,
                [In] ref object flags,
                [In] ref object targetFrameName, [In] ref object postData,
                [In] ref object headers,
                [In,
                Out] ref bool cancel);
            [DispId(273)]
            void NewWindow3(
                [In,
                MarshalAs(UnmanagedType.IDispatch)] object pDisp,
                [In, Out] ref bool cancel,
                [In] ref object flags,
                [In] ref object URLContext,
                [In] ref object URL);
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public ExWebBrowser()
        {
            // スクリプトエラーの非表示化
            this.ScriptErrorsSuppressed = true;
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }


        protected override void CreateSink()
        {
            base.CreateSink();
            events = new WebBrowserExtendedEvents(this);
            cookie = new AxHost.ConnectionPointCookie(this.ActiveXInstance, events, typeof(DWebBrowserEvents2));
        }

        protected override void DetachSink()
        {
            if (null != cookie)
            {
                cookie.Disconnect();
                cookie = null;
            }
            base.DetachSink();
        }

        //This new event will fire when the page is navigating
        public event EventHandler BeforeNavigate;
        public event EventHandler BeforeNewWindow;

        protected void OnBeforeNewWindow(string url, out bool cancel)
        {
            EventHandler h = BeforeNewWindow;
            WebBrowserExtendedNavigatingEventArgs args = new WebBrowserExtendedNavigatingEventArgs(url, null);
            if (null != h)
            {
                h(this, args);
            }
            cancel = args.Cancel;
        }

        protected void OnBeforeNavigate(string url, string frame, out bool cancel)
        {
            EventHandler h = BeforeNavigate;
            WebBrowserExtendedNavigatingEventArgs args = new WebBrowserExtendedNavigatingEventArgs(url, frame);
            Console.WriteLine("ブラウザ遷移先：" + url);
            this.BeforeNavigateUrl = url;
            if (null != h)
            {
                h(this, args);
            }
            //Pass the cancellation chosen back out to the events
            cancel = args.Cancel;
        }
    }

}
