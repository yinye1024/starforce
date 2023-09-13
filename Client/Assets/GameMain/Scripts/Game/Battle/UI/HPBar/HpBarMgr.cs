/*----------------------------------------------------------------
// Author：隐叶
// Copyright © 2023-2030 YinYe. All rights reserved.
//===============================================================
// 功能描述：
//  提供 HpBar 的业务对外接口
//----------------------------------------------------------------*/


using System.Collections.Generic;
using GameMain.Base;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace GameMain.Game
{
    public class HpBarMgr:Singleton<HpBarMgr>,MonoBehavAgent
    {
        public HpBarItem hpBarItemTemplate = null;

        public Transform hpBarInstanceRoot = null;

        public int instancePoolCapacity = 16;

        private List<HPBarPObj> _activeHpBarItems = new();
        public Canvas cachedCanvas = null;

        public void Start()
        {
            if (hpBarInstanceRoot == null)
            {
                Log.Error("You must set HP bar instance root first.");
                return;
            }

            ObjectPoolMgr.Instance.InitPool<HPBarPObj>(instancePoolCapacity);
        }

        public void Update()
        {
            for (int i = _activeHpBarItems.Count - 1; i >= 0; i--)
            {
                HPBarPObj hpBarPObj = _activeHpBarItems[i];
                if (hpBarPObj.HpBarItem.Refresh())
                {
                    continue;
                }

                HideHPBar(hpBarPObj);
            }
        }

        public void ShowHPBar(EntityLg entityLg, float fromHPRatio, float toHPRatio)
        {
            if (entityLg == null)
            {
                Log.Warning("Entity is invalid.");
                return;
            }

            HPBarPObj hpBarPObj = GetActiveHpBarPObj(entityLg);
            if (hpBarPObj == null)
            {
                hpBarPObj = NewHpBarPObj();
                _activeHpBarItems.Add(hpBarPObj);
            }

            hpBarPObj.HpBarItem.Init(entityLg, cachedCanvas, fromHPRatio, toHPRatio);
        }

        private void HideHPBar(HPBarPObj hpBarPObj)
        {
            _activeHpBarItems.Remove(hpBarPObj);
            ObjectPoolMgr.Instance.Unspawn(hpBarPObj);
        }

        private HPBarPObj GetActiveHpBarPObj(EntityLg entityLg)
        {
            if (entityLg == null)
            {
                return null;
            }

            for (int i = 0; i < _activeHpBarItems.Count; i++)
            {
                if (_activeHpBarItems[i].HpBarItem.Owner == entityLg)
                {
                    return _activeHpBarItems[i];
                }
            }

            return null;
        }

        private HPBarPObj NewHpBarPObj()
        {
            HPBarPObj hpBarPObj = ObjectPoolMgr.Instance.Spawn<HPBarPObj>();
            if (hpBarPObj.HpBarItem == null)
            {
                HpBarItem hpBarItem  = Object.Instantiate(hpBarItemTemplate);
                Transform transformTmp = hpBarItem.GetComponent<Transform>();
                transformTmp.SetParent(hpBarInstanceRoot);
                transformTmp.localScale = Vector3.one;
                hpBarPObj.HpBarItem = hpBarItem;
            }
            return hpBarPObj;
        }
    }
}