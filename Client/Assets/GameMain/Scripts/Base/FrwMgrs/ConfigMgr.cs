

using System.Collections.Generic;
using GameFramework.Event;
using UnityGameFramework.Runtime;

namespace GameMain.Base
{
    public class ConfigMgr:Singleton<ConfigMgr>
    {
        public bool IsOnLoading { get; private set; }

        private List<string> _cfgAssetPathList = new(); 

        
        
        public int GetInt(string configName)
        {
            return GameCompMgr.Config.GetInt(configName);
        }
        public string GetString(string configName)
        {
            return GameCompMgr.Config.GetString(configName);
        }
        public bool GetBool(string configName)
        {
            return GameCompMgr.Config.GetBool(configName);
        }
        public float GetFloat(string configName)
        {
            return GameCompMgr.Config.GetFloat(configName);
        }

        public void LoadCfg(string cfgFileName)
        {
            LoadCfg(new List<string> { cfgFileName });
        }

        public void LoadCfg(List<string> cfgFileNameListP)
        {
            if (!this.IsOnLoading)
            {
                this.IsOnLoading = true;
                DoSubscribe();
                foreach (var cfgFileName in cfgFileNameListP)
                {
                    string cfgPath = AssetPathUtils.GetConfigAsset(cfgFileName);
                    this._cfgAssetPathList.Add(cfgPath);
                    GameCompMgr.Config.ReadData(cfgPath,cfgPath);
                }
                
            }
        }
        
        private void OnLoadConfigSuccess(object sender, GameEventArgs e)
        {
            LoadConfigSuccessEventArgs ne = (LoadConfigSuccessEventArgs)e;
            string cfgPath = (string)ne.UserData;

            if (this._cfgAssetPathList.Contains(cfgPath))
            {
                Log.Info("Load config '{0}' OK.", ne.ConfigAssetName);
                this._cfgAssetPathList.Remove(cfgPath);
                DoIfLoadFinish();
            }

          
        }


        private void OnLoadConfigFailure(object sender, GameEventArgs e)
        {

            LoadConfigFailureEventArgs ne = (LoadConfigFailureEventArgs)e;
            string cfgPath = (string)ne.UserData;

            if (this._cfgAssetPathList.Contains(cfgPath))
            {
                Log.Error("Can not load config '{0}' from '{1}' with error message '{2}'.", ne.ConfigAssetName, ne.ConfigAssetName, ne.ErrorMessage);
                this._cfgAssetPathList.Remove(cfgPath);
                DoIfLoadFinish();
            }

            
        }
        
        private void DoIfLoadFinish()
        {
            if (this._cfgAssetPathList.Count == 0)
            {
                this.IsOnLoading = false;
                DoUnSubscribe();
            }
        }

        private void DoSubscribe()
        {   
            EventMgr.Instance.Subscribe(LoadConfigSuccessEventArgs.EventId, OnLoadConfigSuccess);
            EventMgr.Instance.Subscribe(LoadConfigFailureEventArgs.EventId, OnLoadConfigFailure);
        }
        private void DoUnSubscribe()
        {   
            EventMgr.Instance.Unsubscribe(LoadConfigSuccessEventArgs.EventId, OnLoadConfigSuccess);
            EventMgr.Instance.Unsubscribe(LoadConfigFailureEventArgs.EventId, OnLoadConfigFailure);
        }

    }
}