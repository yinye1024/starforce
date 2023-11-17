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
    /// 装甲类。
    /// </summary>
    public class ArmorLg : EntityBsLg
    {
        private const string AttachPoint = "Armor Point";

        [FormerlySerializedAs("m_ArmorData")] [SerializeField]
        private ArmorBsData mArmorBsData = null;

        protected override void OnInit(object userData)
        {
            base.OnInit(userData);
        }

        protected override void OnShow(object userData)
        {
            base.OnShow(userData);

            mArmorBsData = userData as ArmorBsData;
            if (mArmorBsData == null)
            {
                Log.Error("Armor data is invalid.");
                return;
            }

            ArmorMgr.Instance.Attach(this, mArmorBsData.OwnerId, AttachPoint);
        }

        protected override void OnAttachTo(EntityLogic parentEntity, Transform parentTransform, object userData)
        {
            base.OnAttachTo(parentEntity, parentTransform, userData);

            Name = Utility.Text.Format("Armor of {0}", parentEntity.Name);
            CachedTransform.localPosition = Vector3.zero;
        }
    }
}
