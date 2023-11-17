/*----------------------------------------------------------------
// Author：隐叶
// Copyright © 2023-2030 YinYe. All rights reserved.
//===============================================================
// 功能描述：
//
//----------------------------------------------------------------*/


using GameMain.Base;
using UnityGameFramework.Runtime;

namespace GameMain.Game
{
    public class ArmorMgr:Singleton<ArmorMgr>
    {
        public void ShowArmor(ArmorBsData bsData)
        {
            EntityBsMgr.ShowEntity<ArmorLg>(Constant.AssetPriority.ArmorAsset, bsData);
        }
        
        public void Attach(ArmorLg armorLg, int ownerId, string parentTransformPath)
        {
            EntityBsMgr.AttachEntity(armorLg.Id, ownerId, parentTransformPath);
        }

    }
}