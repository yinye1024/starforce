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
using UnityGameFramework.Runtime;

namespace GameMain.Game
{
    /// <summary>
    /// 战机类。
    /// </summary>
    public abstract class Aircraft : TargetableObject
    {
        [SerializeField]
        private AircraftData m_AircraftData = null;

        [SerializeField]
        protected Thruster m_Thruster = null;

        [SerializeField]
        protected List<Weapon> m_Weapons = new List<Weapon>();

        [SerializeField]
        protected List<Armor> m_Armors = new List<Armor>();

        protected override void OnShow(object userData)
        {
            base.OnShow(userData);

            m_AircraftData = userData as AircraftData;
            if (m_AircraftData == null)
            {
                Log.Error("Aircraft data is invalid.");
                return;
            }

            Name = Utility.Text.Format("Aircraft ({0})", Id);

            EntityBsMgr.ShowThruster(m_AircraftData.GetThrusterData());

            List<WeaponData> weaponDatas = m_AircraftData.GetAllWeaponDatas();
            for (int i = 0; i < weaponDatas.Count; i++)
            {
                EntityBsMgr.ShowWeapon(weaponDatas[i]);
            }

            List<ArmorData> armorDatas = m_AircraftData.GetAllArmorDatas();
            for (int i = 0; i < armorDatas.Count; i++)
            {
                EntityBsMgr.ShowArmor(armorDatas[i]);
            }
        }

        protected override void OnHide(bool isShutdown, object userData)
        {
            base.OnHide(isShutdown, userData);
        }

        protected override void OnAttached(EntityLogic childEntity, Transform parentTransform, object userData)
        {
            base.OnAttached(childEntity, parentTransform, userData);

            if (childEntity is Thruster)
            {
                m_Thruster = (Thruster)childEntity;
                return;
            }

            if (childEntity is Weapon)
            {
                m_Weapons.Add((Weapon)childEntity);
                return;
            }

            if (childEntity is Armor)
            {
                m_Armors.Add((Armor)childEntity);
                return;
            }
        }
        protected override void OnDetached(EntityLogic childEntity, object userData)
        {
            base.OnDetached(childEntity, userData);

            if (childEntity is Thruster)
            {
                m_Thruster = null;
                return;
            }

            if (childEntity is Weapon)
            {
                m_Weapons.Remove((Weapon)childEntity);
                return;
            }

            if (childEntity is Armor)
            {
                m_Armors.Remove((Armor)childEntity);
                return;
            }
        }

        protected override void OnDead(EntityLg attacker)
        {
            base.OnDead(attacker);

            EntityBsMgr.ShowEffect(new EffectData(EntityBsMgr.GenerateSerialId(), m_AircraftData.DeadEffectId)
            {
                Position = CachedTransform.localPosition,
            });
            SoundMgr.Instance.PlaySound(m_AircraftData.DeadSoundId);
        }

        public override ImpactData GetImpactData()
        {
            return new ImpactData(m_AircraftData.Camp, m_AircraftData.HP, 0, m_AircraftData.Defense);
        }
    }
}
