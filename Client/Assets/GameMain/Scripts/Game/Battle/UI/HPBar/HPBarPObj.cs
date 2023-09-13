/*----------------------------------------------------------------
// Author：隐叶
// Copyright © 2023-2030 YinYe. All rights reserved.
//===============================================================
// 功能描述：
// 包装 HpBarItem，作为对象池对象使用
//----------------------------------------------------------------*/


using GameMain.Base;

namespace GameMain.Game
{
    public class HPBarPObj : ObjectItem
    {
        public HpBarItem HpBarItem { get; set; }

        // 对象池接口
        public void OnCreate()
        {
            // do nothing
        }

        public void OnSpawn()
        {
            // do nothing
        }
        public void OnUnSpawn()
        {
            this.HpBarItem.Reset();
        }

        public void OnRelease()
        {
            this.HpBarItem.SelfDestroy();
        }
    }
}
