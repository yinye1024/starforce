/*----------------------------------------------------------------
// Author：隐叶
// Copyright © 2023-2030 YinYe. All rights reserved.
//===============================================================
// 功能描述：
//
//----------------------------------------------------------------*/


using System;
using GameFramework;
using GameFramework.Event;
using UnityGameFramework.Runtime;

namespace GameMain.Base
{
    internal class HttpGetWrapper
    {
        private readonly Action<string> _successAction;

        public static HttpGetWrapper New (Action<string> successActionP)
        {
            return new HttpGetWrapper(successActionP);
        }

        private HttpGetWrapper(Action<string> successActionP)
        {
            this._successAction = successActionP;
        }

        public void DoReq(string url)
        {
            EventMgr.Instance.Subscribe(WebRequestSuccessEventArgs.EventId, OnWebRequestSuccess);
            EventMgr.Instance.Subscribe(WebRequestFailureEventArgs.EventId, OnWebRequestFailure);
            
            GameCompMgr.WebRequest.AddWebRequest(url, this);
        }
        private void DoUnSubscribe()
        {
            EventMgr.Instance.Unsubscribe(WebRequestSuccessEventArgs.EventId, OnWebRequestSuccess);
            EventMgr.Instance.Unsubscribe(WebRequestFailureEventArgs.EventId, OnWebRequestFailure);
        }
        
        private void OnWebRequestSuccess(object sender, GameEventArgs e)
        {
            WebRequestSuccessEventArgs ne = (WebRequestSuccessEventArgs)e;
            if (ne.UserData != this)
            {
                return;
            }

            // 解析版本信息
            byte[] resultBytes = ne.GetWebResponseBytes();
            string respStr = Utility.Converter.GetString(resultBytes);
            this._successAction(respStr);
            this.DoUnSubscribe();
        }

        private void OnWebRequestFailure(object sender, GameEventArgs e)
        {
            WebRequestFailureEventArgs ne = (WebRequestFailureEventArgs)e;
            if (ne.UserData != this)
            {
                return;
            }
            this.DoUnSubscribe();
            Log.Warning("Web request fail, ErrorMessage is '{0}'.", ne.ErrorMessage);
        }


    }
}