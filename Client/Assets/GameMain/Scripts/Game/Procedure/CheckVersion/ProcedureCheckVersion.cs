//------------------------------------------------------------
// Game Framework
// Copyright © 2013-2021 Jiang Yin. All rights reserved.
// Homepage: https://gameframework.cn/
// Feedback: mailto:ellan@gameframework.cn
//------------------------------------------------------------

using GameFramework;
using GameFramework.Event;
using GameFramework.Resource;
using GameMain.Base;
using UnityEngine;
using UnityGameFramework.Runtime;
using ProcedureOwner = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;

namespace GameMain.Game
{
    public class ProcedureCheckVersion : ProcedureBase
    {
        protected override void OnEnter(ProcedureOwner procedureOwner)
        {
            base.OnEnter(procedureOwner);

            // 向服务器请求版本信息 获取 full 下面的 XXXVersion.txt 文件信息
            CheckVersionMgr.Instance.DoCheckVersion();
        }


        protected override void OnUpdate(ProcedureOwner procedureOwner, float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);

            if (!CheckVersionMgr.Instance.CheckVersionComplete)
            {
                return;
            }

            if (CheckVersionMgr.Instance.NeedUpdateVersion)
            {
                ProcedureDataMgr.Instance.SetVersionInfo(procedureOwner,CheckVersionMgr.Instance.VersionInfo);
                ChangeState<ProcedureUpdateVersion>(procedureOwner);
            }
            else
            {
                ChangeState<ProcedureVerifyResources>(procedureOwner);
            }
        }



    }
}
