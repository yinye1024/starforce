//------------------------------------------------------------
// Game Framework
// Copyright © 2013-2021 Jiang Yin. All rights reserved.
// Homepage: https://gameframework.cn/
// Feedback: mailto:ellan@gameframework.cn
//------------------------------------------------------------

using System;
using UnityEngine;

namespace GameMain.Game
{
    [Serializable]
    public class MyAircraftBsData : AircraftBsData
    {
        [SerializeField]
        private string m_Name = null;

        public MyAircraftBsData(int entityId, int typeId)
            : base(entityId, typeId, CampType.Player)
        {
        }

        /// <summary>
        /// 角色名称。
        /// </summary>
        public string Name
        {
            get
            {
                return m_Name;
            }
            set
            {
                m_Name = value;
            }
        }
    }
}
