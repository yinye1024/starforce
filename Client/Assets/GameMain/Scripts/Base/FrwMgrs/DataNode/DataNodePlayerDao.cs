using System;
using GameFramework;
using GameFramework.DataNode;
using GameFramework.ObjectPool;
using UnityGameFramework.Runtime;

namespace GameMain.Base
{
    public class DataNodePlayerDao:Singleton<DataNodePlayerDao>
    {

        private const string PathRoot = "Player";
        private readonly HashMap<Type, string> _pathMap = new();

        public void SetData<T>(T data)
        {
            Type type = typeof(T);
            VarObject varObj = new VarObject
            {
                Value = data
            };
            DataNodeMgr.Instance.SetData(GetPath(type),varObj);
        }

        private string GetPath(Type type)
        {
            string path = _pathMap.Get(type);
            if (path == null)
            {
                path = PathRoot + "." + type.Name;
                _pathMap.Put(type,path);
            }

            return path;
        }

        public T GetData<T>()
        {
            Type type = typeof(T);
            string path = GetPath(type);
            Variable varObj = DataNodeMgr.Instance.GetData(path);
            
            return varObj == null? default(T):(T)varObj.GetValue();
        }
        
        public void Clear()
        {
            GameCompMgr.DataNode.RemoveNode(PathRoot);
        }


    }
}