//------------------------------------------------------------
// Game Framework
// Copyright © 2013-2021 Jiang Yin. All rights reserved.
// Homepage: https://gameframework.cn/
// Feedback: mailto:ellan@gameframework.cn
//------------------------------------------------------------

using GameFramework;
using UnityEngine;
using UnityEngine.Serialization;
using UnityGameFramework.Runtime;

namespace GameMain.Game
{
    /// <summary>
    /// 推进器类。
    /// </summary>
    public class ThrusterLg : EntityBsLg
    {
        private const string AttachPoint = "Thruster Point";

        [FormerlySerializedAs("m_ThrusterData")] [SerializeField]
        private ThrusterBsData mThrusterBsData = null;

        protected override void OnInit(object userData)
        {
            base.OnInit(userData);
        }

        protected override void OnShow(object userData)
        {
            base.OnShow(userData);

            mThrusterBsData = userData as ThrusterBsData;
            if (mThrusterBsData == null)
            {
                Log.Error("Thruster data is invalid.");
                return;
            }

            ThrusterMgr.Instance.Attach(this, mThrusterBsData.OwnerId, AttachPoint);
        }

        protected override void OnAttachTo(EntityLogic parentEntity, Transform parentTransform, object userData)
        {
            base.OnAttachTo(parentEntity, parentTransform, userData);

            Name = Utility.Text.Format("Thruster of {0}", parentEntity.Name);
            CachedTransform.localPosition = Vector3.zero;
        }
    }
}
