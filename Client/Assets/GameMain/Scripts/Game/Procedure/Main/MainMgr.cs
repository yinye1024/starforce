//------------------------------------------------------------
// Game Framework
// Copyright © 2013-2021 Jiang Yin. All rights reserved.
// Homepage: https://gameframework.cn/
// Feedback: mailto:ellan@gameframework.cn
//------------------------------------------------------------

using System.Collections.Generic;
using GameMain.Base;
using UnityGameFramework.Runtime;
using ProcedureOwner = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;

namespace GameMain.Game
{
    public class MainMgr : Singleton<MainMgr>
    {
        private const float GameOverDelayedSeconds = 2f;

        private bool _startGotoMenu = false;
        private float _gotoMenuDelaySeconds = 0f;
        public bool IsGotoMenu { get; private set; } = false;

        public void OnEnter(BattleMode battleMode)
        {
            this._startGotoMenu = false;
            BattleMgr.Instance.OnEnter(battleMode);
        }
        public void OnLeave()
        {
            BattleMgr.Instance.OnLeave();
        }
        public void OnDestroy()
        {
            BattleMgr.Instance.OnDestroy();
        }
        public void OnUpdate( float elapseSeconds, float realElapseSeconds)
        {
            if (this.IsGotoMenu)
            {
                return;
            }

            BattleMgr.Instance.OnUpdate(elapseSeconds,realElapseSeconds);

            if (BattleMgr.Instance.IsGameOver())
            {
                TickGotoMenu(elapseSeconds);
            }

        }

        private void TickGotoMenu(float elapseSeconds)
        {
            if (!_startGotoMenu)
            {
                _startGotoMenu = true;
                _gotoMenuDelaySeconds = 0;
            }

            _gotoMenuDelaySeconds += elapseSeconds;
            if (_gotoMenuDelaySeconds >= GameOverDelayedSeconds)
            {
                this.IsGotoMenu = true;
            }
        }
    }
}
