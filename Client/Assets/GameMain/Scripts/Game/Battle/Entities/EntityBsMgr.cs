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

        public static EntityLg GetGameEntity(int entityId)
        {
            
            Entity entity = EntityMgr.Instance.GetEntity(entityId);
            if (entity == null)
            {
                return null;
            }

            return (EntityLg)entity.Logic;
        }

        public static void HideEntity(EntityLg entityLg)
        {
            EntityMgr.Instance.HideEntity(entityLg.Entity);
        }
        public static void HideEntity(Entity entity)
        {
            EntityMgr.Instance.HideEntity(entity);
        }

        public static void AttachEntity(EntityLg entityLg, int ownerId, string parentTransformPath)
        {
            EntityMgr.Instance.AttachEntity(entityLg.Entity, ownerId, parentTransformPath);
        }
        public static void AttachEntity(Entity entity, int ownerId, string parentTransformPath)
        {
            EntityMgr.Instance.AttachEntity(entity, ownerId, parentTransformPath);
        }

        public static void ShowMyAircraft(MyAircraftData data)
        {
            ShowEntity(typeof(MyAircraft), "Aircraft", Constant.AssetPriority.MyAircraftAsset, data);
        }

        public static void ShowAircraft(AircraftData data)
        {
            ShowEntity(typeof(Aircraft), "Aircraft", Constant.AssetPriority.AircraftAsset, data);
        }

        public static void ShowThruster(ThrusterData data)
        {
            ShowEntity(typeof(Thruster), "Thruster", Constant.AssetPriority.ThrusterAsset, data);
        }

        public static void ShowWeapon(WeaponData data)
        {
            ShowEntity(typeof(Weapon), "Weapon", Constant.AssetPriority.WeaponAsset, data);
        }

        public static void ShowArmor(ArmorData data)
        {
            ShowEntity(typeof(Armor), "Armor", Constant.AssetPriority.ArmorAsset, data);
        }

        public static void ShowBullet( BulletData data)
        {
            ShowEntity(typeof(Bullet), "Bullet", Constant.AssetPriority.BulletAsset, data);
        }

        public static void ShowAsteroid( AsteroidData data)
        {
            ShowEntity(typeof(Asteroid), "Asteroid", Constant.AssetPriority.AsteroiAsset, data);
        }

        public static void ShowEffect(EffectData data)
        {
            ShowEntity(typeof(Effect), "Effect", Constant.AssetPriority.EffectAsset, data);
        }

        private static void ShowEntity(Type logicType, string entityGroup, int priority, EntityData data)
        {
            if (data == null)
            {
                Log.Warning("Data is invalid.");
                return;
            }

            IDataTable<DTEntity> dtEntity = DataTableMgr.Instance.GetDataTable<DTEntity>();
            DTEntity drEntity = dtEntity.GetDataRow(data.TypeId);
            if (drEntity == null)
            {
                Log.Warning("Can not load entity id '{0}' from data table.", data.TypeId.ToString());
                return;
            }

            EntityMgr.Instance.ShowEntity(data.Id, logicType, drEntity.AssetName, priority, data);
        }

        public static int GenerateSerialId()
        {
            return --s_SerialId;
        }

        public static void HideAll()
        {
            EntityMgr.Instance.HideAll();
        }
    }
}