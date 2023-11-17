//------------------------------------------------------------
// Game Framework
// Copyright © 2013-2021 Jiang Yin. All rights reserved.
// Homepage: https://gameframework.cn/
// Feedback: mailto:ellan@gameframework.cn
//------------------------------------------------------------

using GameMain.Base;
using UnityEngine;
using UnityEngine.Serialization;
using UnityGameFramework.Runtime;

namespace GameMain.Game
{
    /// <summary>
    /// 特效类。
    /// </summary>
    public class EffectLg : EntityBsLg
    {
        [FormerlySerializedAs("m_EffectData")] [SerializeField]
        private EffectBsData mEffectBsData = null;

        private float m_ElapseSeconds = 0f;

        protected override void OnShow(object userData)
        {
            base.OnShow(userData);

            mEffectBsData = userData as EffectBsData;
            if (mEffectBsData == null)
            {
                Log.Error("Effect data is invalid.");
                return;
            }

            m_ElapseSeconds = 0f;
        }

        protected override void OnUpdate(float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(elapseSeconds, realElapseSeconds);

            m_ElapseSeconds += elapseSeconds;
            if (m_ElapseSeconds >= mEffectBsData.KeepTime)
            {
                EntityBsMgr.HideEntity(this);
            }
        }
    }
}
