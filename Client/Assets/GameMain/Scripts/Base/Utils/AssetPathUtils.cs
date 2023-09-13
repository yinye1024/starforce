//------------------------------------------------------------
// Game Framework
// Copyright © 2013-2021 Jiang Yin. All rights reserved.
// Homepage: https://gameframework.cn/
// Feedback: mailto:ellan@gameframework.cn
//------------------------------------------------------------

using GameFramework;


namespace GameMain.Base
{
    public static class AssetPathUtils
    {
        public static string GetConfigAsset(string assetName)
        {
            return Utility.Text.Format("Assets/GameMain/AssetsPackage/Configs/{0}", assetName);
        }

        public static string GetDataTableAsset(string assetName)
        {
            return Utility.Text.Format("Assets/GameMain/AssetsPackage/DataTables/{0}", assetName);
        }

        public static string GetLocalizationAsset(string assetName)
        {
            return Utility.Text.Format("Assets/GameMain/AssetsPackage/Localization/{0}/Dictionaries/{1}", LocalizationMgr.Instance.GetLanguage(), assetName);
        }

        public static string GetFontAsset(string assetName)
        {
            return Utility.Text.Format("Assets/GameMain/AssetsPackage/Fonts/{0}.ttf", assetName);
        }

        public static string GetSceneAsset(string assetName)
        {
            return Utility.Text.Format("Assets/GameMain/Scenes/{0}.unity", assetName);
        }

        public static string GetMusicAsset(string assetName)
        {
            return Utility.Text.Format("Assets/GameMain/AssetsPackage/Music/{0}.mp3", assetName);
        }

        public static string GetSoundAsset(string assetName)
        {
            return Utility.Text.Format("Assets/GameMain/AssetsPackage/Sounds/{0}.wav", assetName);
        }

        public static string GetEntityAsset(string assetName)
        {
            return Utility.Text.Format("Assets/GameMain/AssetsPackage/Entities/{0}.prefab", assetName);
        }

        public static string GetUIFormAsset(string assetName)
        {
            return Utility.Text.Format("Assets/GameMain/AssetsPackage/UI/UIForms/{0}.prefab", assetName);
        }

        public static string GetUISoundAsset(string assetName)
        {
            return Utility.Text.Format("Assets/GameMain/AssetsPackage/UI/UISounds/{0}.wav", assetName);
        }
    }
}
