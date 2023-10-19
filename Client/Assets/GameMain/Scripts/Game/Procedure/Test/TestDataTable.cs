//------------------------------------------------------------
// Game Framework
// Copyright © 2013-2021 Jiang Yin. All rights reserved.
// Homepage: https://gameframework.cn/
// Feedback: mailto:ellan@gameframework.cn
//------------------------------------------------------------

using DataTable;
using System.Collections.Generic;
using GameFramework.DataTable;
using GameMain.Base;
using UnityGameFramework.Runtime;

namespace GameMain.Test
{
    public class TestDataTable : Singleton<TestDataTable>
    {
        private bool _doPrint = true;
        public void LoadDataTable()
        {
            DataTableInfo[] tableInfoList = new DataTableInfo[]
            {
                new DataTableInfo(typeof(DTWeapon),"Weapon.txt"),
                new DataTableInfo(typeof(DTEntity),"Entity.txt"),
            
            };
            DataTableMgr.Instance.LoadData(tableInfoList);
        }

        
        public void CheckCfg()
        {
            if (!DataTableMgr.Instance.IsOnLoading && this._doPrint)
            {
                this._doPrint = false;
                IDataTable<DTWeapon> dataTable = DataTableMgr.Instance.GetDataTable<DTWeapon>();
                DTWeapon wp = dataTable.GetDataRow(30000);
                Log.Info("load success wp.attack:"+wp.Attack);
                
                IDataTable<DTEntity> entityTable = DataTableMgr.Instance.GetDataTable<DTEntity>();
                DTEntity entity = entityTable.GetDataRow(10000);
                Log.Info("load success entity.AssetName:"+ entity.AssetName);
                
            }

        }

    }
}
