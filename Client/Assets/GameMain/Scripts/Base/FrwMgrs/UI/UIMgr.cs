/*----------------------------------------------------------------
// Author：隐叶
// Copyright © 2023-2030 YinYe. All rights reserved.
//===============================================================
// 功能描述：
//  实现对 UI界面，也就是 UIForm 的管理,打开，关闭，获取 等
//----------------------------------------------------------------*/

using GameFramework.UI;
using DataTable;
using GameFramework.Resource;
using GameMain.Game;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace GameMain.Base
{
    public class UIMgr:Singleton<UIMgr>
    {
        public bool IsOnLoading = false;
        public void LoadFont(string fontName)
        {
            this.IsOnLoading = true;
            ResMgr.Instance.LoadAsset(AssetPathUtils.GetFontAsset(fontName), Constant.AssetPriority.FontAsset, new LoadAssetCallbacks(
                (assetName, asset, duration, userData) =>
                {
                    this.IsOnLoading = false;
                    UGuiFormLogic.SetMainFont((Font)asset);
                    Log.Info("Load font '{0}' OK.", fontName);
                },

                (assetName, status, errorMessage, userData) =>
                {
                    this.IsOnLoading = false;
                    Log.Error("Can not load font '{0}' from '{1}' with error message '{2}'.", fontName, assetName, errorMessage);
                }));
        }
        

        public bool HasUIForm(UIFormId uiFormId, string uiGroupName = null)
        {
            return HasUIForm((int)uiFormId, uiGroupName);
        }

        public bool HasUIForm(int uiFormId, string uiGroupName = null)
        {
            DTUIForm dtuiForm = DataTableMgr.Instance.GetDataRow<DTUIForm>(uiFormId);
            if (dtuiForm == null)
            {
                return false;
            }

            string assetName = AssetPathUtils.GetUIFormAsset(dtuiForm.AssetName);
            if (string.IsNullOrEmpty(uiGroupName))
            {
                return GameCompMgr.UI.HasUIForm(assetName);
            }

            IUIGroup uiGroup = GameCompMgr.UI.GetUIGroup(uiGroupName);
            if (uiGroup == null)
            {
                return false;
            }

            return uiGroup.HasUIForm(assetName);
        }

        public UGuiFormLogic GetUIForm(UIFormId uiFormId, string uiGroupName = null)
        {
            return GetUIForm((int)uiFormId, uiGroupName);
        }

        public UGuiFormLogic GetUIForm( int uiFormId, string uiGroupName = null)
        {
            DTUIForm dtuiForm = DataTableMgr.Instance.GetDataRow<DTUIForm>(uiFormId);
            if (dtuiForm == null)
            {
                return null;
            }

            string assetName = AssetPathUtils.GetUIFormAsset(dtuiForm.AssetName);
            UIForm uiForm = null;
            if (string.IsNullOrEmpty(uiGroupName))
            {
                uiForm = GameCompMgr.UI.GetUIForm(assetName);
                if (uiForm == null)
                {
                    return null;
                }

                return (UGuiFormLogic)uiForm.Logic;
            }

            IUIGroup uiGroup = GameCompMgr.UI.GetUIGroup(uiGroupName);
            if (uiGroup == null)
            {
                return null;
            }

            uiForm = (UIForm)uiGroup.GetUIForm(assetName);
            if (uiForm == null)
            {
                return null;
            }

            return (UGuiFormLogic)uiForm.Logic;
        }

        public void CloseUIForm(UGuiFormLogic uiFormLogic)
        {
            GameCompMgr.UI.CloseUIForm(uiFormLogic.UIForm);
        }

        public int? OpenUIForm(UIFormId uiFormId, object userData = null)
        {
            return OpenUIForm((int)uiFormId, userData);
        }

        public int? OpenUIForm( int uiFormId, object userData = null)
        {
            DTUIForm dtUIForm = DataTableMgr.Instance.GetDataRow<DTUIForm>(uiFormId);
            if (dtUIForm == null)
            {
                Log.Warning("Can not load UI form '{0}' from data table.", uiFormId.ToString());
                return null;
            }

            string assetName = AssetPathUtils.GetUIFormAsset(dtUIForm.AssetName);
            if (!dtUIForm.AllowMultiInstance)
            {
                if (GameCompMgr.UI.IsLoadingUIForm(assetName))
                {
                    return null;
                }

                if (GameCompMgr.UI.HasUIForm(assetName))
                {
                    return null;
                }
            }

            return GameCompMgr.UI.OpenUIForm(assetName, dtUIForm.UIGroupName, Constant.AssetPriority.UIFormAsset, dtUIForm.PauseCoveredUIForm, userData);
        }

        public void OpenDialog(DialogParams dialogParams,bool userNative)
        {
            if (userNative)
            {
                OpenNativeDialog(dialogParams);
            }
            else
            {
                OpenUIForm(UIFormId.DialogForm, dialogParams);
            }
        }

        private void OpenNativeDialog(DialogParams dialogParams)
        {
            // TODO：这里应该弹出原生对话框，先简化实现为直接按确认按钮
            if (dialogParams.OnClickConfirm != null)
            {
                dialogParams.OnClickConfirm(dialogParams.UserData);
            }
        }

        
    }
}
