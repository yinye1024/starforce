/*----------------------------------------------------------------
// Author：隐叶
// Copyright © 2023-2030 YinYe. All rights reserved.
//===============================================================
// 功能描述：
//
//----------------------------------------------------------------*/



namespace GameMain.Base
{
    public class DownloadMgr:Singleton<DownloadMgr>
    {
        public int GetCurSpeed()
        {
            return (int)GameCompMgr.Download.CurrentSpeed;
        }
    }
}