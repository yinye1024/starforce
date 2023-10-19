//------------------------------------------------------------
// Game Framework
// Copyright © 2013-2021 Jiang Yin. All rights reserved.
// Homepage: https://gameframework.cn/
// Feedback: mailto:ellan@gameframework.cn
//------------------------------------------------------------

using GameFramework.Resource;
using GameMain.Base;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace GameMain.Test
{
    public class TestSetting : Singleton<TestSetting>
    {
        public void Test()
        {
            bool hasAccount = SettingMgr.Instance.HasSetting("account");
            Log.Info("has account:"+hasAccount);
            SettingMgr.Instance.SetString("account","tt@aa.com");
            SettingMgr.Instance.Save();
        }

    }
}
