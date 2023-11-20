/*----------------------------------------------------------------
// Author：隐叶
// Copyright © 2023-2030 YinYe. All rights reserved.
//===============================================================
// 功能描述：
//
//----------------------------------------------------------------*/


using GameFramework;
using GameFramework.Event;
using GameMain.Base;
using UnityGameFramework.Runtime;

namespace GameMain.Test.Event
{
    public class TestEventBsMgr:Singleton<TestEventBsMgr>
    {
        public static void FireEvent(object sender)
        {
            // 系统在 fire event 的时候，会调用 ReferencePool.Release((IReference) e) ;
            // 所以业务这里只要 Acquire 就行了，不需要手动 release。
            TestEventArgs testEventArgs = ReferencePool.Acquire<TestEventArgs>();
            EventMgr.Instance.Fire(sender,testEventArgs);
        }
        public void Subscribe()
        {
            EventMgr.Instance.Subscribe(TestEventArgs.EventId,OnEventFire);
            
        }
       
        
        public void OnEventFire(object sender, GameEventArgs eventArgs)
        {
            TestEventArgs testEventArgs = (TestEventArgs)eventArgs;
            Log.Info("OnEventFire testEventArgs.PropA = "+testEventArgs.PropA);
        }
    }
}