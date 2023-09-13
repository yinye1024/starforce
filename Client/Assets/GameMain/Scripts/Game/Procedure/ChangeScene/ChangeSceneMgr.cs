/*----------------------------------------------------------------
// Author：隐叶
// Copyright © 2023-2030 YinYe. All rights reserved.
//===============================================================
// 功能描述：
//
//----------------------------------------------------------------*/


using DataTable;
using GameMain.Base;

namespace GameMain.Game
{
    public class ChangeSceneMgr:Singleton<ChangeSceneMgr>
    {
        private readonly SceneLoader _sceneLoader = new();
        private int _backgroundMusicId = 0;

        public bool IsLoading()
        {
            return this._sceneLoader.IsLoading;
        }

        public void PlayBackGroundMusic()
        {
          
            if (this._backgroundMusicId > 0)
            {
                SoundMgr.Instance.PlayMusic(this._backgroundMusicId);
            }
        }

        public void DoChangeScene(DTScene dtScene)
        {
            
            // 停止所有声音
            SoundMgr.Instance.StopAllSounds();
            
            // 隐藏所有实体
            EntityBsMgr.HideAll();
            
            // 卸载所有场景
            SceneMgr.Instance.UnloadAll();
            
            // 还原游戏速度
            BaseMgr.Instance.ResetNormalGameSpeed();
            
            this._sceneLoader.LoadScene(dtScene);
            _backgroundMusicId = dtScene.BackgroundMusicId;
        }
    }
}