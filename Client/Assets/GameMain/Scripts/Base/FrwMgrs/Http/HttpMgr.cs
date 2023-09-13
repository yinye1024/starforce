/*----------------------------------------------------------------
// Author：隐叶
// Copyright © 2023-2030 YinYe. All rights reserved.
//===============================================================
// 功能描述：
//  http 相关操作
//----------------------------------------------------------------*/


using System;

namespace GameMain.Base
{
    public class HttpMgr:Singleton<HttpMgr>
    {

        public void DoHttpGet(string url, Action<string> successAction)
        {
            HttpGetWrapper.New(successAction).DoReq(url);
        }
        
    }
}