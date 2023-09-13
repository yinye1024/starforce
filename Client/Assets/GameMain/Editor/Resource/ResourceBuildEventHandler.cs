// Author：隐叶
// Copyright © 2023-2030 YinYe. All rights reserved.
//===============================================================
// 功能描述：
//  收集并输出版本相关信息到 Version.txt，用做热更新的判断
//----------------------------------------------------------------*/

using GameFramework;
using System.IO;
using GameMain.Game;
using Unity.Plastic.Newtonsoft.Json;
using UnityEditor;
using UnityEngine;
using UnityGameFramework.Editor.ResourceTools;

namespace GameMain.Editor
{
    public sealed class ResourceBuildEventHandler : IBuildEventHandler
    {

        
        private static string OutPutDirectory { get; set; }
        private static VersionInfo m_VersionInfo = new VersionInfo();

        public bool ContinueOnFailure
        {
            get
            {
                return false;
            }
        }

        public void OnPreprocessAllPlatforms(string productName, string companyName, string gameIdentifier, string gameFrameworkVersion, string unityVersion, string applicableGameVersion, int internalResourceVersion,
            Platform platforms, AssetBundleCompressionType assetBundleCompression, string compressionHelperTypeName, bool additionalCompressionSelected, bool forceRebuildAssetBundleSelected, string buildEventHandlerTypeName, string outputDirectory, BuildAssetBundleOptions buildAssetBundleOptions,
            string workingPath, bool outputPackageSelected, string outputPackagePath, bool outputFullSelected, string outputFullPath, bool outputPackedSelected, string outputPackedPath, string buildReportPath)
        {
            //...
            //赋值Version需要参数
            m_VersionInfo.LatestGameVersion = applicableGameVersion;
            m_VersionInfo.InternalResourceVersion = internalResourceVersion;
            m_VersionInfo.InternalGameVersion = 1;
            OutPutDirectory = outputDirectory;
        }

        public void OnPostprocessAllPlatforms(string productName, string companyName, string gameIdentifier, string gameFrameworkVersion, string unityVersion, string applicableGameVersion, int internalResourceVersion,
            Platform platforms, AssetBundleCompressionType assetBundleCompression, string compressionHelperTypeName, bool additionalCompressionSelected, bool forceRebuildAssetBundleSelected, string buildEventHandlerTypeName, string outputDirectory, BuildAssetBundleOptions buildAssetBundleOptions,
            string workingPath, bool outputPackageSelected, string outputPackagePath, bool outputFullSelected, string outputFullPath, bool outputPackedSelected, string outputPackedPath, string buildReportPath)
        {
        }

        public void OnPreprocessPlatform(Platform platform, string workingPath, bool outputPackageSelected, string outputPackagePath, bool outputFullSelected, string outputFullPath, bool outputPackedSelected, string outputPackedPath)
        {
        }

        public void OnBuildAssetBundlesComplete(Platform platform, string workingPath, bool outputPackageSelected, string outputPackagePath, bool outputFullSelected, string outputFullPath, bool outputPackedSelected, string outputPackedPath, AssetBundleManifest assetBundleManifest)
        {
        }

        public void OnOutputUpdatableVersionListData(Platform platform, string versionListPath, int versionListLength, int versionListHashCode, int versionListCompressedLength, int versionListCompressedHashCode)
        {
            //赋值Version版本相关参数
            m_VersionInfo.ForceUpdateGame = false;
            m_VersionInfo.VersionListLength = versionListLength;
            m_VersionInfo.VersionListHashCode = versionListHashCode;
            m_VersionInfo.VersionListCompressedLength = versionListCompressedLength;
            m_VersionInfo.VersionListCompressedHashCode = versionListCompressedHashCode;
        }

        public void OnPostprocessPlatform(Platform platform, string workingPath, bool outputPackageSelected, string outputPackagePath, bool outputFullSelected, string outputFullPath, bool outputPackedSelected, string outputPackedPath, bool isSuccess)
        {
            if (!outputPackageSelected)
            {
                return;
            }

            //保存Version.txt到Full目录
            var versionName = m_VersionInfo.LatestGameVersion.Replace(".", "_") + "_" + m_VersionInfo.InternalResourceVersion;
            m_VersionInfo.UpdatePrefixUri = Utility.Path.GetRegularPath(Path.Combine(EditorCfg.UpdateURL, versionName, platform.ToString()));
            var versionJson = JsonConvert.SerializeObject(m_VersionInfo, Formatting.Indented);
            var savePath = Utility.Path.GetRegularPath(Path.Combine(OutPutDirectory, "Full", platform + "Version.txt"));
            File.WriteAllText(savePath, versionJson);
            Debug.Log("Version.txt save success!!! path:"+ savePath);
        }
    }
}
