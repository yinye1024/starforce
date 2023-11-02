using System;
using GameFramework.ObjectPool;

namespace GameMain.Base
{
    public class ObjectPoolMgr:Singleton<ObjectPoolMgr>
    {
        
        private HashMap<Type,IObjectPool<ObjectItemWrapper>> _poolMap = new();


        public void InitPool<T>(int poolSize)
        {
            Type type = typeof(T);
            string name = type.ToString();
            IObjectPool<ObjectItemWrapper> newPool = GameCompMgr.ObjectPool.CreateSingleSpawnObjectPool<ObjectItemWrapper>(name, poolSize);
            this._poolMap.Put(type,newPool);
        }

        public int GetCount<T>() where T : ObjectItem
        {
            Type type = typeof(T);
            IObjectPool<ObjectItemWrapper> typePool = this._poolMap.Get(type);
            return typePool.Count;
        }

        public T Spawn<T>() where T:ObjectItem
        {
            Type type = typeof(T);
            IObjectPool<ObjectItemWrapper> typePool = this._poolMap.Get(type);
            
            ObjectItem objItem;
            ObjectItemWrapper objectItemWrapper = typePool.Spawn();
            if (objectItemWrapper != null)
            {
                objItem = (ObjectItem)objectItemWrapper.Target;
            }
            else
            {
                objItem = Activator.CreateInstance<T>();
                objItem.OnCreate();
                typePool.Register(ObjectItemWrapper.Create(objItem), true);
            }
            objItem.OnSpawn();
            
            return (T)objItem;
        }
        
        public void Unspawn(ObjectItem objItem)
        {
            objItem.OnUnSpawn();
            Type type = objItem.GetType();
            IObjectPool<ObjectItemWrapper> typePool = this._poolMap.Get(type);
            typePool.Unspawn(objItem);
        }
        

    }
}