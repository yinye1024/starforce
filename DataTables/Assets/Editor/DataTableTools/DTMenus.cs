using System.Collections.Generic;
using System.IO;
using GameFramework;
using UnityEditor;
using UnityEngine;

namespace DataTableTools
{
    public class DTMenus : Editor
    {
        [MenuItem("DataTables/Generate Txt")]
        public static void ExportTxt()
        {
            List<string> dataTableNames = GetAllFnList(DTCfg.ExcelPath);
            
            foreach (string dataTableName in dataTableNames)
            {
                ExcelToTxt.ExportTxt(dataTableName);
            }

            AssetDatabase.Refresh();
        }
        
        
        [MenuItem("DataTables/Generate DataTables From Txt")]
        private static void GenerateDataTablesFromTxt()
        {
            List<string> dataTableNames = GetAllFnList(DTCfg.TxtOutPath);
            
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
            List<string> dataTableNames = GetAllFnList(DTCfg.ExcelPath);
            
            foreach (string dataTableName in dataTableNames)
            {
                ExcelToJson.ExportTxt(dataTableName);
            }

        }

        [MenuItem("DataTables/Generate DataTables From Json")]
        private static void GenerateDataTablesFromJson()
        {
            List<string> dataTableNames = GetAllFnList(DTCfg.JsonOutPath);
            
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

        private static List<string> GetAllFnList(string folderPath)
        {
            // 创建一个用于存储文件名（去掉后缀）的列表
            List<string> fileNameList = new List<string>();

            // 获取目录下所有文件的全路径
            string[] files = Directory.GetFiles(folderPath);

            // 循环遍历每个文件路径，去掉后缀名并添加到列表
            foreach (string filePath in files)
            {
                if (Path.GetExtension(filePath) != ".meta")
                {
                    string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(filePath);
                    fileNameList.Add(fileNameWithoutExtension);
                }
              
            }

            return fileNameList;
        }
        
        

    }
}