/*----------------------------------------------------------------
// Author：隐叶
// Copyright © 2023-2030 YinYe. All rights reserved.
//===============================================================
// 功能描述：
//
//----------------------------------------------------------------*/


using System.Collections.Generic;
using GameFramework;
using GameMain.Base;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace GameMain.Game
{
    public class UpdateResourcesUICtrl
    {
        
        private int _updateCount = 0;
        private long _updateTotalCompressedLength = 0L;
        private int _updateSuccessCount = 0;
        private readonly List<UpdateLengthData> _updateLengthDataList = new ();
        private UpdateResourceForm _updateResourceForm = null;


        public void OnEnter(UpdateResourceInfo updateResourceInfo)
        {
            _updateCount = updateResourceInfo.UpdateResourceCount;
            _updateTotalCompressedLength = updateResourceInfo.UpdateResourceTotalCompressedLength;
            
            _updateSuccessCount = 0;
            _updateLengthDataList.Clear();
            _updateResourceForm = null;
        }

        public void ShowUI()
        {
            if (_updateResourceForm == null)
            {
                _updateResourceForm = Object.Instantiate(BuildInDataMgr.Instance.GetUpdateResourceFormTemplate());
            }
        }

        public void OnDestroy()
        {
            if (_updateResourceForm != null)
            {
                Object.Destroy(_updateResourceForm.gameObject);
                _updateResourceForm = null;
            }
        }
        
        public void OnResourceUpdateStart(ResourceUpdateStartEventArgs eventArgs)
        {
            foreach (UpdateLengthData dataTmp in _updateLengthDataList)
            {
                if (dataTmp.Name == eventArgs.Name)
                {
                    Log.Warning("Update resource '{0}' is duplicated, download again", eventArgs.Name);
                    dataTmp.Length = 0;
                    RefreshProgress();
                    return;
                }
            }
            _updateLengthDataList.Add(new UpdateLengthData(eventArgs.Name));
        }


        public void OnResourceUpdateChanged(ResourceUpdateChangedEventArgs eventArgs )
        {
            UpdateLengthData dataTmp = GetByName(eventArgs.Name);
            if (dataTmp != null)
            {
                dataTmp.Length = eventArgs.CurrentLength;
                RefreshProgress();
            }
            else
            {
                Log.Warning("Update resource '{0}' is invalid.", eventArgs.Name);
            }

         
        }

        public void OnResourceUpdateSuccess(ResourceUpdateSuccessEventArgs eventArgs )
        {
        
            UpdateLengthData dataTmp = GetByName(eventArgs.Name);
            if (dataTmp!=null)
            {
                _updateSuccessCount++;
                dataTmp.Length = eventArgs.CompressedLength;
                RefreshProgress();
            }
            else
            {
                Log.Warning("Update resource '{0}' is invalid.", eventArgs.Name);
            }
         
        }

        public void OnResourceUpdateFailure(ResourceUpdateFailureEventArgs eventArgs )
        {
            UpdateLengthData dataTmp = GetByName(eventArgs.Name);
            if (dataTmp!=null)
            {
                _updateLengthDataList.Remove(dataTmp);
                RefreshProgress();
            }
            else
            {
                Log.Warning("Update resource '{0}' is invalid.", eventArgs.Name);
            }

        
        }

        private UpdateLengthData GetByName(string name)
        {
            foreach (UpdateLengthData dataTmp in _updateLengthDataList)
            {
                if (dataTmp.Name == name)
                {
                    return dataTmp;
                }
            }

            return null;
        }


        private void RefreshProgress()
        {
            long currentTotalUpdateLength = 0L;
            for (int i = 0; i < _updateLengthDataList.Count; i++)
            {
                currentTotalUpdateLength += _updateLengthDataList[i].Length;
            }

            float progressTotal = (float)currentTotalUpdateLength / _updateTotalCompressedLength;
            
            string descriptionText = LocalizationMgr.Instance.GetString("UpdateResource.Tips", _updateSuccessCount.ToString(), _updateCount.ToString(), GetByteLengthString(currentTotalUpdateLength), GetByteLengthString(_updateTotalCompressedLength), progressTotal, GetByteLengthString(DownloadMgr.Instance.GetCurSpeed()));
            _updateResourceForm.SetProgress(progressTotal, descriptionText);
        }

        private string GetByteLengthString(long byteLength)
        {
            if (byteLength < 1024L) // 2 ^ 10
            {
                return Utility.Text.Format("{0} Bytes", byteLength);
            }

            if (byteLength < 1048576L) // 2 ^ 20
            {
                return Utility.Text.Format("{0:F2} KB", byteLength / 1024f);
            }

            if (byteLength < 1073741824L) // 2 ^ 30
            {
                return Utility.Text.Format("{0:F2} MB", byteLength / 1048576f);
            }

            if (byteLength < 1099511627776L) // 2 ^ 40
            {
                return Utility.Text.Format("{0:F2} GB", byteLength / 1073741824f);
            }

            if (byteLength < 1125899906842624L) // 2 ^ 50
            {
                return Utility.Text.Format("{0:F2} TB", byteLength / 1099511627776f);
            }

            if (byteLength < 1152921504606846976L) // 2 ^ 60
            {
                return Utility.Text.Format("{0:F2} PB", byteLength / 1125899906842624f);
            }

            return Utility.Text.Format("{0:F2} EB", byteLength / 1152921504606846976f);
        }

        
        private class UpdateLengthData
        {
            private readonly string m_Name;

            public UpdateLengthData(string name)
            {
                m_Name = name;
            }

            public string Name
            {
                get
                {
                    return m_Name;
                }
            }

            public int Length
            {
                get;
                set;
            }
        }
        
        
    }
}