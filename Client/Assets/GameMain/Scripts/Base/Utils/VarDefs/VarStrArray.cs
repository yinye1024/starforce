/*----------------------------------------------------------------
// Author：隐叶
// Copyright © 2023-2030 YinYe. All rights reserved.
//===============================================================
// 功能描述：
//
//----------------------------------------------------------------*/


using GameFramework;

namespace GameMain.Game
{
    public class VarStrArray:Variable<string[]>
    {

        public VarStrArray()
        {
        }
        
        /// <summary>
        /// string[] 到 VarStrList 变量类的隐式转换。
        /// </summary>
        /// <param name="strList">值。</param>
        public static implicit operator VarStrArray(string[] strList)
        {
            VarStrArray varValue = ReferencePool.Acquire<VarStrArray>();
            varValue.Value = strList;
            return varValue;
        }

        /// <summary>
        /// VarStrArray 到 string[] 变量类的隐式转换。
        /// </summary>
        /// <param name="value">值。</param>
        public static implicit operator string[](VarStrArray value)
        {
            return value.Value;
        }
    }
}