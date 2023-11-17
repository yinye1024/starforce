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
    public class WeaponBsData : EntityBsData
    {
        [SerializeField]
        private int m_OwnerId = 0;

        [SerializeField]
        private CampType m_OwnerCamp = CampType.Unknown;
        
        [SerializeField]
        private int m_Attack = 0;

        [SerializeField]
        private float m_AttackInterval = 0f;

        [SerializeField]
        private int m_BulletId = 0;

        [SerializeField]
        private float m_BulletSpeed = 0f;

        [SerializeField]
        private int m_BulletSoundId = 0;

        public WeaponBsData(int entityId, int typeId, int ownerId, CampType ownerCamp)
            : base(entityId, typeId)
        {
            m_OwnerId = ownerId;
            m_OwnerCamp = ownerCamp;
            IDataTable<DTWeapon> dataTable = DataTableMgr.Instance.GetDataTable<DTWeapon>();
            DTWeapon drWeapon = dataTable.GetDataRow(TypeId);
            if (drWeapon == null)
            {
                return;
            }

            m_Attack = drWeapon.Attack;
            m_AttackInterval = drWeapon.AttackInterval;
            m_BulletId = drWeapon.BulletId;
            m_BulletSpeed = drWeapon.BulletSpeed;
            m_BulletSoundId = drWeapon.BulletSoundId;
        }

        /// <summary>
        /// 攻击力。
        /// </summary>
        public int Attack
        {
            get
            {
                return m_Attack;
            }
        }

        /// <summary>
        /// 攻击间隔。
        /// </summary>
        public float AttackInterval
        {
            get
            {
                return m_AttackInterval;
            }
        }

        /// <summary>
        /// 子弹编号。
        /// </summary>
        public int BulletId
        {
            get
            {
                return m_BulletId;
            }
        }

        /// <summary>
        /// 子弹速度。
        /// </summary>
        public float BulletSpeed
        {
            get
            {
                return m_BulletSpeed;
            }
        }

        /// <summary>
        /// 子弹声音编号。
        /// </summary>
        public int BulletSoundId
        {
            get
            {
                return m_BulletSoundId;
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
