// Author：隐叶
// Copyright © 2023-2030 YinYe. All rights reserved.
//===============================================================
// 功能描述：
//  指定打包配置文件的路径，GameFramework 会根据字段标签来获取这些配置
//----------------------------------------------------------------*/


using GameFramework;
using System.IO;
using UnityEngine;
using UnityGameFramework.Editor;
using UnityGameFramework.Editor.ResourceTools;

namespace GameMain.Editor
{
    public static class ResourceBuildConfigsPath
    {
       

        [ResourceCollectionConfigPath]
        public static string ResourceCollectionConfig = Utility.Path.GetRegularPath(Path.Combine(Application.dataPath, EditorCfg.BuildCfgDirPath+"ResourceCollection.xml"));

        [ResourceEditorConfigPath]
        public static string ResourceEditorConfig = Utility.Path.GetRegularPath(Path.Combine(Application.dataPath, EditorCfg.BuildCfgDirPath+"ResourceEditor.xml"));

        [ResourceBuilderConfigPath]
        public static string ResourceBuilderConfig = Utility.Path.GetRegularPath(Path.Combine(Application.dataPath, EditorCfg.BuildCfgDirPath+"ResourceBuilder.xml"));
    }
}
