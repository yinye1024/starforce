//------------------------------------------------------------
// Game Framework
// Copyright © 2013-2021 Jiang Yin. All rights reserved.
// Homepage: https://gameframework.cn/
// Feedback: mailto:ellan@gameframework.cn
//------------------------------------------------------------

using System;
using System.Collections.Generic;
using GameFramework;
using GameMain.Base;
using UnityGameFramework.Runtime;

namespace GameMain.Test
{
    public class TestDataNode : Base.Singleton<TestDataNode>
    {

        private DateTime _lastDateTime = DateTime.UtcNow;
        private bool doTest = true;
        public void OnEnter()
        {
            

            TestBag bag = new TestBag();
            TestBagItem bagItem_1 = TestBagItem.CreateInstance(1,10);
            TestBagItem bagItem_2 = TestBagItem.CreateInstance(2,23);
            bag.PutItem(bagItem_1).PutItem(bagItem_2);
            
            DataNodePlayerDao.Instance.SetData<TestBag>(bag);

            Player player = new();
            player.Id = 10001;
            player.Name = "TName 呱唧";
            
            DataNodePlayerDao.Instance.SetData<Player>(player);
        }

        public void OnUpdate()
        {
            DateTime now = DateTime.UtcNow; // 获取当前UTC时间
            TimeSpan elapsedTime = now - _lastDateTime;
            double totalSeconds = elapsedTime.TotalSeconds;

            if (doTest && totalSeconds > 5 )
            {
                
                this.doTest = false;
                TestBag bag = DataNodePlayerDao.Instance.GetData<TestBag>();
                Log.Info("bag count:"+bag.Count());
                
                DataNodePlayerDao.Instance.Clear();
                TestBag bag1 = DataNodePlayerDao.Instance.GetData<TestBag>();
                Player player = DataNodePlayerDao.Instance.GetData<Player>();
                Log.Info("after remove, bag == null:" + (bag1 == null));
                Log.Info("after remove, player == null:" + (player == null));
            }

        }
        
        

        private class Player
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
        private class TestBag
        {

            private HashMap<int, TestBagItem> itemMap = new();

            public int Count()
            {
                return this.itemMap.Count();
            }

            public TestBag PutItem(TestBagItem bagItem)
            {
                this.itemMap.Put(bagItem.Id,bagItem);
                return this;
            }
            public TestBagItem GetItem(int itemId)
            {
                return this.itemMap.Get(itemId);
            }
        }
        
        private class TestBagItem
        {
            private TestBagItem(int id,int count)
            {
                this.Id = id;
                this.Count = count;
            }

            public static TestBagItem CreateInstance(int id, int count)
            {
                return new TestBagItem(id, count);
            }

            public int Id { get; }
            public int Count { get; set; }
        }
        
        

    }
}
