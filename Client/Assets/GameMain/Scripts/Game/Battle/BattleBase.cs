//------------------------------------------------------------
// Game Framework
// Copyright © 2013-2021 Jiang Yin. All rights reserved.
// Homepage: https://gameframework.cn/
// Feedback: mailto:ellan@gameframework.cn
//------------------------------------------------------------

using GameFramework.Event;
using GameMain.Base;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace GameMain.Game
{
    public abstract class BattleBase
    {
        public abstract BattleMode BattleMode
        {
            get;
        }

        protected ScrollableBackground SceneBackground
        {
            get;
            private set;
        }

        public bool GameOver
        {
            get;
            protected set;
        }

        private MyAircraftLg _mMyAircraftLg = null;

        public virtual void Initialize()
        {
            EventMgr.Instance.Subscribe(ShowEntitySuccessEventArgs.EventId, OnShowEntitySuccess);
            EventMgr.Instance.Subscribe(ShowEntityFailureEventArgs.EventId, OnShowEntityFailure);

            SceneBackground = Object.FindObjectOfType<ScrollableBackground>();
            if (SceneBackground == null)
            {
                Log.Warning("Can not find scene background.");
                return;
            }

            SceneBackground.VisibleBoundary.gameObject.GetOrAddComponent<HideByBoundary>();
            MyAircraftMgr.Instance.ShowMyAircraft(new MyAircraftBsData(EntityBsMgr.GenerateSerialId(), 10000)
            {
                Name = "My Aircraft",
                Position = Vector3.zero,
            });

            GameOver = false;
            _mMyAircraftLg = null;
        }

        public virtual void Shutdown()
        {
            EventMgr.Instance.Unsubscribe(ShowEntitySuccessEventArgs.EventId, OnShowEntitySuccess);
            EventMgr.Instance.Unsubscribe(ShowEntityFailureEventArgs.EventId, OnShowEntityFailure);
        }

        public virtual void Update(float elapseSeconds, float realElapseSeconds)
        {
            if (_mMyAircraftLg != null && _mMyAircraftLg.IsDead)
            {
                GameOver = true;
                return;
            }
        }

        protected virtual void OnShowEntitySuccess(object sender, GameEventArgs e)
        {
            ShowEntitySuccessEventArgs ne = (ShowEntitySuccessEventArgs)e;
            if (ne.EntityLogicType == typeof(MyAircraftLg))
            {
                _mMyAircraftLg = (MyAircraftLg)ne.Entity.Logic;
            }
        }

        protected virtual void OnShowEntityFailure(object sender, GameEventArgs e)
        {
            ShowEntityFailureEventArgs ne = (ShowEntityFailureEventArgs)e;
            Log.Warning("Show entity failure with error message '{0}'.", ne.ErrorMessage);
        }
    }
}
