/*----------------------------------------------------------------
// Author：隐叶
// Copyright © 2023-2030 YinYe. All rights reserved.
//===============================================================
// 功能描述：
//
//----------------------------------------------------------------*/


using System.IO;
using GameFramework;
using UnityEngine;

namespace ComTools
{
    public static class ProtoCfg
    {
        // 工作目录
        public const string Workspace = "./ProtoBuf/workspace"; // 相对 streamingAssetsPath 的路径
        // bat文件目录
        public const string BatFile = "proto2cs.bat"; // 
        // proto文件目录
        public const string ProtoDir = "./protos"; // 相对 Workspace 的路径
        // 生成目录
        public const string GenDir = "./gen"; // 相对 Workspace 的路径
        // protogen.exe 
        public const string ExePath = "./protogen/bin/protogen"; // 相对 Workspace 的路径

        
        public static string BuildProtoAbsPath()
        {
            return BuildAbsPath(ProtoDir);
        }
        
        public static string BuildBatFileAbsPath()
        {
            return BuildAbsPath(BatFile);
        }
        public static string BuildBatDirAbsPath()
        {
            string bat = "";
            return BuildAbsPath(bat);
        }
        
        // 获取绝对路径
        private static string BuildAbsPath(string filePath)
        {
            string path = Path.Combine(GetWorkSpacePath(), filePath);
            return Utility.Path.GetRegularPath(path);
        }

        private static string GetWorkSpacePath()
        {
            string path = Path.Combine(Application.streamingAssetsPath, Workspace);
            return Utility.Path.GetRegularPath(path);
        }


    }
}