using GameFramework;
using GameFramework.Event;
using System.Collections.Generic;
using GameMain.Base;
using UnityEngine;
using UnityGameFramework.Runtime;
using ProcedureOwner = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;

namespace GameMain.Game
{
    public class ProcedureUpdateResources : ProcedureBase
    {
        protected override void OnEnter(ProcedureOwner procedureOwner)
        {
            base.OnEnter(procedureOwner);

            UpdateResourceInfo updateResourceInfo = ProcedureDataMgr.Instance.GetUpdateResourceInfo(procedureOwner);
            ProcedureDataMgr.Instance.RmUpdateResourceInfo(procedureOwner);
            UpdateResourcesMgr.Instance.OnEnter(updateResourceInfo);
        }
        

        protected override void OnLeave(ProcedureOwner procedureOwner, bool isShutdown)
        {
            UpdateResourcesMgr.Instance.OnLeave();
            base.OnLeave(procedureOwner, isShutdown);
        }

        protected override void OnUpdate(ProcedureOwner procedureOwner, float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);

            if (!UpdateResourcesMgr.Instance.UpdateResourcesComplete)
            {
                return;
            }

            ChangeState<ProcedurePreload>(procedureOwner);
        }


    }
}
