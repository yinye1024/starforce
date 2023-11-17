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
    public class ThrusterBsData : EntityBsData
    {
        [SerializeField]
        private int m_OwnerId = 0;

        [SerializeField]
        private CampType m_OwnerCamp = CampType.Unknown;
        
        [SerializeField]
        private float m_Speed = 0f;

        public ThrusterBsData(int entityId, int typeId, int ownerId, CampType ownerCamp)
            : base(entityId, typeId)
        {
            m_OwnerId = ownerId;
            m_OwnerCamp = ownerCamp;
            
            IDataTable<DTThruster> dataTable = DataTableMgr.Instance.GetDataTable<DTThruster>();
            DTThruster drThruster = dataTable.GetDataRow(TypeId);
            if (drThruster == null)
            {
                return;
            }

            m_Speed = drThruster.Speed;
        }

        /// <summary>
        /// 速度。
        /// </summary>
        public float Speed
        {
            get
            {
                return m_Speed;
            }
        }
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
