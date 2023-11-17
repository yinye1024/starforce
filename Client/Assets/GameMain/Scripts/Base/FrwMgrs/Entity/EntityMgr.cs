

using System;
using GameFramework.Resource;
using UnityGameFramework.Runtime;

namespace GameMain.Base
{
    public class EntityMgr:Singleton<EntityMgr>
    {

        private readonly HashMap<Type, string> _groupNameMap = new();

        
        /// <summary>
        /// 获取实体。
        /// </summary>
        /// <param name="entityId">实体编号。</param>
        /// <returns>实体。</returns>
        public Entity GetEntity(int entityId)
        {
            return  GameCompMgr.Entity.GetEntity(entityId);
        }

        /// <summary>
        /// 附加子实体。
        /// </summary>
        /// <param name="childEntity">要附加的子实体。</param>
        /// <param name="parentEntityId">被附加的父实体Id。</param>
        /// <param name="parentTransformPath">挂载点，相对于被附加父实体的位置。</param>
        public void AttachEntity(Entity childEntity, int parentEntityId, string parentTransformPath)
        {
            GameCompMgr.Entity.AttachEntity(childEntity,parentEntityId,parentTransformPath);
        }

        /// <summary>
        /// 显示实体。
        /// </summary>
        /// <typeparam name="T">实体逻辑类型。</typeparam>
        /// <param name="entityId">实体编号。</param>
        /// <param name="assetName">实体资源名称。</param>
        /// <param name="priority">加载实体资源的优先级。</param>
        /// <param name="userData">用户自定义数据。</param>
        public void ShowEntity<T>(int entityId, string assetName,int priority,object userData) where T : EntityLogic
        {
            Type type = typeof(T);
            string entityGroupName = GetGroupName(type);
            string assetPath = AssetPathUtils.GetEntityAsset(assetName);
            GameCompMgr.Entity.ShowEntity<T>( entityId, assetPath, entityGroupName,priority,userData);
        }

        /// <summary>
        /// 显示实体。
        /// </summary>
        /// <param name="entityId">实体编号。</param>
        /// <param name="logicType">实体逻辑类型。</param>
        /// <param name="assetName">实体资源名称。</param>
        /// <param name="priority">加载实体资源的优先级。</param>
        /// <param name="userData">用户自定义数据。</param>
        public void ShowEntity(int entityId,Type logicType, string assetName,int priority,object userData)
        {
            string entityGroupName = GetGroupName(logicType);
            string assetPath = AssetPathUtils.GetEntityAsset(assetName);
            GameCompMgr.Entity.ShowEntity( entityId, logicType, assetPath, entityGroupName,priority,userData);
        }

        private string GetGroupName(Type type)
        {
            if (this._groupNameMap.HasKey(type))
            {
                return this._groupNameMap.Get(type);
            }
            string groupName = type.Name;
            // Group Name 要先在组建节点配置好
            if (GameCompMgr.Entity.HasEntityGroup(groupName))
            {
                this._groupNameMap.Put(type,groupName);
                return this._groupNameMap.Get(type);
            }
            ErrorUtils.ThrowBsException("Entity Group Name is not Config:" + groupName);
            return null;
        }
        
        public void HideEntity(int entityId)
        {
            GameCompMgr.Entity.HideEntity(entityId);
        }
        public void HideEntity(Entity entity)
        {
            GameCompMgr.Entity.HideEntity(entity);
        }

        public void HideAll()
        {
            GameCompMgr.Entity.HideAllLoadedEntities();
            GameCompMgr.Entity.HideAllLoadingEntities();
        }

    }
}