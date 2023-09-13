/*----------------------------------------------------------------
// Author：隐叶
// Copyright © 2023-2030 YinYe. All rights reserved.
//===============================================================
// 功能描述：
//
//----------------------------------------------------------------*/


using GameMain.Base;

namespace GameMain.Game
{
    public class BattleMgr:Singleton<BattleMgr>
    {
        
        private readonly HashMap<BattleMode, BattleBase> _battleMap = new ();
        private BattleBase _curBattle = null;

        public bool IsGameOver()
        {
            return this._curBattle == null || this._curBattle.GameOver;
        }

        public BattleMgr()
        {
            this._battleMap.Put(BattleMode.Survival, new BattleSurvival());
        }

        public void OnDestroy()
        {
            _battleMap.Clear();
        }

        public void OnEnter(BattleMode battleMode)
        {

            _curBattle = _battleMap.Get(battleMode);
            _curBattle.Initialize();
        }

        public void OnLeave()
        {
            if (_curBattle != null)
            {
                _curBattle.Shutdown();
                _curBattle = null;
            }
        }

        public void OnUpdate(float elapseSeconds, float realElapseSeconds)
        {

            if (!IsGameOver())
            {
                _curBattle.Update(elapseSeconds, realElapseSeconds);
            }

        }
    }
}