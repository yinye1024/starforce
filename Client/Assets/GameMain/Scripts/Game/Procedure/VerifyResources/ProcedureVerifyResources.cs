using GameFramework.Event;
using GameMain.Base;
using UnityGameFramework.Runtime;
using ProcedureOwner = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;

namespace GameMain.Game
{
    public class ProcedureVerifyResources : ProcedureBase
    {
        protected override void OnEnter(ProcedureOwner procedureOwner)
        {
            base.OnEnter(procedureOwner);

            VerifyResourcesMgr.Instance.DoVerify();
        }

        protected override void OnUpdate(ProcedureOwner procedureOwner, float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);

            if (!VerifyResourcesMgr.Instance.VerifyResourcesComplete)
            {
                return;
            }

            ChangeState<ProcedureCheckResources>(procedureOwner);
        }
    }
}
