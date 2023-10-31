// Author：隐叶
// Copyright © 2023-2030 YinYe. All rights reserved.
//===============================================================
// 功能描述：
//  资源控制 加载和卸载等
//----------------------------------------------------------------*/


using GameFramework.Resource;

namespace GameMain.Base
{
    public class ResMgr:Singleton<ResMgr>
    {
        
        /// <summary>
        /// 已设置使用单机模式，并初始化资源。
        /// </summary>
        /// <param name="initResourcesCompleteCallback">使用单机模式并初始化资源完成时的回调函数。</param>
        public void InitResources(InitResourcesCompleteCallback initResourcesCompleteCallback)
        {
            GameCompMgr.Resource.InitResources(initResourcesCompleteCallback);
        }

        /// <summary>
        /// 设置当前变体。对应多语言资源
        /// </summary>
        /// <param name="currentVariant">当前变体。</param>
        public void SetCurrentVariant(string currentVariant)
        {
            GameCompMgr.Resource.SetCurrentVariant(currentVariant);
        }
        
        /// <summary>
        /// 设置资源更新下载地址前缀。
        /// </summary>
        public void SetUpdatePrefixUri(string updatePrefixUri)
        {
            GameCompMgr.Resource.UpdatePrefixUri=updatePrefixUri;
        }
        /// <summary>
        /// 已使用可更新模式，并检查版本资源列表。
        /// </summary>
        /// <param name="latestInternalResourceVersion">最新的内部资源版本号。</param>
        /// <returns>检查版本资源列表结果。</returns>
        public CheckVersionListResult CheckVersionList(int latestInternalResourceVersion)
        {
            return GameCompMgr.Resource.CheckVersionList(latestInternalResourceVersion) ;
        }
        /// <summary>
        /// 已使用可更新模式，并更新版本资源列表。
        /// </summary>
        /// <param name="versionListLength">版本资源列表大小。</param>
        /// <param name="versionListHashCode">版本资源列表哈希值。</param>
        /// <param name="versionListCompressedLength">版本资源列表压缩后大小。</param>
        /// <param name="versionListCompressedHashCode">版本资源列表压缩后哈希值。</param>
        /// <param name="updateVersionListCallbacks">版本资源列表更新回调函数集。</param>
        public void UpdateVersionList(int versionListLength, int versionListHashCode, int versionListCompressedLength, int versionListCompressedHashCode, UpdateVersionListCallbacks updateVersionListCallbacks)
        {
            GameCompMgr.Resource.UpdateVersionList(versionListLength, versionListHashCode, versionListCompressedLength, versionListCompressedHashCode, updateVersionListCallbacks) ;
        }

        
        /// <summary>
        /// 已使用可更新模式，并校验资源。
        /// </summary>
        /// <param name="verifyResourcesCompleteCallback">使用可更新模式并校验资源完成时的回调函数。</param>
        public void VerifyResources(VerifyResourcesCompleteCallback verifyResourcesCompleteCallback)
        {
            GameCompMgr.Resource.VerifyResources(verifyResourcesCompleteCallback);
        }
   
        /// <summary>
        /// 已使用可更新模式，并检查资源。
        /// </summary>
        /// <param name="checkResourcesCompleteCallback">使用可更新模式并检查资源完成时的回调函数。</param>
        public void CheckResources(CheckResourcesCompleteCallback checkResourcesCompleteCallback)
        {
            GameCompMgr.Resource.CheckResources(checkResourcesCompleteCallback);
        }

        /// <summary>
        /// 已使用可更新模式，并更新所有需要更新的资源。
        /// </summary>
        /// <param name="updateResourcesCompleteCallback">使用可更新模式并更新默认资源组完成时的回调函数。</param>
        public void UpdateResources(UpdateResourcesCompleteCallback updateResourcesCompleteCallback)
        {
            GameCompMgr.Resource.UpdateResources(updateResourcesCompleteCallback);
        }
        
        
        public void LoadAsset(string assetPath,   LoadAssetSuccessCallback loadAssetSuccessCallback,
            LoadAssetFailureCallback loadAssetFailureCallback, object userData)
        {
            LoadAssetCallbacks loadAssetCallbacks =
                new LoadAssetCallbacks(loadAssetSuccessCallback, loadAssetFailureCallback);
            GameCompMgr.Resource.LoadAsset(assetPath,loadAssetCallbacks,userData);
        }
        
        /// <summary>
        /// 异步加载资源。
        /// </summary>
        /// <param name="assetName">要加载资源的名称。</param>
        /// <param name="priority">加载资源的优先级。</param>
        /// <param name="loadAssetCallbacks">加载资源回调函数集。</param>
        public void LoadAsset(string assetName, int priority, LoadAssetCallbacks loadAssetCallbacks)
        {
            GameCompMgr.Resource.LoadAsset( assetName, priority, loadAssetCallbacks);
        }


        public ResourceMode ResourceMode {
            get { return GameCompMgr.Resource.ResourceMode; }
        }


    }
}