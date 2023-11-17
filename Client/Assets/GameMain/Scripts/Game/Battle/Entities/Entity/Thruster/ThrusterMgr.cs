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
    public class ThrusterMgr:Singleton<ThrusterMgr>
    {
        public void ShowThruster(ThrusterBsData bsData)
        {
            EntityBsMgr.ShowEntity<ThrusterLg>(Constant.AssetPriority.ThrusterAsset, bsData);
        }
        
        public void Attach(ThrusterLg thrusterLg, int ownerId, string parentTransformPath)
        {
            EntityBsMgr.AttachEntity(thrusterLg.Id, ownerId, parentTransformPath);
        }
    }
    
}