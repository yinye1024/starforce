/*----------------------------------------------------------------
// Author：隐叶
// Copyright © 2023-2030 YinYe. All rights reserved.
//===============================================================
// 功能描述：
//
//----------------------------------------------------------------*/


using GameMain.Base;

namespace GameMain.Game
{
    public class AsteroidMgr:Singleton<AsteroidMgr>
    {
        public void ShowAsteroid( AsteroidBsData bsData)
        {
            EntityBsMgr.ShowEntity<AsteroidLg>(Constant.AssetPriority.AsteroiAsset, bsData);
        }
        
    }
}