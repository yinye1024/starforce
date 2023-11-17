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
    /// 小行星类。
    /// </summary>
    public class AsteroidLg : TargetableEntityBsLg
    {
        [FormerlySerializedAs("m_AsteroidData")] [SerializeField]
        private AsteroidBsData mAsteroidBsData = null;

        private Vector3 m_RotateSphere = Vector3.zero;

        protected override void OnInit(object userData)
        {
            base.OnInit(userData);
        }

        protected override void OnShow(object userData)
        {
            base.OnShow(userData);

            mAsteroidBsData = userData as AsteroidBsData;
            if (mAsteroidBsData == null)
            {
                Log.Error("Asteroid data is invalid.");
                return;
            }

            m_RotateSphere = Random.insideUnitSphere;
        }

        protected override void OnUpdate(float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(elapseSeconds, realElapseSeconds);

            CachedTransform.Translate(Vector3.back * mAsteroidBsData.Speed * elapseSeconds, Space.World);
            CachedTransform.Rotate(m_RotateSphere * mAsteroidBsData.AngularSpeed * elapseSeconds, Space.Self);
        }

        protected override void OnDead(EntityBsLg attacker)
        {
            base.OnDead(attacker);

            EffectMgr.Instance.ShowEffect(new EffectBsData(EntityBsMgr.GenerateSerialId(), mAsteroidBsData.DeadEffectId)
            {
                Position = CachedTransform.localPosition,
            });
            SoundMgr.Instance.PlaySound(mAsteroidBsData.DeadSoundId);
        }

        public override ImpactData GetImpactData()
        {
            return new ImpactData(mAsteroidBsData.Camp, mAsteroidBsData.HP, mAsteroidBsData.Attack, 0);
        }
    }
}
