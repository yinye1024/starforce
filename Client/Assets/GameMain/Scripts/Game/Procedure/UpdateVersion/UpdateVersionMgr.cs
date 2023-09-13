/*----------------------------------------------------------------
// Author：隐叶
// Copyright © 2023-2030 YinYe. All rights reserved.
//===============================================================
// 功能描述：
//
//----------------------------------------------------------------*/


using GameFramework.Resource;
using GameMain.Base;
using UnityGameFramework.Runtime;

namespace GameMain.Game
{
    public class UpdateVersionMgr:Singleton<UpdateVersionMgr>
    {
        public bool UpdateVersionComplete = false;
        
        // 下载更新 GameFrameworkVersion.***.dat 文件到本地
        public void DoUpdate(  VersionInfo versionInfo)
        {
            UpdateVersionComplete = false;
            
            UpdateVersionListCallbacks updateVersionListCallbacks = new UpdateVersionListCallbacks(OnUpdateVersionListSuccess, OnUpdateVersionListFailure);
            
            ResMgr.Instance.UpdateVersionList(versionInfo.VersionListLength, versionInfo.VersionListHashCode, versionInfo.VersionListCompressedLength, 
                versionInfo.VersionListCompressedHashCode, updateVersionListCallbacks);
        }
        
        private void OnUpdateVersionListSuccess(string downloadPath, string downloadUri)
        {
            UpdateVersionComplete = true;
            Log.Info("Update version list from '{0}' success.", downloadUri);
        }

        private void OnUpdateVersionListFailure(string downloadUri, string errorMessage)
        {
            Log.Warning("Update version list from '{0}' failure, error message is '{1}'.", downloadUri, errorMessage);
        }
    }
}