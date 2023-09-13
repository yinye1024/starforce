using GameMain.Base;
using UnityGameFramework.Runtime;
using ProcedureOwner = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;

namespace GameMain.Game
{
    public class ProcedureCheckResources : ProcedureBase
    {

        protected override void OnEnter(ProcedureOwner procedureOwner)
        {
            base.OnEnter(procedureOwner);

            CheckResourcesMgr.Instance.DoCheck();
        }

        protected override void OnUpdate(ProcedureOwner procedureOwner, float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);

            if (!CheckResourcesMgr.Instance.CheckResourcesComplete)
            {
                return;
            }

            if (CheckResourcesMgr.Instance.NeedUpdateResources)
            {
                UpdateResourceInfo updateResourceInfo = CheckResourcesMgr.Instance.GetUpdateResourceInfo();
                ProcedureDataMgr.Instance.SetUpdateResourceInfo(procedureOwner,updateResourceInfo);
                ChangeState<ProcedureUpdateResources>(procedureOwner);
            }
            else
            {
                ChangeState<ProcedurePreload>(procedureOwner);
            }
        }

    
    }
}
