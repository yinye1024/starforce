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
    public class MyAircraftMgr:Singleton<MyAircraftMgr>
    {
        public void ShowMyAircraft(MyAircraftBsData bsData)
        {
            EntityBsMgr.ShowEntity<MyAircraftLg>(Constant.AssetPriority.MyAircraftAsset, bsData);
        }
        
        
    }
}