//------------------------------------------------------------
// Game Base
//------------------------------------------------------------


using GameMain.Game;

namespace GameMain.Base
{
    /// <summary>
    /// 游戏入口，总管理类。初始化 游戏自定义的框架组件
    /// </summary>
    public partial class GameCompMgr
    {
        public static BuiltinDataComponent BuiltinData
        {
            get;
            private set;
        }

        public static HpBarComponent HPBar
        {
            get;
            private set;
        }

        private static void InitCustomComponents()
        {
            BuiltinData = UnityGameFramework.Runtime.GameEntry.GetComponent<BuiltinDataComponent>();
            HPBar = UnityGameFramework.Runtime.GameEntry.GetComponent<HpBarComponent>();
        }
        
    }
}
