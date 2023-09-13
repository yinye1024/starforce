using System;
using GameFramework;
using GameFramework.DataNode;
using GameFramework.ObjectPool;

namespace GameMain.Base
{
    public class DataNodeMgr:Singleton<DataNodeMgr>
    {
        
        public void SetData(string path, Variable data)
        {
            GameCompMgr.DataNode.SetData(path,data);
        }
        
        public Variable GetData(string path)
        {
            IDataNode node = GameCompMgr.DataNode.GetNode(path);
            if (node  ==  null )
            {
                return null;
            }
            else
            {
                return node.GetData();
            }
        }
        
        public void RmData(string path)
        {
            GameCompMgr.DataNode.RemoveNode(path);
        }


    }
}