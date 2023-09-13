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

namespace GameMain.Game
{
    public class TestResource : Singleton<TestResource>
    {
        public void LoadRes()
        {
            
            string assetPath = AssetPathUtils.GetConfigAsset("BuildInfo.txt");
           
            
            ResMgr.Instance.LoadAsset(assetPath, LoadAssetSuccessCallback, LoadAssetFailureCallback,this);
        }

        private void LoadAssetSuccessCallback(string assetName, object asset, float duration, object userData)
        {
            if (userData == this)
            {
                TextAsset tx = (TextAsset)asset;
                BuildInfo buildInfo = JsonUtils.ToObject<BuildInfo>(tx.text);
                Log.Info(buildInfo);
            }
        }

        private void LoadAssetFailureCallback(string assetName, LoadResourceStatus status, string errorMessage,
            object userData)
        {
            if (userData == this)
            {
                Log.Info("fail to load asset:"+assetName);
            }
        }

    }
}
