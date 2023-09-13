//------------------------------------------------------------
// Game Framework
// Copyright © 2013-2021 Jiang Yin. All rights reserved.
// Homepage: https://gameframework.cn/
// Feedback: mailto:ellan@gameframework.cn
//------------------------------------------------------------

using System;
using System.Collections.Generic;
using GameMain.Base;
using UnityGameFramework.Runtime;

namespace GameMain.Game
{
    public class TestObjectPool : Singleton<TestObjectPool>
    {


        private DateTime _lastDateTime = DateTime.UtcNow;
        private readonly List<TestObj> _objList = new();

        public void test()
        {
            ObjectPoolMgr.Instance.InitPool<TestObj>(3);

            for (int i = 0; i < 5; i++)
            {
                TestObj fromPool = ObjectPoolMgr.Instance.Spawn<TestObj>();
                _objList.Add(fromPool);
            }
            
        }

        public void check()
        {
            
            DateTime now = DateTime.UtcNow; // 获取当前UTC时间
            TimeSpan elapsedTime = now - _lastDateTime;
            double totalSeconds = elapsedTime.TotalSeconds;
            
            if (totalSeconds > 5)
            {
                this._lastDateTime = now;
                int count = ObjectPoolMgr.Instance.GetCount<TestObj>();
                Log.Info("count now:"+count);

                if (this._objList.Count > 0)
                {
                    foreach (TestObj item in this._objList)
                    {
                        ObjectPoolMgr.Instance.Unspawn(item);
                    }
                    this._objList.Clear();
                }

              
            }

        }
        
        

        private class TestObj : ObjectItem
        {
            public void OnCreate()
            {
                Log.Info("TestObj:OnCreate...");
            }

            public void OnSpawn()
            {
                Log.Info("TestObj:OnSpawn...");
            }

            public void OnUnSpawn()
            {
                Log.Info("TestObj:OnUnSpawn...");
            }

            public void OnRelease()
            {
                Log.Info("TestObj:OnRelease...");
            }
        }

    }
}
