/*----------------------------------------------------------------
// Author：隐叶
// Copyright © 2023-2030 YinYe. All rights reserved.
//===============================================================
// 功能描述：
//
//----------------------------------------------------------------*/


using GameFramework;
using GameFramework.Resource;
using GameMain.Base;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace GameMain.Game
{
    public class CheckVersionMgr:Singleton<CheckVersionMgr>
    {
        public bool CheckVersionComplete { get; private set; } = false;
        public bool NeedUpdateVersion { get; private set; } = false;
        public VersionInfo VersionInfo { get; private set; } = null;

        public void DoCheckVersion()
        {
            CheckVersionComplete = false;
            NeedUpdateVersion = false;
            VersionInfo = null;

            // 向服务器请求版本信息 获取 full 下面的 XXXVersion.txt 文件
            string url = BuiltinDataMgr.Instance.GetCheckVersionUrl();
            HttpMgr.Instance.DoHttpGet(url, OnWebRequestSuccess);
        }


        private void OnWebRequestSuccess(string respStr)
        {
            VersionInfo = VersionInfo.FromJson(respStr);
            if (VersionInfo == null)
            {
                Log.Error("Parse VersionInfo failure.");
                return;
            }

            Log.Info("Latest game version is '{0} ({1})', local game version is '{2} ({3})'.", VersionInfo.LatestGameVersion, VersionInfo.InternalGameVersion.ToString(), Version.GameVersion, Version.InternalGameVersion.ToString());

            if (VersionInfo.ForceUpdateGame)
            {
                // 需要强制更新游戏应用
                UIMgr.Instance.OpenDialog(new DialogParams
                {
                    Mode = 2,
                    Title = LocalizationMgr.Instance.GetString("ForceUpdate.Title"),
                    Message = LocalizationMgr.Instance.GetString("ForceUpdate.Message"),
                    ConfirmText = LocalizationMgr.Instance.GetString("ForceUpdate.UpdateButton"),
                    OnClickConfirm = GotoUpdateApp,
                    CancelText = LocalizationMgr.Instance.GetString("ForceUpdate.QuitButton"),
                    OnClickCancel = delegate (object userData) { UnityGameFramework.Runtime.GameEntry.Shutdown(ShutdownType.Quit); },
                },true);

                return;
            }

            // 设置资源更新下载地址
            ResMgr.Instance.SetUpdatePrefixUri(Utility.Path.GetRegularPath(VersionInfo.UpdatePrefixUri));

            CheckVersionComplete = true;
            NeedUpdateVersion = ResMgr.Instance.CheckVersionList(VersionInfo.InternalResourceVersion) == CheckVersionListResult.NeedUpdate;
        }
        
        private void GotoUpdateApp(object userData)
        {
            string url = BuiltinDataMgr.Instance.GetAppUrl();
            if (!string.IsNullOrEmpty(url))
            {
                Application.OpenURL(url);
            }
        }
    }
}