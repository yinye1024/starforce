/*----------------------------------------------------------------
// Author：隐叶
// Copyright © 2023-2030 YinYe. All rights reserved.
//===============================================================
// 功能描述：
//  base 组件的接口封装
//----------------------------------------------------------------*/


using GameFramework.Localization;

namespace GameMain.Base
{
    public class BaseMgr:Singleton<BaseMgr>
    {
        public Language GetEditorLanguage()
        {
            return GameCompMgr.Base.EditorLanguage;
        }

        public bool IsEditorResourceMode()
        {
            return GameCompMgr.Base.EditorResourceMode;
        }

        public void ResumeGame()
        {
            GameCompMgr.Base.ResumeGame();
        }
        public void PauseGame()
        {
            GameCompMgr.Base.PauseGame();
        }
        public void ResetNormalGameSpeed()
        {
            GameCompMgr.Base.ResetNormalGameSpeed();
        }

    }
}