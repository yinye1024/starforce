//------------------------------------------------------------
// Game Base
//------------------------------------------------------------


using System;
using GameMain.Game;
using UnityEngine;

namespace GameMain.Base
{
    /// <summary>
    /// 游戏入口，总管理类。
    /// </summary>
    public partial class GameCompMgr : MonoBehaviour
    {
        private void Start()
        {
            InitBuiltinComponents();
            InitCustomComponents();
            MonoBehavMgr.Instance.Start();
        }

        private void Update()
        {
            MonoBehavMgr.Instance.Update();
        }

        private void OnDestroy()
        {
            MonoBehavMgr.Instance.OnDestroy();
        }
    }
}
