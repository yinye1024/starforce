/*----------------------------------------------------------------
// Author：隐叶
// Copyright © 2023-2030 YinYe. All rights reserved.
//===============================================================
// 功能描述：
//  场景控制 加载和卸载等
//----------------------------------------------------------------*/


using UnityEngine;

namespace GameMain.Base
{
    public class SceneMgr:Singleton<SceneMgr>
    {
        public Vector3 WorldToScreenPoint(Vector3 worldPosition)
        {
            Vector3 screenPosition = GameCompMgr.Scene.MainCamera.WorldToScreenPoint(worldPosition);
            return screenPosition;
        }

        public void LoadScene(string sceneAssetName, int priority, object userData)
        {
            GameCompMgr.Scene.LoadScene(sceneAssetName,priority,userData);
        }

        public void UnloadAll()
        {
            string[] sceneAssetPath = GameCompMgr.Scene.GetLoadedSceneAssetNames();
            foreach (string assetPath in sceneAssetPath)
            {
                UnloadScene(assetPath);
            }
        }

        public void UnloadScene(string sceneAssetPath)
        {
            GameCompMgr.Scene.UnloadScene(sceneAssetPath);
        }

    }
}