// Author：隐叶
// Copyright © 2023-2030 YinYe. All rights reserved.
//===============================================================
// 功能描述：
//  指定 BuildSettings 配置文件的路径，GameFramework 会根据字段标签来获取这些配置
//----------------------------------------------------------------*/


using GameFramework;
using System.IO;
using UnityEngine;
using UnityGameFramework.Editor;

namespace GameMain.Editor
{
    public static class BuildSettingConfigsPath
    {
        [BuildSettingsConfigPath]
        public static string BuildSettingsConfig = Utility.Path.GetRegularPath(Path.Combine(Application.dataPath, "GameMain/Editor/BuildSettings/Configs/BuildSettings.xml"));
    }
}
