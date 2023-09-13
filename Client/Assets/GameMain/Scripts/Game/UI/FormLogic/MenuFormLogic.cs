//------------------------------------------------------------
// Game Framework
// Copyright © 2013-2021 Jiang Yin. All rights reserved.
// Homepage: https://gameframework.cn/
// Feedback: mailto:ellan@gameframework.cn
//------------------------------------------------------------

using UnityEngine;
using UnityGameFramework.Runtime;
using GameMain.Base;

namespace GameMain.Game
{
    public class MenuFormLogic : UGuiFormLogic
    {
        [SerializeField]
        private GameObject m_QuitButton = null;

        public void OnStartButtonClick()
        {
            MenuMgr.Instance.DoStartGame();
        }

        public void OnSettingButtonClick()
        {
            UIMgr.Instance.OpenUIForm(UIFormId.SettingForm);
        }

        public void OnAboutButtonClick()
        {
            UIMgr.Instance.OpenUIForm(UIFormId.AboutForm);
        }

        public void OnQuitButtonClick()
        {
            UIMgr.Instance.OpenDialog(new DialogParams()
            {
                Mode = 2,
                Title = LocalizationMgr.Instance.GetString("AskQuitGame.Title"),
                Message = LocalizationMgr.Instance.GetString("AskQuitGame.Message"),
                OnClickConfirm = delegate (object userData) { UnityGameFramework.Runtime.GameEntry.Shutdown(ShutdownType.Quit); },
            },false);
        }

        protected override void OnOpen(object userData)
        {
            base.OnOpen(userData);

            m_QuitButton.SetActive(Application.platform != RuntimePlatform.IPhonePlayer);
        }

    }
}
