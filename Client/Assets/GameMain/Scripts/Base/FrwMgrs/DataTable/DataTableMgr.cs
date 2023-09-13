

using System;
using System.Collections.Generic;
using GameFramework.DataTable;
using GameFramework.Event;
using UnityGameFramework.Runtime;

namespace GameMain.Base
{
    public class DataTableMgr:Singleton<DataTableMgr>
    {
        public bool IsOnLoading { get; private set; }

        private List<string> _tableAssetPathList = new(); 

        public T GetDataRow<T>(int rowId) where T : IDataRow
        {
            IDataTable<T> dataTable = GetDataTable<T>();
            return dataTable.GetDataRow(rowId);
        }

        public IDataTable<T> GetDataTable<T>() where T : IDataRow
        {
            return GameCompMgr.DataTable.GetDataTable<T>();
        }

        public void LoadData(DataTableInfo[] dataTableList)
        {
            if (!this.IsOnLoading)
            {
                this.IsOnLoading = true;
                this._tableAssetPathList = new List<string>();
                DoSubscribe();
                foreach (DataTableInfo tableInfo in dataTableList)
                {
                    DataTableBase dataTable = GameCompMgr.DataTable.CreateDataTable(tableInfo.DataType);
                    string assetPath = AssetPathUtils.GetDataTableAsset(tableInfo.FileName);
                    this._tableAssetPathList.Add(assetPath);
                    dataTable.ReadData(assetPath, assetPath);
                }
            }
        }
        
        
        private void OnLoadDataTableSuccess(object sender, GameEventArgs e)
        {
            LoadDataTableSuccessEventArgs ne = (LoadDataTableSuccessEventArgs)e;
            string assetPath = (string)ne.UserData;

            if (this._tableAssetPathList.Contains(assetPath))
            {
                Log.Info("Load data table '{0}' OK.", ne.DataTableAssetName);
                this._tableAssetPathList.Remove(assetPath);
                DoIfLoadFinish();
            }
            
        }

        private void OnLoadDataTableFailure(object sender, GameEventArgs e)
        {
            LoadDataTableFailureEventArgs ne = (LoadDataTableFailureEventArgs)e;
            string assetPath = (string)ne.UserData;

            if (this._tableAssetPathList.Contains(assetPath))
            {
                Log.Error("Can not load data table '{0}' from '{1}' with error message '{2}'.", ne.DataTableAssetName, ne.DataTableAssetName, ne.ErrorMessage);
                this._tableAssetPathList.Remove(assetPath);
                DoIfLoadFinish();
            }
            
        }
        
        private void DoIfLoadFinish()
        {
            if (this._tableAssetPathList.Count == 0)
            {
                this.IsOnLoading = false;
                DoUnSubscribe();
            }
        }

        private void DoSubscribe()
        {   
            EventMgr.Instance.Subscribe(LoadDataTableSuccessEventArgs.EventId, OnLoadDataTableSuccess);
            EventMgr.Instance.Subscribe(LoadDataTableFailureEventArgs.EventId, OnLoadDataTableFailure);
        }
        private void DoUnSubscribe()
        {   
            EventMgr.Instance.Unsubscribe(LoadDataTableSuccessEventArgs.EventId, OnLoadDataTableSuccess);
            EventMgr.Instance.Unsubscribe(LoadDataTableFailureEventArgs.EventId, OnLoadDataTableFailure);
        }

    }

    public class DataTableInfo
    {
        public DataTableInfo(Type dataTypeP,string fileNameP)
        {
            this.DataType = dataTypeP;
            this.FileName = fileNameP;
        }

        // 数据表对应的数据类

        public Type DataType { get; }

        // 数据表对应的文件名
        public string FileName { get; }
    }
}