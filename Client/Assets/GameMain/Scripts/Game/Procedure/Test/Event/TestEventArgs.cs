/*----------------------------------------------------------------
// Author：隐叶
// Copyright © 2023-2030 YinYe. All rights reserved.
//===============================================================
// 功能描述：
//
//----------------------------------------------------------------*/


using GameFramework;
using GameFramework.Event;
using GameMain.Base;

namespace GameMain.Test.Event
{
    public class TestEventArgs:GameEventArgs
    {
        public static readonly int EventId = typeof(TestEventArgs).GetHashCode();
        public int PropA = 1;
        public int PropB = 2;
        
        
        public override int Id
        {
            get
            {
                return EventId;
            }
        }
        
        public override void Clear()
        {
            this.PropA = 1;
            this. PropB = 2;
        }
  
       


    }
}