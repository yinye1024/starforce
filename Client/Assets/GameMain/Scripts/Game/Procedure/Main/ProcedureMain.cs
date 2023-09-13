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
    public class ProcedureMain : ProcedureBase
    {

        protected override void OnEnter(ProcedureOwner procedureOwner)
        {
            base.OnEnter(procedureOwner);

            BattleMode battleMode = ProcedureDataMgr.Instance.GetBattleMode(procedureOwner);
            MainMgr.Instance.OnEnter(battleMode);
        }
        protected override void OnLeave(ProcedureOwner procedureOwner, bool isShutdown)
        {
            MainMgr.Instance.OnLeave();
            
            base.OnLeave(procedureOwner, isShutdown);
        }
        protected override void OnDestroy(ProcedureOwner procedureOwner)
        {
            MainMgr.Instance.OnDestroy();
            
            base.OnDestroy(procedureOwner);
        }
        protected override void OnUpdate(ProcedureOwner procedureOwner, float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);

            MainMgr.Instance.OnUpdate(elapseSeconds,realElapseSeconds);

            if (MainMgr.Instance.IsGotoMenu)
            {
                ProcedureDataMgr.Instance.SetNextSceneId(procedureOwner,ConfigMgr.Instance.GetInt("Scene.Menu"));
                ChangeState<ProcedureChangeScene>(procedureOwner);
            }

        }
    }
}
