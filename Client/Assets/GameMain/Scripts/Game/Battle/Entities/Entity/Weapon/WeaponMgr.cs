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
    public class WeaponMgr:Singleton<WeaponMgr>
    {
        public void ShowWeapon(WeaponBsData bsData)
        {
            EntityBsMgr.ShowEntity<WeaponLg>(Constant.AssetPriority.WeaponAsset, bsData);
        }
        
        public void Attach(WeaponLg weaponLg, int ownerId, string parentTransformPath)
        {
            EntityBsMgr.AttachEntity(weaponLg.Id, ownerId, parentTransformPath);
        }
    }
}