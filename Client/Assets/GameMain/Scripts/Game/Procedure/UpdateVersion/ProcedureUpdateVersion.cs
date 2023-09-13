//------------------------------------------------------------
// Game Framework
// Copyright © 2013-2021 Jiang Yin. All rights reserved.
// Homepage: https://gameframework.cn/
// Feedback: mailto:ellan@gameframework.cn
//------------------------------------------------------------

using ProcedureOwner = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;

namespace GameMain.Game
{
    public class ProcedureUpdateVersion : ProcedureBase
    {

        protected override void OnEnter(ProcedureOwner procedureOwner)
        {
            base.OnEnter(procedureOwner);

            VersionInfo versionInfo = ProcedureDataMgr.Instance.GetVersionInfo(procedureOwner);
            UpdateVersionMgr.Instance.DoUpdate(versionInfo);
            
            ProcedureDataMgr.Instance.RmVersionInfo(procedureOwner);
        }

        protected override void OnUpdate(ProcedureOwner procedureOwner, float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);

            if (!UpdateVersionMgr.Instance.UpdateVersionComplete)
            {
                return;
            }

            ChangeState<ProcedureVerifyResources>(procedureOwner);
        }
    }
}
