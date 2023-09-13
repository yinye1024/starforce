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
using UnityGameFramework.Runtime;

namespace GameMain.Game
{
    [Serializable]
    public abstract class AircraftData : TargetableObjectData
    {
        [SerializeField]
        private ThrusterData m_ThrusterData = null;

        [SerializeField]
        private List<WeaponData> m_WeaponDatas = new List<WeaponData>();

        [SerializeField]
        private List<ArmorData> m_ArmorDatas = new List<ArmorData>();

        [SerializeField]
        private int m_MaxHP = 0;

        [SerializeField]
        private int m_Defense = 0;

        [SerializeField]
        private int m_DeadEffectId = 0;

        [SerializeField]
        private int m_DeadSoundId = 0;

        public AircraftData(int entityId, int typeId, CampType camp)
            : base(entityId, typeId, camp)
        {
            IDataTable<DTAircraft> dataTable = DataTableMgr.Instance.GetDataTable<DTAircraft>();
            DTAircraft dtAircraft = dataTable.GetDataRow(TypeId);
            if (dtAircraft == null)
            {
                return;
            }

            m_ThrusterData = new ThrusterData(EntityBsMgr.GenerateSerialId(), dtAircraft.ThrusterId, Id, Camp);
            
            AttachWeaponData(new WeaponData(EntityBsMgr.GenerateSerialId(), dtAircraft.WeaponId0, Id, Camp));
            AttachWeaponData(new WeaponData(EntityBsMgr.GenerateSerialId(), dtAircraft.WeaponId1, Id, Camp));
            AttachWeaponData(new WeaponData(EntityBsMgr.GenerateSerialId(), dtAircraft.WeaponId2, Id, Camp));

            AttachArmorData(new ArmorData(EntityBsMgr.GenerateSerialId(), dtAircraft.ArmorId0, Id, Camp));
            AttachArmorData(new ArmorData(EntityBsMgr.GenerateSerialId(), dtAircraft.ArmorId1, Id, Camp));
            AttachArmorData(new ArmorData(EntityBsMgr.GenerateSerialId(), dtAircraft.ArmorId2, Id, Camp));
      
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
                return m_ThrusterData.Speed;
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

        public ThrusterData GetThrusterData()
        {
            return m_ThrusterData;
        }

        public List<WeaponData> GetAllWeaponDatas()
        {
            return m_WeaponDatas;
        }

        public void AttachWeaponData(WeaponData weaponData)
        {
            if (weaponData == null)
            {
                return;
            }

            if (m_WeaponDatas.Contains(weaponData))
            {
                return;
            }

            m_WeaponDatas.Add(weaponData);
        }

        public void DetachWeaponData(WeaponData weaponData)
        {
            if (weaponData == null)
            {
                return;
            }

            m_WeaponDatas.Remove(weaponData);
        }

        public List<ArmorData> GetAllArmorDatas()
        {
            return m_ArmorDatas;
        }

        public void AttachArmorData(ArmorData armorData)
        {
            if (armorData == null)
            {
                return;
            }

            if (m_ArmorDatas.Contains(armorData))
            {
                return;
            }

            m_ArmorDatas.Add(armorData);
            RefreshData();
        }

        public void DetachArmorData(ArmorData armorData)
        {
            if (armorData == null)
            {
                return;
            }

            m_ArmorDatas.Remove(armorData);
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
