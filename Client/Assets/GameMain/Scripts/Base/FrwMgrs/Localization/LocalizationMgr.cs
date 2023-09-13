/*----------------------------------------------------------------
// Author：隐叶
// Copyright © 2023-2030 YinYe. All rights reserved.
//===============================================================
// 功能描述：
//  场景控制 加载和卸载等
//----------------------------------------------------------------*/


using System.Collections.Generic;
using GameFramework.Event;
using GameFramework.Localization;
using UnityGameFramework.Runtime;

namespace GameMain.Base
{
    public class LocalizationMgr:Singleton<LocalizationMgr>
    {

        public bool IsOnLoading { get; private set; }

        /// <summary>
        /// 根据字典主键获取字典内容字符串。
        /// </summary>
        /// <param name="key">字典主键。</param>
        /// <returns>要获取的字典内容字符串。</returns>
        public string GetString(string key)
        {
            return GameCompMgr.Localization.GetString(key);
        }

        /// <summary>
        /// 根据字典主键获取字典内容字符串。
        /// </summary>
        /// <param name="key">字典主键。</param>
        /// <param name="args">字典参数。</param>
        /// <returns>要获取的字典内容字符串。</returns>
        public string GetString(string key, params object[] args)
        {
           return GameCompMgr.Localization.GetString(key, args);
        }

        public void SetLanguage(Language language)
        {
            GameCompMgr.Localization.Language = language;
        }

        public Language GetLanguage()
        {
            return GameCompMgr.Localization.Language;
        }

        /// <summary>
        /// 解析字典。
        /// </summary>
        /// <param name="dictionaryString">要解析的字典字符串。</param>
        /// <returns>是否解析字典成功。</returns>
        public bool ParseData(string dictionaryString)
        {
            return GameCompMgr.Localization.ParseData(dictionaryString);
        }
        
        
        public void LoadDict(string dicFileName)
        {
            if (!this.IsOnLoading)
            {
                this.IsOnLoading = true;
                DoSubscribe();
                string dicAssetPath = AssetPathUtils.GetLocalizationAsset(dicFileName);
                GameCompMgr.Localization.ReadData(dicAssetPath,this);
            }
        }
        
        private void OnLoadDictionarySuccess(object sender, GameEventArgs e)
        {
            LoadDictionarySuccessEventArgs ne = (LoadDictionarySuccessEventArgs)e;

            if (ne.UserData == this)
            {
                Log.Info("Load config '{0}' OK.", ne.DictionaryAssetName);
                DoIfLoadFinish();
            }
        }


        private void OnLoadDictionaryFailure(object sender, GameEventArgs e)
        {

            LoadDictionaryFailureEventArgs ne = (LoadDictionaryFailureEventArgs)e;

            if (ne.UserData == this)
            {
                Log.Error("Can not load config '{0}' from '{1}' with error message '{2}'.", ne.DictionaryAssetName, ne.DictionaryAssetName, ne.ErrorMessage);
                DoIfLoadFinish();
            }

            
        }
        
        private void DoIfLoadFinish()
        {
            this.IsOnLoading = false;
            DoUnSubscribe();
        }
        
        private void DoSubscribe()
        {   
            EventMgr.Instance.Subscribe(LoadDictionarySuccessEventArgs.EventId, OnLoadDictionarySuccess);
            EventMgr.Instance.Subscribe(LoadDictionaryFailureEventArgs.EventId, OnLoadDictionaryFailure);
        }
        private void DoUnSubscribe()
        {   
            EventMgr.Instance.Unsubscribe(LoadDictionarySuccessEventArgs.EventId, OnLoadDictionarySuccess);
            EventMgr.Instance.Unsubscribe(LoadDictionaryFailureEventArgs.EventId, OnLoadDictionaryFailure);
        }
    }
}