/*----------------------------------------------------------------
// Author：隐叶
// Copyright © 2023-2030 YinYe. All rights reserved.
//===============================================================
// 功能描述：
// mono 行为组建，需要用到mono声明周期的mgr可以注册进来
//----------------------------------------------------------------*/


using System;
using GameMain.Base;

namespace GameMain.Game
{
    public class MonoBehavMgr : Singleton<MonoBehavMgr>
    {
        private readonly HashMap<Type, MonoBehavAgent> _agentMap = new();

        public MonoBehavMgr()
        {
            // 如果需要用到start，在构造函数这里显示注册。
            // start会在所有的框架 组件 初始化完成后执行。
            Reg(HpBarMgr.Instance);
        }

        public void Start()
        {
            foreach (MonoBehavAgent agentTmp in this._agentMap.GetAllValues())
            {
                agentTmp.Start();
            }
        }

        public void Update()
        {
            foreach (MonoBehavAgent agentTmp in this._agentMap.GetAllValues())
            {
                agentTmp.Update();
            }
        }

        public void OnDestroy()
        {
            this._agentMap.Clear();
        }

        public void Reg(MonoBehavAgent agent)
        {
            this._agentMap.Put(agent.GetType(),agent);
        }

        public void UnReg(Type type)
        {
            this._agentMap.Remove(type);
        }


    }
}
