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
    public class EffectMgr:Singleton<EffectMgr>
    {
        public void ShowEffect(EffectBsData bsData)
        {
            EntityBsMgr.ShowEntity<EffectLg>(Constant.AssetPriority.EffectAsset, bsData);
        }

    }
}