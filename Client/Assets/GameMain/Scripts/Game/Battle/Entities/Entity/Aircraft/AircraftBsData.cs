//------------------------------------------------------------
// Game Framework
// Copyright © 2013-2021 Jiang Yin. All rights reserved.
// Homepage: https://gameframework.cn/
// Feedback: mailto:ellan@gameframework.cn
//------------------------------------------------------------

using GameFramework.DataTable;
using System;
using System.Collections.Generic;
using DataTable;
using GameMain.Base;
using UnityEngine;
using UnityEngine.Serialization;
using UnityGameFramework.Runtime;

namespace GameMain.Game
{
    [Serializable]
    public abstract class AircraftBsData : TargetableEntityBsData
    {
        [FormerlySerializedAs("m_ThrusterData")] [SerializeField]
        private ThrusterBsData mThrusterBsData = null;

        [SerializeField]
        private List<WeaponBsData> m_WeaponDatas = new List<WeaponBsData>();

        [SerializeField]
        private List<ArmorBsData> m_ArmorDatas = new List<ArmorBsData>();

        [SerializeField]
        private int m_MaxHP = 0;

        [SerializeField]
        private int m_Defense = 0;

        [SerializeField]
        private int m_DeadEffectId = 0;

        [SerializeField]
        private int m_DeadSoundId = 0;

        public AircraftBsData(int entityId, int typeId, CampType camp)
            : base(entityId, typeId, camp)
        {
            IDataTable<DTAircraft> dataTable = DataTableMgr.Instance.GetDataTable<DTAircraft>();
            DTAircraft dtAircraft = dataTable.GetDataRow(TypeId);
            if (dtAircraft == null)
            {
                return;
            }

            mThrusterBsData = new ThrusterBsData(EntityBsMgr.GenerateSerialId(), dtAircraft.ThrusterId, Id, Camp);
            
            AttachWeaponData(new WeaponBsData(EntityBsMgr.GenerateSerialId(), dtAircraft.WeaponId0, Id, Camp));
            AttachWeaponData(new WeaponBsData(EntityBsMgr.GenerateSerialId(), dtAircraft.WeaponId1, Id, Camp));
            AttachWeaponData(new WeaponBsData(EntityBsMgr.GenerateSerialId(), dtAircraft.WeaponId2, Id, Camp));

            AttachArmorData(new ArmorBsData(EntityBsMgr.GenerateSerialId(), dtAircraft.ArmorId0, Id, Camp));
            AttachArmorData(new ArmorBsData(EntityBsMgr.GenerateSerialId(), dtAircraft.ArmorId1, Id, Camp));
            AttachArmorData(new ArmorBsData(EntityBsMgr.GenerateSerialId(), dtAircraft.ArmorId2, Id, Camp));
      
            m_DeadEffectId = dtAircraft.DeadEffectId;
            m_DeadSoundId = dtAircraft.DeadSoundId;

            HP = m_MaxHP;
        }

        /// <summary>
        /// 最大生命。
        /// </summary>
        public override int MaxHP
        {
            get
            {
                return m_MaxHP;
            }
        }

        /// <summary>
        /// 防御。
        /// </summary>
        public int Defense
        {
            get
            {
                return m_Defense;
            }
        }

        /// <summary>
        /// 速度。
        /// </summary>
        public float Speed
        {
            get
            {
                return mThrusterBsData.Speed;
            }
        }

        public int DeadEffectId
        {
            get
            {
                return m_DeadEffectId;
            }
        }

        public int DeadSoundId
        {
            get
            {
                return m_DeadSoundId;
            }
        }

        public ThrusterBsData GetThrusterData()
        {
            return mThrusterBsData;
        }

        public List<WeaponBsData> GetAllWeaponDatas()
        {
            return m_WeaponDatas;
        }

        public void AttachWeaponData(WeaponBsData weaponBsData)
        {
            if (weaponBsData == null)
            {
                return;
            }

            if (m_WeaponDatas.Contains(weaponBsData))
            {
                return;
            }

            m_WeaponDatas.Add(weaponBsData);
        }

        public void DetachWeaponData(WeaponBsData weaponBsData)
        {
            if (weaponBsData == null)
            {
                return;
            }

            m_WeaponDatas.Remove(weaponBsData);
        }

        public List<ArmorBsData> GetAllArmorDatas()
        {
            return m_ArmorDatas;
        }

        public void AttachArmorData(ArmorBsData armorBsData)
        {
            if (armorBsData == null)
            {
                return;
            }

            if (m_ArmorDatas.Contains(armorBsData))
            {
                return;
            }

            m_ArmorDatas.Add(armorBsData);
            RefreshData();
        }

        public void DetachArmorData(ArmorBsData armorBsData)
        {
            if (armorBsData == null)
            {
                return;
            }

            m_ArmorDatas.Remove(armorBsData);
            RefreshData();
        }

        private void RefreshData()
        {
            m_MaxHP = 0;
            m_Defense = 0;
            for (int i = 0; i < m_ArmorDatas.Count; i++)
            {
                m_MaxHP += m_ArmorDatas[i].MaxHP;
                m_Defense += m_ArmorDatas[i].Defense;
            }

            if (HP > m_MaxHP)
            {
                HP = m_MaxHP;
            }
        }
    }
}
