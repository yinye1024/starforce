//------------------------------------------------------------
// Game Framework
// Copyright © 2013-2021 Jiang Yin. All rights reserved.
// Homepage: https://gameframework.cn/
// Feedback: mailto:ellan@gameframework.cn
//------------------------------------------------------------

using GameFramework.Event;
using GameMain.Base;
using UnityGameFramework.Runtime;
using ProcedureOwner = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;

namespace GameMain.Game
{
    public class MenuMgr : Singleton<MenuMgr>
    {
        public bool IsStartGame { get; private set; } = false;
        private MenuFormLogic _menuForm = null;

        public void DoStartGame()
        {
            this.IsStartGame = true;
        }

        public void OnEnter()
        {
            IsStartGame = false;
            EventMgr.Instance.Subscribe(OpenUIFormSuccessEventArgs.EventId, OnOpenUIFormSuccess);
            UIMgr.Instance.OpenUIForm(UIFormId.MenuForm, this);
        }

        public void OnLeave(bool isShutdown)
        {

            EventMgr.Instance.Unsubscribe(OpenUIFormSuccessEventArgs.EventId, OnOpenUIFormSuccess);

            if (_menuForm != null)
            {
                _menuForm.Close(isShutdown);
                _menuForm = null;
            }
        }

        private void OnOpenUIFormSuccess(object sender, GameEventArgs e)
        {
            OpenUIFormSuccessEventArgs ne = (OpenUIFormSuccessEventArgs)e;
            if (ne.UserData != this)
            {
                return;
            }
            _menuForm = (MenuFormLogic)ne.UIForm.Logic;
        }
    }
}
