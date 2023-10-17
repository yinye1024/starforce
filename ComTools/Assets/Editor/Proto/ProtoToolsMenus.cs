using System.Collections.Generic;
using System.IO;
using System.Text;
using GameFramework;
using UnityEditor;
using UnityEngine;

namespace ComTools
{
    public class ProtoToolsMenus : Editor
    {
        [MenuItem("ProtoTools/ExportProto")]
        public static void ExportTxt()
        {
            List<string> protoFileNames = FileUtils.GetAllFnListWithSuffix(ProtoCfg.BuildProtoAbsPath(),".proto");
            ExportProto(protoFileNames);
        }
        
        
        private static void ExportProto(List<string> fileNames)
        {
    
            //把生成指令写入bat文件
            string batFilePath = ProtoCfg.BuildBatFileAbsPath();
            StringBuilder sb = new StringBuilder();
            
            sb.AppendLine("@echo off");
            sb.AppendLine("chcp 65001"); // 设置cmd窗口编码 utf-8
            
            foreach (var fileName in fileNames)
            {
                sb.AppendLine($"\"{ProtoCfg.ExePath}\" -i:{ProtoCfg.ProtoDir}/{fileName}.proto -o:{ProtoCfg.GenDir}/{fileName}.cs");
            }
            sb.AppendLine("pause");
            File.WriteAllText(batFilePath, sb.ToString(),Encoding.UTF8);
   
            //执行bat文件
            BatUtils.RunBat(batFilePath,ProtoCfg.BuildBatDirAbsPath());
            AssetDatabase.Refresh();
        }

        

    }
}