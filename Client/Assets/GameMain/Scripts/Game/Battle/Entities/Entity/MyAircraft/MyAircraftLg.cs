﻿//------------------------------------------------------------
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
    public class MyAircraftLg : AircraftLg
    {
        [FormerlySerializedAs("m_MyAircraftData")] [SerializeField]
        private MyAircraftBsData mMyAircraftBsData = null;

        private Rect m_PlayerMoveBoundary = default(Rect);
        private Vector3 m_TargetPosition = Vector3.zero;

        protected override void OnInit(object userData)
        {
            base.OnInit(userData);
        }

        protected override void OnShow(object userData)
        {
            base.OnShow(userData);

            mMyAircraftBsData = userData as MyAircraftBsData;
            if (mMyAircraftBsData == null)
            {
                Log.Error("My aircraft data is invalid.");
                return;
            }

            ScrollableBackground sceneBackground = FindObjectOfType<ScrollableBackground>();
            if (sceneBackground == null)
            {
                Log.Warning("Can not find scene background.");
                return;
            }

            m_PlayerMoveBoundary = new Rect(sceneBackground.PlayerMoveBoundary.bounds.min.x, sceneBackground.PlayerMoveBoundary.bounds.min.z,
                sceneBackground.PlayerMoveBoundary.bounds.size.x, sceneBackground.PlayerMoveBoundary.bounds.size.z);
        }

        protected override void OnUpdate(float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(elapseSeconds, realElapseSeconds);

            if (Input.GetMouseButton(0))
            {
                Vector3 point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                m_TargetPosition = new Vector3(point.x, 0f, point.z);

                for (int i = 0; i < m_Weapons.Count; i++)
                {
                    m_Weapons[i].TryAttack();
                }
            }

            Vector3 direction = m_TargetPosition - CachedTransform.localPosition;
            if (direction.sqrMagnitude <= Vector3.kEpsilon)
            {
                return;
            }

            Vector3 speed = Vector3.ClampMagnitude(direction.normalized * mMyAircraftBsData.Speed * elapseSeconds, direction.magnitude);
            CachedTransform.localPosition = new Vector3
            (
                Mathf.Clamp(CachedTransform.localPosition.x + speed.x, m_PlayerMoveBoundary.xMin, m_PlayerMoveBoundary.xMax),
                0f,
                Mathf.Clamp(CachedTransform.localPosition.z + speed.z, m_PlayerMoveBoundary.yMin, m_PlayerMoveBoundary.yMax)
            );
        }
    }
}
