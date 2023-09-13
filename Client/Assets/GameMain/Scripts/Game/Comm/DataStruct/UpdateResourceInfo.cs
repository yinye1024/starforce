/*----------------------------------------------------------------
// Author：隐叶
// Copyright © 2023-2030 YinYe. All rights reserved.
//===============================================================
// 功能描述：
//
//----------------------------------------------------------------*/



namespace GameMain.Game
{
    public class UpdateResourceInfo
    {
        public static UpdateResourceInfo NewObj(int updateResourceCount, long updateResourceTotalCompressedLength)
        {
            UpdateResourceInfo info = new()
            {
                UpdateResourceCount = updateResourceCount,
                UpdateResourceTotalCompressedLength = updateResourceCount
            };
            return info;
        }

        public int UpdateResourceCount { get; set; }
        public long UpdateResourceTotalCompressedLength { get; set; }
    }
}