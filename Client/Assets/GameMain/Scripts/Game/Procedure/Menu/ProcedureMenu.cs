//------------------------------------------------------------
// Game Framework
// Copyright © 2013-2021 Jiang Yin. All rights reserved.
// Homepage: https://gameframework.cn/
// Feedback: mailto:ellan@gameframework.cn
//------------------------------------------------------------

using GameFramework.Event;
using GameMain.Base;
using UnityGameFramework.Runtime;
using ProcedureOwner = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;

namespace GameMain.Game
{
    public class ProcedureMenu : ProcedureBase
    {
        protected override void OnEnter(ProcedureOwner procedureOwner)
        {
            base.OnEnter(procedureOwner);
            MenuMgr.Instance.OnEnter();
        }

        protected override void OnLeave(ProcedureOwner procedureOwner, bool isShutdown)
        {
            base.OnLeave(procedureOwner, isShutdown);
            MenuMgr.Instance.OnLeave(isShutdown);
        }

        protected override void OnUpdate(ProcedureOwner procedureOwner, float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);

            if (MenuMgr.Instance.IsStartGame)
            {
                ProcedureDataMgr.Instance.SetNextSceneId(procedureOwner,ConfigMgr.Instance.GetInt("Scene.Main"));
                ProcedureDataMgr.Instance.SetBattleMode(procedureOwner,BattleMode.Survival);
                ChangeState<ProcedureChangeScene>(procedureOwner);
            }
        }

    }
}
