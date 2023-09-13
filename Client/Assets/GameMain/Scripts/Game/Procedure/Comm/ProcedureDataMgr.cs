/*----------------------------------------------------------------
// Author：隐叶
// Copyright © 2023-2030 YinYe. All rights reserved.
//===============================================================
// 功能描述：
//
//----------------------------------------------------------------*/

using GameMain.Base;
using UnityGameFramework.Runtime;
using ProcedureOwner = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;

namespace GameMain.Game
{
    
    public class ProcedureDataMgr: Singleton<ProcedureDataMgr>
    {
        public void SetNextSceneId(ProcedureOwner procedureOwner,int sceneId)
        {
            procedureOwner.SetData<VarInt32>("NextSceneId", sceneId);
        }
        public int GetNextSceneId(ProcedureOwner procedureOwner)
        {
            int sceneId = procedureOwner.GetData<VarInt32>("NextSceneId");
            return sceneId;
        }
        
        
        public void SetBattleMode(ProcedureOwner procedureOwner,BattleMode battleMode)
        {
            procedureOwner.SetData<VarByte>("BattleMode", (byte)battleMode);
        }
        public BattleMode GetBattleMode(ProcedureOwner procedureOwner)
        {
            BattleMode battleMode = (BattleMode)procedureOwner.GetData<VarByte>("BattleMode").Value;
            return battleMode;
        }
       
        
        public void SetVersionInfo(ProcedureOwner procedureOwner,VersionInfo versionInfo)
        {
            procedureOwner.SetData("VersionInfo", NewVarObject(versionInfo));
        }
        public VersionInfo GetVersionInfo(ProcedureOwner procedureOwner)
        {
            VersionInfo versionInfo = (VersionInfo)procedureOwner.GetData<VarObject>("VersionInfo").Value;
            return versionInfo;
        }
        public void RmVersionInfo(ProcedureOwner procedureOwner)
        {
            procedureOwner.RemoveData("VersionInfo");
        }
        
        
        
        public void SetUpdateResourceInfo(ProcedureOwner procedureOwner,UpdateResourceInfo updateResourceInfo)
        {
            procedureOwner.SetData("UpdateResourceInfo", NewVarObject(updateResourceInfo));
        }
        public UpdateResourceInfo GetUpdateResourceInfo(ProcedureOwner procedureOwner)
        {
            UpdateResourceInfo updateResourceInfo = (UpdateResourceInfo)procedureOwner.GetData<VarObject>("UpdateResourceInfo").Value;
            return updateResourceInfo;
        }
        public void RmUpdateResourceInfo(ProcedureOwner procedureOwner)
        {
            procedureOwner.RemoveData("UpdateResourceInfo");
        }

        
        
        private VarObject NewVarObject(object obj)
        {
            VarObject vo = new ()
            {
                Value = obj
            };
            return vo;
        }
    }
}