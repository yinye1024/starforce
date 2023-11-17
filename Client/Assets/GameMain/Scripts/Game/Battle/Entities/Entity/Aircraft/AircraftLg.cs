//------------------------------------------------------------
// Game Framework
// Copyright © 2013-2021 Jiang Yin. All rights reserved.
// Homepage: https://gameframework.cn/
// Feedback: mailto:ellan@gameframework.cn
//------------------------------------------------------------

using GameFramework;
using System.Collections.Generic;
using GameMain.Base;
using UnityEngine;
using UnityEngine.Serialization;
using UnityGameFramework.Runtime;

namespace GameMain.Game
{
    /// <summary>
    /// 战机类。
    /// </summary>
    public abstract class AircraftLg : TargetableEntityBsLg
    {
        [SerializeField]
        private AircraftBsData _mAircraftBsData = null;

        [FormerlySerializedAs("m_Thruster")] [SerializeField]
        protected ThrusterLg mThrusterLg = null;

        [SerializeField]
        protected List<WeaponLg> m_Weapons = new List<WeaponLg>();

        [SerializeField]
        protected List<ArmorLg> m_Armors = new List<ArmorLg>();

        protected override void OnShow(object userData)
        {
            base.OnShow(userData);

            _mAircraftBsData = userData as AircraftBsData;
            if (_mAircraftBsData == null)
            {
                Log.Error("Aircraft data is invalid.");
                return;
            }

            Name = Utility.Text.Format("Aircraft ({0})", Id);

            ThrusterMgr.Instance.ShowThruster(_mAircraftBsData.GetThrusterData());

            List<WeaponBsData> weaponDatas = _mAircraftBsData.GetAllWeaponDatas();
            for (int i = 0; i < weaponDatas.Count; i++)
            {
                WeaponMgr.Instance.ShowWeapon(weaponDatas[i]);
            }

            List<ArmorBsData> armorDatas = _mAircraftBsData.GetAllArmorDatas();
            for (int i = 0; i < armorDatas.Count; i++)
            {
                ArmorMgr.Instance.ShowArmor(armorDatas[i]);
            }
        }

        protected override void OnHide(bool isShutdown, object userData)
        {
            base.OnHide(isShutdown, userData);
        }

        protected override void OnAttached(EntityLogic childEntity, Transform parentTransform, object userData)
        {
            base.OnAttached(childEntity, parentTransform, userData);

            if (childEntity is ThrusterLg)
            {
                mThrusterLg = (ThrusterLg)childEntity;
                return;
            }

            if (childEntity is WeaponLg)
            {
                m_Weapons.Add((WeaponLg)childEntity);
                return;
            }

            if (childEntity is ArmorLg)
            {
                m_Armors.Add((ArmorLg)childEntity);
                return;
            }
        }
        protected override void OnDetached(EntityLogic childEntity, object userData)
        {
            base.OnDetached(childEntity, userData);

            if (childEntity is ThrusterLg)
            {
                mThrusterLg = null;
                return;
            }

            if (childEntity is WeaponLg)
            {
                m_Weapons.Remove((WeaponLg)childEntity);
                return;
            }

            if (childEntity is ArmorLg)
            {
                m_Armors.Remove((ArmorLg)childEntity);
                return;
            }
        }

        protected override void OnDead(EntityBsLg attacker)
        {
            base.OnDead(attacker);

            EffectMgr.Instance.ShowEffect(new EffectBsData(EntityBsMgr.GenerateSerialId(), _mAircraftBsData.DeadEffectId)
            {
                Position = CachedTransform.localPosition,
            });
            SoundMgr.Instance.PlaySound(_mAircraftBsData.DeadSoundId);
        }

        public override ImpactData GetImpactData()
        {
            return new ImpactData(_mAircraftBsData.Camp, _mAircraftBsData.HP, 0, _mAircraftBsData.Defense);
        }
    }
}
