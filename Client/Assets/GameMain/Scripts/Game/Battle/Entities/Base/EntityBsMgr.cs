/*----------------------------------------------------------------
// Author：隐叶
// Copyright © 2023-2030 YinYe. All rights reserved.
//===============================================================
// 功能描述：
// 
//----------------------------------------------------------------*/


using System;
using DataTable;
using GameFramework.DataTable;
using GameMain.Base;
using UnityGameFramework.Runtime;

namespace GameMain.Game
{
    public static class EntityBsMgr
    {
        // 关于 EntityId 的约定：
        // 0 为无效
        // 正值用于和服务器通信的实体（如玩家角色、NPC、怪等，服务器只产生正值）
        // 负值用于本地生成的临时实体（如特效、FakeObject等）
        private static int s_SerialId = 0;
        public static int GenerateSerialId()
        {
            return --s_SerialId;
        }

        public static void AttachEntity(int entityId, int ownerId, string parentTransformPath)
        {
            Entity childEntity = EntityMgr.Instance.GetEntity(entityId);
            EntityMgr.Instance.AttachEntity(childEntity, ownerId, parentTransformPath);
        }


        public static void ShowEntity<T>(int priority, EntityBsData bsData) where T:EntityBsLg
        {
            if (bsData == null)
            {
                Log.Warning("Data is invalid.");
                return;
            }

            IDataTable<DTEntity> dtEntity = DataTableMgr.Instance.GetDataTable<DTEntity>();
            DTEntity drEntity = dtEntity.GetDataRow(bsData.TypeId);
            if (drEntity == null)
            {
                Log.Warning("Can not load entity id '{0}' from data table.", bsData.TypeId.ToString());
                return;
            }

            Type logicType = typeof(T);
            EntityMgr.Instance.ShowEntity(bsData.Id, logicType, drEntity.AssetName, priority, bsData);
        }
        
        public static void HideEntity(EntityBsLg entityBsLg)
        {
            EntityMgr.Instance.HideEntity(entityBsLg.Entity);
        }

        public static void HideAll()
        {
            EntityMgr.Instance.HideAll();
        }
    }
}