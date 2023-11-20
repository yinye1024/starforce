/*----------------------------------------------------------------
// Author：隐叶
// Copyright © 2023-2030 YinYe. All rights reserved.
//===============================================================
// 功能描述：
//
//----------------------------------------------------------------*/


using GameFramework.Event;
using GameMain.Base;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace GameMain.Test.Event
{
    public class TestEventMgr : Singleton<TestEventMgr>
    {
        private float _accTime = 0;
        public void OnEnter()
        {
            TestEventBsMgr.Instance.Subscribe();
        }

        
        public void OnUpdate()
        {
          
            this._accTime += Time.deltaTime;
            if (this._accTime > 5.0f)
            {
                this._accTime = 0;
                TestEventBsMgr.FireEvent(this);
            }
        }



    }
}