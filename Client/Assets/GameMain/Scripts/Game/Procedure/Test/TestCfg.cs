//------------------------------------------------------------
// Game Framework
// Copyright © 2013-2021 Jiang Yin. All rights reserved.
// Homepage: https://gameframework.cn/
// Feedback: mailto:ellan@gameframework.cn
//------------------------------------------------------------

using System.Collections.Generic;
using GameMain.Base;
using UnityGameFramework.Runtime;

namespace GameMain.Game
{
    public class TestCfg : Singleton<TestCfg>
    {
        private bool _doPrint = true;
        public void OnEnter()
        {
            ConfigMgr.Instance.LoadCfg(new List<string>{"DefaultConfig.txt","DefaultConfig_test.txt"});
        }

        
        public void OnUpdate()
        {
            if (!ConfigMgr.Instance.IsOnLoading && this._doPrint)
            {
                this._doPrint = false;
                Log.Info("load success "+ConfigMgr.Instance.GetString("Game.Id"));
                Log.Info("load success "+ConfigMgr.Instance.GetString("Scene.Test2"));
            }

        }

    }
}
