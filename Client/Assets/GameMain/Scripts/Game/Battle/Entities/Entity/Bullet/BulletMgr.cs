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
    public class BulletMgr:Singleton<BulletMgr>
    {
        public void ShowBullet( BulletBsData bsData)
        {
            EntityBsMgr.ShowEntity<BulletLg>(Constant.AssetPriority.BulletAsset, bsData);
        }

    }
}