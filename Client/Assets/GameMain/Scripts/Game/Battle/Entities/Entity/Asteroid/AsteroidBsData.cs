﻿//------------------------------------------------------------
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
    public class AsteroidBsData : TargetableEntityBsData
    {
        [SerializeField]
        private int m_MaxHP = 0;

        [SerializeField]
        private int m_Attack = 0;

        [SerializeField]
        private float m_Speed = 0f;

        [SerializeField]
        private float m_AngularSpeed = 0f;

        [SerializeField]
        private int m_DeadEffectId = 0;

        [SerializeField]
        private int m_DeadSoundId = 0;

        public AsteroidBsData(int entityId, int typeId)
            : base(entityId, typeId, CampType.Neutral)
        {
            IDataTable<DTAsteroid> dataTable = DataTableMgr.Instance.GetDataTable<DTAsteroid>();
            DTAsteroid drAsteroid = dataTable.GetDataRow(TypeId);
            if (drAsteroid == null)
            {
                return;
            }

            HP = m_MaxHP = drAsteroid.MaxHP;
            m_Attack = drAsteroid.Attack;
            m_Speed = drAsteroid.Speed;
            m_AngularSpeed = drAsteroid.AngularSpeed;
            m_DeadEffectId = drAsteroid.DeadEffectId;
            m_DeadSoundId = drAsteroid.DeadSoundId;
        }

        public override int MaxHP
        {
            get
            {
                return m_MaxHP;
            }
        }

        public int Attack
        {
            get
            {
                return m_Attack;
            }
        }

        public float Speed
        {
            get
            {
                return m_Speed;
            }
        }

        public float AngularSpeed
        {
            get
            {
                return m_AngularSpeed;
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
    }
}
