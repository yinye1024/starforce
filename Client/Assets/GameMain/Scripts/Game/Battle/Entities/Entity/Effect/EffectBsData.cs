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
    public class EffectBsData : EntityBsData
    {
        [SerializeField]
        private float m_KeepTime = 0f;

        public EffectBsData(int entityId, int typeId)
            : base(entityId, typeId)
        {
            m_KeepTime = 3f;
        }

        public float KeepTime
        {
            get
            {
                return m_KeepTime;
            }
        }
    }
}
