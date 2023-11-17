//------------------------------------------------------------
// Game Framework
// Copyright © 2013-2021 Jiang Yin. All rights reserved.
// Homepage: https://gameframework.cn/
// Feedback: mailto:ellan@gameframework.cn
//------------------------------------------------------------

using GameFramework.DataTable;
using System;
using DataTable;
using GameMain.Base;
using UnityEngine;

namespace GameMain.Game
{
    [Serializable]
    public class ArmorBsData : EntityBsData
    {
        [SerializeField]
        private int m_OwnerId = 0;

        [SerializeField]
        private CampType m_OwnerCamp = CampType.Unknown;
        
        [SerializeField]
        private int m_MaxHP = 0;

        [SerializeField]
        private int m_Defense = 0;

        public ArmorBsData(int entityId, int typeId, int ownerId, CampType ownerCamp): base(entityId, typeId)
        {
            m_OwnerId = ownerId;
            m_OwnerCamp = ownerCamp;
            IDataTable<DTArmor> dataTable = DataTableMgr.Instance.GetDataTable<DTArmor>();
            DTArmor drArmor = dataTable.GetDataRow(TypeId);
            if (drArmor == null)
            {
                return;
            }

            m_MaxHP = drArmor.MaxHP;
            m_Defense = drArmor.Defense;
        }

        /// <summary>
        /// 最大生命。
        /// </summary>
        public int MaxHP
        {
            get
            {
                return m_MaxHP;
            }
        }

        /// <summary>
        /// 防御力。
        /// </summary>
        public int Defense
        {
            get
            {
                return m_Defense;
            }
        }
        /// <summary>
        /// 拥有者编号。
        /// </summary>
        public int OwnerId
        {
            get
            {
                return m_OwnerId;
            }
        }

        /// <summary>
        /// 拥有者阵营。
        /// </summary>
        public CampType OwnerCamp
        {
            get
            {
                return m_OwnerCamp;
            }
        }
    }
}
