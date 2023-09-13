//------------------------------------------------------------
// Game Framework
// Copyright © 2013-2021 Jiang Yin. All rights reserved.
// Homepage: https://gameframework.cn/
// Feedback: mailto:ellan@gameframework.cn
//------------------------------------------------------------

using DataTable;
using GameFramework.Event;
using GameMain.Base;
using UnityGameFramework.Runtime;
using ProcedureOwner = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;

namespace GameMain.Game
{
    public class ProcedureChangeScene : ProcedureBase
    {
        private const int MenuSceneId = 1;

        private bool _isChangeToMenu = false;


        protected override void OnEnter(ProcedureOwner procedureOwner)
        {
            base.OnEnter(procedureOwner);
            Log.Info("enter ProcedureChangeScene ");
            
            int sceneId = ProcedureDataMgr.Instance.GetNextSceneId(procedureOwner);
            _isChangeToMenu = (sceneId == MenuSceneId);
        
            DTScene dtScene = DataTableMgr.Instance.GetDataRow<DTScene>(sceneId);
            if (dtScene == null)
            {
                Log.Warning("Can not load scene '{0}' from data table.", sceneId.ToString());
                return;
            }
            
            ChangeSceneMgr.Instance.DoChangeScene(dtScene);
        }


        protected override void OnUpdate(ProcedureOwner procedureOwner, float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);

            if (ChangeSceneMgr.Instance.IsLoading())
            {
                return;
            }
            
            ChangeSceneMgr.Instance.PlayBackGroundMusic();
            
            if (_isChangeToMenu)
            {
                ChangeState<ProcedureMenu>(procedureOwner);
            }
            else
            {
                ChangeState<ProcedureMain>(procedureOwner);
            }
        }

    }
}
