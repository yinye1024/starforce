/*----------------------------------------------------------------
// Author：隐叶
// Copyright © 2023-2030 YinYe. All rights reserved.
//===============================================================
// 功能描述：
//
//----------------------------------------------------------------*/


using DataTable;
using GameFramework.Event;
using GameMain.Base;
using UnityGameFramework.Runtime;

namespace GameMain.Game
{
    public class SceneLoader
    {
        public bool IsLoading { get; private set; } = false;

        public void LoadScene(DTScene dtScene)
        {
            if (!this.IsLoading)
            {
                IsLoading = true;
                EventMgr.Instance.Subscribe(LoadSceneSuccessEventArgs.EventId, OnLoadSceneSuccess);
                EventMgr.Instance.Subscribe(LoadSceneFailureEventArgs.EventId, OnLoadSceneFailure);
                EventMgr.Instance.Subscribe(LoadSceneUpdateEventArgs.EventId, OnLoadSceneUpdate);
                EventMgr.Instance.Subscribe(LoadSceneDependencyAssetEventArgs.EventId, OnLoadSceneDependencyAsset);
    
                SceneMgr.Instance.LoadScene(AssetPathUtils.GetSceneAsset(dtScene.AssetName), Constant.AssetPriority.SceneAsset, this);
            }
        }

        private void DoOnLoadFinish()
        {
            EventMgr.Instance.Unsubscribe(LoadSceneSuccessEventArgs.EventId, OnLoadSceneSuccess);
            EventMgr.Instance.Unsubscribe(LoadSceneFailureEventArgs.EventId, OnLoadSceneFailure);
            EventMgr.Instance.Unsubscribe(LoadSceneUpdateEventArgs.EventId, OnLoadSceneUpdate);
            EventMgr.Instance.Unsubscribe(LoadSceneDependencyAssetEventArgs.EventId, OnLoadSceneDependencyAsset);
            this.IsLoading = false;
        }
        
        private void OnLoadSceneSuccess(object sender, GameEventArgs e)
        {
            LoadSceneSuccessEventArgs ne = (LoadSceneSuccessEventArgs)e;
            if (ne.UserData != this)
            {
                return;
            }
        
            Log.Info("Load scene '{0}' OK.", ne.SceneAssetName);

            DoOnLoadFinish();
        }
        
        private void OnLoadSceneFailure(object sender, GameEventArgs e)
        {
            LoadSceneFailureEventArgs ne = (LoadSceneFailureEventArgs)e;
            if (ne.UserData != this)
            {
                return;
            }
        
            Log.Error("Load scene '{0}' failure, error message '{1}'.", ne.SceneAssetName, ne.ErrorMessage);
        }
        
        private void OnLoadSceneUpdate(object sender, GameEventArgs e)
        {
            LoadSceneUpdateEventArgs ne = (LoadSceneUpdateEventArgs)e;
            if (ne.UserData != this)
            {
                return;
            }
        
            Log.Info("Load scene '{0}' update, progress '{1}'.", ne.SceneAssetName, ne.Progress.ToString("P2"));
        }
        
        private void OnLoadSceneDependencyAsset(object sender, GameEventArgs e)
        {
            LoadSceneDependencyAssetEventArgs ne = (LoadSceneDependencyAssetEventArgs)e;
            if (ne.UserData != this)
            {
                return;
            }
        
            Log.Info("Load scene '{0}' dependency asset '{1}', count '{2}/{3}'.", ne.SceneAssetName, ne.DependencyAssetName, ne.LoadedCount.ToString(), ne.TotalCount.ToString());
        }

    }
}