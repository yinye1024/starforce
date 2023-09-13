/*----------------------------------------------------------------
// Author：隐叶
// Copyright © 2023-2030 YinYe. All rights reserved.
//===============================================================
// 功能描述：
//
//----------------------------------------------------------------*/

using GameFramework.Localization;
using System;
using GameMain.Base;
using UnityGameFramework.Runtime;

namespace GameMain.Game
{
    public class LaunchMgr:Singleton<LaunchMgr>
    {
        
        public void InitLanguageSettings()
        {
            if (BaseMgr.Instance.IsEditorResourceMode() && BaseMgr.Instance.GetEditorLanguage() != Language.Unspecified)
            {
                // 编辑器资源模式直接使用 Inspector 上设置的语言
                return;
            }

            Language language = LocalizationMgr.Instance.GetLanguage();
            if (SettingMgr.Instance.HasSetting(Constant.Setting.Language))
            {
                try
                {
                    string languageString = SettingMgr.Instance.GetString(Constant.Setting.Language);
                    language = (Language)Enum.Parse(typeof(Language), languageString);
                }
                catch
                {
                }
            }

            if (language != Language.English
                && language != Language.ChineseSimplified
                && language != Language.ChineseTraditional
                && language != Language.Korean)
            {
                // 若是暂不支持的语言，则使用英语
                language = Language.English;

                SettingMgr.Instance.SetString(Constant.Setting.Language, language.ToString());
                SettingMgr.Instance.Save();
            }

            LocalizationMgr.Instance.SetLanguage(language);
            Log.Info("Init language settings complete, current language is '{0}'.", language.ToString());
        }

        // 初始化变体
        public void InitCurrentVariant()
        {
            if (BaseMgr.Instance.IsEditorResourceMode())
            {
                // 编辑器资源模式不使用 AssetBundle，也就没有变体了
                return;
            }

            string currentVariant = null;
            switch (LocalizationMgr.Instance.GetLanguage())
            {
                case Language.English:
                    currentVariant = "en-us";
                    break;

                case Language.ChineseSimplified:
                    currentVariant = "zh-cn";
                    break;

                case Language.ChineseTraditional:
                    currentVariant = "zh-tw";
                    break;

                case Language.Korean:
                    currentVariant = "ko-kr";
                    break;

                default:
                    currentVariant = "zh-cn";
                    break;
            }

            ResMgr.Instance.SetCurrentVariant(currentVariant);
            Log.Info("Init current variant complete.");
        }

        public void InitSoundSettings()
        {
            SoundMgr.Instance.Mute("Music", SettingMgr.Instance.GetBool(Constant.Setting.MusicMuted, false));
            SoundMgr.Instance.SetVolume("Music", SettingMgr.Instance.GetFloat(Constant.Setting.MusicVolume, 0.3f));
            SoundMgr.Instance.Mute("Sound", SettingMgr.Instance.GetBool(Constant.Setting.SoundMuted, false));
            SoundMgr.Instance.SetVolume("Sound", SettingMgr.Instance.GetFloat(Constant.Setting.SoundVolume, 1f));
            SoundMgr.Instance.Mute("UISound", SettingMgr.Instance.GetBool(Constant.Setting.UISoundMuted, false));
            SoundMgr.Instance.SetVolume("UISound", SettingMgr.Instance.GetFloat(Constant.Setting.UISoundVolume, 1f));
            Log.Info("Init sound settings complete.");
        }
    }
}