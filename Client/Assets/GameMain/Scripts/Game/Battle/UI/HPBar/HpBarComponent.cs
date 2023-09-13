/*----------------------------------------------------------------
// Author：隐叶
// Copyright © 2023-2030 YinYe. All rights reserved.
//===============================================================
// 功能描述：
// 血条控制，mono组件，提供所有血条 UI 的控制 
//----------------------------------------------------------------*/

using UnityEngine;
using UnityGameFramework.Runtime;

namespace GameMain.Game
{
    public class HpBarComponent : GameFrameworkComponent
    {
        [SerializeField]
        public HpBarItem hpBarItemTemplate = null;

        [SerializeField]
        public Transform hpBarInstanceRoot = null;

        [SerializeField]
        private int instancePoolCapacity = 16;

        private void Start()
        {
            if (hpBarInstanceRoot == null)
            {
                Log.Error("You must set HP bar instance root first.");
                return;
            }
            HpBarMgr.Instance.hpBarInstanceRoot = this.hpBarInstanceRoot;
            HpBarMgr.Instance.hpBarItemTemplate = this.hpBarItemTemplate;
            HpBarMgr.Instance.instancePoolCapacity = this.instancePoolCapacity;
            HpBarMgr.Instance.cachedCanvas = hpBarInstanceRoot.GetComponent<Canvas>();
        }

    }
}
