//------------------------------------------------------------
// Game Framework
// Copyright © 2013-2021 Jiang Yin. All rights reserved.
// Homepage: https://gameframework.cn/
// Feedback: mailto:ellan@gameframework.cn
//------------------------------------------------------------

using UnityEngine;
using UnityEngine.Serialization;
using UnityGameFramework.Runtime;

namespace GameMain.Game
{
    /// <summary>
    /// 子弹类。
    /// </summary>
    public class BulletLg : EntityBsLg
    {
        [FormerlySerializedAs("m_BulletData")] [SerializeField]
        private BulletBsData mBulletBsData = null;

        public ImpactData GetImpactData()
        {
            return new ImpactData(mBulletBsData.OwnerCamp, 0, mBulletBsData.Attack, 0);
        }

        protected override void OnInit(object userData)
        {
            base.OnInit(userData);
        }

        protected override void OnShow(object userData)
        {
            base.OnShow(userData);

            mBulletBsData = userData as BulletBsData;
            if (mBulletBsData == null)
            {
                Log.Error("Bullet data is invalid.");
                return;
            }
        }

        protected override void OnUpdate(float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(elapseSeconds, realElapseSeconds);

            CachedTransform.Translate(Vector3.forward * mBulletBsData.Speed * elapseSeconds, Space.World);
        }
    }
}
