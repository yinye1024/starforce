/*----------------------------------------------------------------
// Author：隐叶
// Copyright © 2023-2030 YinYe. All rights reserved.
//===============================================================
// 功能描述：
//
//----------------------------------------------------------------*/


using System.Collections.Generic;
using System.IO;

namespace ComTools
{
    public static class FileUtils
    {
        public static List<string> GetAllFnList(string folderPath)
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
        public static List<string> GetAllFnListWithSuffix(string folderPath,string suffix)
        {
            // 创建一个用于存储文件名（去掉后缀）的列表
            List<string> fileNameList = new List<string>();

            // 获取目录下所有文件的全路径
            string[] files = Directory.GetFiles(folderPath);

            // 循环遍历每个文件路径，去掉后缀名并添加到列表
            foreach (string filePath in files)
            {
                if (Path.GetExtension(filePath) == suffix)
                {
                    string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(filePath);
                    fileNameList.Add(fileNameWithoutExtension);
                }
              
            }

            return fileNameList;
        }

    }
}