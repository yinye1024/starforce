/*----------------------------------------------------------------
// Author：隐叶
// Copyright © 2023-2030 YinYe. All rights reserved.
//===============================================================
// 功能描述：
//
//----------------------------------------------------------------*/


using GameFramework;
using GameMain.Game;
using UnityEngine;

namespace GameMain.Base
{
    public class BuiltinDataMgr:Singleton<BuiltinDataMgr>
    {

        public void InitBuildInfo()
        {
            GameCompMgr.BuiltinData.InitBuildInfo();
        }
        public void InitDefaultDictionary()
        {
            GameCompMgr.BuiltinData.InitDefaultDictionary();
        }
        
        public UpdateResourceForm GetUpdateResourceFormTemplate()
        {
            return GameCompMgr.BuiltinData.UpdateResourceFormTemplate;
        }


        public string GetAppUrl()
        {
            string url = null;
                #if UNITY_EDITOR_WIN || UNITY_STANDALONE_WIN
                            url = GameCompMgr.BuiltinData.BuildInfo.WindowsAppUrl;
                #elif UNITY_EDITOR_OSX || UNITY_STANDALONE_OSX
                            url = GameEntry.BuiltinData.BuildInfo.MacOSAppUrl;
                #elif UNITY_IOS
                            url = GameEntry.BuiltinData.BuildInfo.IOSAppUrl;
                #elif UNITY_ANDROID
                            url = GameEntry.BuiltinData.BuildInfo.AndroidAppUrl;
                #endif
            return url;
        }

        public string GetCheckVersionUrl()
        {
            
            string checkVersionUrl =
                Utility.Text.Format(GameCompMgr.BuiltinData.BuildInfo.CheckVersionUrl, GetPlatformPath());
            return checkVersionUrl;
        }

        private string GetPlatformPath()
        {
            switch (Application.platform)
            {
                case RuntimePlatform.WindowsEditor:
                case RuntimePlatform.WindowsPlayer:
                    return "Windows";

                case RuntimePlatform.OSXEditor:
                case RuntimePlatform.OSXPlayer:
                    return "MacOS";

                case RuntimePlatform.IPhonePlayer:
                    return "IOS";

                case RuntimePlatform.Android:
                    return "Android";

                default:
                    throw new System.NotSupportedException(Utility.Text.Format("Platform '{0}' is not supported.", Application.platform));
            }
        }

      
    }
    
}