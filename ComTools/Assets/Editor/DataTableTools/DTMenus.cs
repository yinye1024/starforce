using System.Collections.Generic;

using GameFramework;
using UnityEditor;
using UnityEngine;

namespace ComTools
{
    public class DTMenus : Editor
    {
        [MenuItem("DataTables/Generate Txt")]
        public static void ExportTxt()
        {
            List<string> dataTableNames = FileUtils.GetAllFnList(DTCfg.ExcelPath);
            
            foreach (string dataTableName in dataTableNames)
            {
                ExcelToTxt.ExportTxt(dataTableName);
            }

            AssetDatabase.Refresh();
        }
        
        
        [MenuItem("DataTables/Generate DataTables From Txt")]
        private static void GenerateDataTablesFromTxt()
        {
            List<string> dataTableNames = FileUtils.GetAllFnList(DTCfg.TxtOutPath);
            
            foreach (string dataTableName in dataTableNames)
            {
                DataTableProcessor dataTableProcessor = DataTableTxtGenerator.CreateDataTableProcessor(dataTableName);
                if (!DataTableTxtGenerator.CheckRawData(dataTableProcessor, dataTableName))
                {
                    Debug.LogError(Utility.Text.Format("Check raw data failure. DataTableName='{0}'", dataTableName));
                    break;
                }

                DataTableTxtGenerator.GenerateCodeFile(dataTableProcessor, dataTableName);
            }

            AssetDatabase.Refresh();
        }
    
        
        [MenuItem("DataTables/Generate Json")]
        public static void ExportJson()
        {
            List<string> dataTableNames = FileUtils.GetAllFnList(DTCfg.ExcelPath);
            
            foreach (string dataTableName in dataTableNames)
            {
                ExcelToJson.ExportTxt(dataTableName);
            }

        }

        [MenuItem("DataTables/Generate DataTables From Json")]
        private static void GenerateDataTablesFromJson()
        {
            List<string> dataTableNames = FileUtils.GetAllFnList(DTCfg.JsonOutPath);
            
            foreach (string dataTableName in dataTableNames)
            {
                DataTableProcessor dataTableProcessor = DataTableJsonGenerator.CreateDataTableProcessor(dataTableName);
                if (!DataTableJsonGenerator.CheckRawData(dataTableProcessor, dataTableName))
                {
                    Debug.LogError(Utility.Text.Format("Check raw data failure. DataTableName='{0}'", dataTableName));
                    break;
                }

                DataTableJsonGenerator.GenerateCodeFile(dataTableProcessor, dataTableName);
            }

            AssetDatabase.Refresh();
        }

        

    }
}