//------------------------------------------------------------
// Game Framework
// Copyright © 2013-2021 Jiang Yin. All rights reserved.
// Homepage: https://gameframework.cn/
// Feedback: mailto:ellan@gameframework.cn
//------------------------------------------------------------

using GameMain.Base;
using UnityEngine;
using UnityEngine.UI;
using UnityGameFramework.Runtime;

namespace GameMain.Game
{
    public class AboutFormLogic : UGuiFormLogic
    {
        [SerializeField]
        private RectTransform m_Transform = null;

        [SerializeField]
        private float m_ScrollSpeed = 1f;

        private float m_InitPosition = 0f;

        protected override void OnInit(object userData)
        {
            base.OnInit(userData);

            CanvasScaler canvasScaler = GetComponentInParent<CanvasScaler>();
            if (canvasScaler == null)
            {
                Log.Warning("Can not find CanvasScaler component.");
                return;
            }

            m_InitPosition = -0.5f * canvasScaler.referenceResolution.x * Screen.height / Screen.width;
        }

        protected override void OnOpen(object userData)
        {
            base.OnOpen(userData);

            m_Transform.SetLocalPositionY(m_InitPosition);

            // 换个音乐
            SoundMgr.Instance.PlayMusic(3);
        }

        protected override void OnClose(bool isShutdown, object userData)
        {
            base.OnClose(isShutdown, userData);

            // 还原音乐
            SoundMgr.Instance.PlayMusic(1);
        }

        protected override void OnUpdate(float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(elapseSeconds, realElapseSeconds);

            m_Transform.AddLocalPositionY(m_ScrollSpeed * elapseSeconds);
            if (m_Transform.localPosition.y > m_Transform.sizeDelta.y - m_InitPosition)
            {
                m_Transform.SetLocalPositionY(m_InitPosition);
            }
        }
    }
}
