/*----------------------------------------------------------------
// Author：隐叶
// Copyright © 2023-2030 YinYe. All rights reserved.
//===============================================================
// 功能描述：
//
//----------------------------------------------------------------*/


using GameFramework.Event;
using GameMain.Base;
using UnityGameFramework.Runtime;

namespace GameMain.Game
{
    public class VerifyResourcesMgr:Singleton<VerifyResourcesMgr>
    {
        public bool VerifyResourcesComplete { get; set; } = false;

        public void DoVerify()
        {
            this.VerifyResourcesComplete = false;
            EventMgr.Instance.Subscribe(ResourceVerifyStartEventArgs.EventId, OnResourceVerifyStart);
            EventMgr.Instance.Subscribe(ResourceVerifySuccessEventArgs.EventId, OnResourceVerifySuccess);
            EventMgr.Instance.Subscribe(ResourceVerifyFailureEventArgs.EventId, OnResourceVerifyFailure);
         
            ResMgr.Instance.VerifyResources(OnVerifyResourcesComplete);
        }

        public void OnVerifyFinish()
        {
            this.VerifyResourcesComplete = true;
            EventMgr.Instance.Unsubscribe(ResourceVerifyStartEventArgs.EventId, OnResourceVerifyStart);
            EventMgr.Instance.Unsubscribe(ResourceVerifySuccessEventArgs.EventId, OnResourceVerifySuccess);
            EventMgr.Instance.Unsubscribe(ResourceVerifyFailureEventArgs.EventId, OnResourceVerifyFailure);
        }

        private void OnVerifyResourcesComplete(bool result)
        {
            OnVerifyFinish();
            Log.Info("Verify resources complete, result is '{0}'.", result);
        }

        private void OnResourceVerifyStart(object sender, GameEventArgs e)
        {
            ResourceVerifyStartEventArgs ne = (ResourceVerifyStartEventArgs)e;
            Log.Info("Start verify resources, verify resource count '{0}', verify resource total length '{1}'.", ne.Count, ne.TotalLength);
        }

        private void OnResourceVerifySuccess(object sender, GameEventArgs e)
        {
            ResourceVerifySuccessEventArgs ne = (ResourceVerifySuccessEventArgs)e;
            Log.Info("Verify resource '{0}' success.", ne.Name);
        }

        private void OnResourceVerifyFailure(object sender, GameEventArgs e)
        {
            ResourceVerifyFailureEventArgs ne = (ResourceVerifyFailureEventArgs)e;
            Log.Warning("Verify resource '{0}' failure.", ne.Name);
        }
    }
}