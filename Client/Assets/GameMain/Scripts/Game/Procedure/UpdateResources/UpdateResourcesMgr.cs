using GameFramework;
using GameFramework.Event;
using System.Collections.Generic;
using GameMain.Base;
using UnityEngine;
using UnityGameFramework.Runtime;
using ProcedureOwner = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;

namespace GameMain.Game
{
    public class UpdateResourcesMgr : Singleton<UpdateResourcesMgr>
    {
        public bool UpdateResourcesComplete { get; private set; } = false;
        private readonly UpdateResourcesUICtrl _updateResourcesUICtrl = new UpdateResourcesUICtrl();
        

        public void OnEnter(UpdateResourceInfo updateResourceInfo)
        {
            UpdateResourcesComplete = false;

            this._updateResourcesUICtrl.OnEnter(updateResourceInfo);
            
            EventMgr.Instance.Subscribe(ResourceUpdateStartEventArgs.EventId, OnResourceUpdateStart);
            EventMgr.Instance.Subscribe(ResourceUpdateChangedEventArgs.EventId, OnResourceUpdateChanged);
            EventMgr.Instance.Subscribe(ResourceUpdateSuccessEventArgs.EventId, OnResourceUpdateSuccess);
            EventMgr.Instance.Subscribe(ResourceUpdateFailureEventArgs.EventId, OnResourceUpdateFailure);

            if (Application.internetReachability == NetworkReachability.ReachableViaCarrierDataNetwork)
            { 
                
                UIMgr.Instance.OpenDialog(new DialogParams
                {
                    Mode = 2,
                    Title = LocalizationMgr.Instance.GetString("UpdateResourceViaCarrierDataNetwork.Title"),
                    Message = LocalizationMgr.Instance.GetString("UpdateResourceViaCarrierDataNetwork.Message"),
                    ConfirmText = LocalizationMgr.Instance.GetString("UpdateResourceViaCarrierDataNetwork.UpdateButton"),
                    OnClickConfirm = StartUpdateResources,
                    CancelText = LocalizationMgr.Instance.GetString("UpdateResourceViaCarrierDataNetwork.QuitButton"),
                    OnClickCancel = delegate (object userData) { UnityGameFramework.Runtime.GameEntry.Shutdown(ShutdownType.Quit); },
                },true);
                return;
            }

            StartUpdateResources(null);
        }
        
        private void StartUpdateResources(object userData)
        {
            Log.Info("Start update resources...");
            this._updateResourcesUICtrl.ShowUI();
            Log.Info("Start update resources...");
            ResMgr.Instance.UpdateResources(OnUpdateResourcesComplete);
        }

        public void OnLeave()
        {
            this._updateResourcesUICtrl.OnDestroy();

            EventMgr.Instance.Unsubscribe(ResourceUpdateStartEventArgs.EventId, OnResourceUpdateStart);
            EventMgr.Instance.Unsubscribe(ResourceUpdateChangedEventArgs.EventId, OnResourceUpdateChanged);
            EventMgr.Instance.Unsubscribe(ResourceUpdateSuccessEventArgs.EventId, OnResourceUpdateSuccess);
            EventMgr.Instance.Unsubscribe(ResourceUpdateFailureEventArgs.EventId, OnResourceUpdateFailure);
        }


        private void OnUpdateResourcesComplete(GameFramework.Resource.IResourceGroup resourceGroup, bool result)
        {
            if (result)
            {
                UpdateResourcesComplete = true;
                Log.Info("Update resources complete with no errors.");
            }
            else
            {
                Log.Error("Update resources complete with errors.");
            }
        }

        private void OnResourceUpdateStart(object sender, GameEventArgs e)
        {
            ResourceUpdateStartEventArgs ne = (ResourceUpdateStartEventArgs)e;
            this._updateResourcesUICtrl.OnResourceUpdateStart(ne);
        }

        private void OnResourceUpdateChanged(object sender, GameEventArgs e)
        {
            ResourceUpdateChangedEventArgs ne = (ResourceUpdateChangedEventArgs)e;
            this._updateResourcesUICtrl.OnResourceUpdateChanged(ne);
        }

        private void OnResourceUpdateSuccess(object sender, GameEventArgs e)
        {
            ResourceUpdateSuccessEventArgs ne = (ResourceUpdateSuccessEventArgs)e;
            Log.Info("Update resource '{0}' success.", ne.Name);
            this._updateResourcesUICtrl.OnResourceUpdateSuccess(ne);
        }

        private void OnResourceUpdateFailure(object sender, GameEventArgs e)
        {
            ResourceUpdateFailureEventArgs ne = (ResourceUpdateFailureEventArgs)e;
            if (ne.RetryCount >= ne.TotalRetryCount)
            {
                Log.Error("Update resource '{0}' failure from '{1}' with error message '{2}', retry count '{3}'.", ne.Name, ne.DownloadUri, ne.ErrorMessage, ne.RetryCount.ToString());
                return;
            }
            else
            {
                Log.Info("Update resource '{0}' failure from '{1}' with error message '{2}', retry count '{3}'.", ne.Name, ne.DownloadUri, ne.ErrorMessage, ne.RetryCount.ToString());
            }

            this._updateResourcesUICtrl.OnResourceUpdateFailure(ne);
        }

    }
}
