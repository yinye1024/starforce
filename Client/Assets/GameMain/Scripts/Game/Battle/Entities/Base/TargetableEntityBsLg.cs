//------------------------------------------------------------
// Game Framework
// Copyright © 2013-2021 Jiang Yin. All rights reserved.
// Homepage: https://gameframework.cn/
// Feedback: mailto:ellan@gameframework.cn
//------------------------------------------------------------

using GameMain.Base;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace GameMain.Game
{
    /// <summary>
    /// 可作为目标的实体类。
    /// </summary>
    public abstract class TargetableEntityBsLg : EntityBsLg
    {
        [SerializeField]
        private TargetableEntityBsData _targetableEntityBsData = null;

        public bool IsDead
        {
            get
            {
                return _targetableEntityBsData.HP <= 0;
            }
        }

        public abstract ImpactData GetImpactData();

        public void ApplyDamage(EntityBsLg attacker, int damageHP)
        {
            float fromHPRatio = _targetableEntityBsData.HPRatio;
            _targetableEntityBsData.HP -= damageHP;
            float toHPRatio = _targetableEntityBsData.HPRatio;
            if (fromHPRatio > toHPRatio)
            {
                HpBarMgr.Instance.ShowHPBar(this, fromHPRatio, toHPRatio);
            }

            if (_targetableEntityBsData.HP <= 0)
            {
                OnDead(attacker);
            }
        }

        protected override void OnInit(object userData)
        {
            base.OnInit(userData);
            gameObject.SetLayerRecursively(Constant.Layer.TargetableObjectLayerId);
        }

        protected override void OnShow(object userData)
        {
            base.OnShow(userData);

            _targetableEntityBsData = userData as TargetableEntityBsData;
            if (_targetableEntityBsData == null)
            {
                Log.Error("Targetable object data is invalid.");
                return;
            }
        }

        protected virtual void OnDead(EntityBsLg attacker)
        {
            EntityBsMgr.HideEntity(this);
        }

        private void OnTriggerEnter(Collider other)
        {
            EntityBsLg entityBsLg = other.gameObject.GetComponent<EntityBsLg>();
            if (entityBsLg == null)
            {
                return;
            }

            if (entityBsLg is TargetableEntityBsLg && entityBsLg.Id >= Id)
            {
                // 碰撞事件由 Id 小的一方处理，避免重复处理
                return;
            }

            AIUtility.PerformCollision(this, entityBsLg);
        }
    }
}
