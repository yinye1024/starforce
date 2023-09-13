/*----------------------------------------------------------------
// Author：隐叶
// Copyright © 2023-2030 YinYe. All rights reserved.
//===============================================================
// 功能描述：
//
//----------------------------------------------------------------*/


using GameMain.Base;
using UnityGameFramework.Runtime;

namespace GameMain.Game
{
    public class CheckResourcesMgr:Singleton<CheckResourcesMgr>
    {
        public bool CheckResourcesComplete { get; set; } = false;
        public bool NeedUpdateResources { get; private set; } = false;
        
        private int _updateResourceCount= 0;
        private long _updateResourceTotalCompressedLength = 0L;
        
        public void DoCheck()
        {

            CheckResourcesComplete = false;
            NeedUpdateResources = false;
            _updateResourceCount = 0;
            _updateResourceTotalCompressedLength = 0L;

            ResMgr.Instance.CheckResources(OnCheckResourcesComplete);
        }
        
        private void OnCheckResourcesComplete(int movedCount, int removedCount, int updateCount, long updateTotalLength, long updateTotalCompressedLength)
        {
            CheckResourcesComplete = true;
            NeedUpdateResources = updateCount > 0;
            _updateResourceCount = updateCount;
            _updateResourceTotalCompressedLength = updateTotalCompressedLength;
            
            Log.Info("Check resources complete, '{0}' resources need to update, compressed length is '{1}', uncompressed length is '{2}'.", updateCount.ToString(), updateTotalCompressedLength.ToString(), updateTotalLength.ToString());
        }

        public UpdateResourceInfo GetUpdateResourceInfo()
        {
            return UpdateResourceInfo.NewObj(this._updateResourceCount, this._updateResourceTotalCompressedLength);
        }
    }
}