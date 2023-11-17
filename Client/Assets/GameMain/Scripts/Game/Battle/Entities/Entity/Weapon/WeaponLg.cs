//------------------------------------------------------------
// Game Framework
// Copyright © 2013-2021 Jiang Yin. All rights reserved.
// Homepage: https://gameframework.cn/
// Feedback: mailto:ellan@gameframework.cn
//------------------------------------------------------------

using GameFramework;
using GameMain.Base;
using UnityEngine;
using UnityEngine.Serialization;
using UnityGameFramework.Runtime;

namespace GameMain.Game
{
    /// <summary>
    /// 武器类。
    /// </summary>
    public class WeaponLg : EntityBsLg
    {
        private const string AttachPoint = "Weapon Point";

        [FormerlySerializedAs("m_WeaponData")] [SerializeField]
        private WeaponBsData mWeaponBsData = null;

        private float m_NextAttackTime = 0f;

        protected override void OnInit(object userData)
        {
            base.OnInit(userData);
        }

        protected override void OnShow(object userData)
        {
            base.OnShow(userData);

            mWeaponBsData = userData as WeaponBsData;
            if (mWeaponBsData == null)
            {
                Log.Error("Weapon data is invalid.");
                return;
            }

            WeaponMgr.Instance.Attach(this, mWeaponBsData.OwnerId, AttachPoint);
        }

        protected override void OnAttachTo(EntityLogic parentEntity, Transform parentTransform, object userData)
        {
            base.OnAttachTo(parentEntity, parentTransform, userData);

            Name = Utility.Text.Format("Weapon of {0}", parentEntity.Name);
            CachedTransform.localPosition = Vector3.zero;
        }

        public void TryAttack()
        {
            if (Time.time < m_NextAttackTime)
            {
                return;
            }

            m_NextAttackTime = Time.time + mWeaponBsData.AttackInterval;
            BulletMgr.Instance.ShowBullet(new BulletBsData(EntityBsMgr.GenerateSerialId(), mWeaponBsData.BulletId, mWeaponBsData.OwnerId, mWeaponBsData.OwnerCamp, mWeaponBsData.Attack, mWeaponBsData.BulletSpeed)
            {
                Position = CachedTransform.position,
            });
            SoundMgr.Instance.PlaySound(mWeaponBsData.BulletSoundId);
        }
    }
}
