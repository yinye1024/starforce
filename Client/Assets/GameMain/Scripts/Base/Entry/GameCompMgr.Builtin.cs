//------------------------------------------------------------
// Game Base
//------------------------------------------------------------

using UnityGameFramework.Runtime;

namespace GameMain.Base
{
    /// <summary>
    /// 游戏入口，总管理类。初始化 GameFramework 的框架组件
    /// </summary>
    public partial class GameCompMgr
    {
        /// <summary>
        /// 获取游戏基础组件。
        /// </summary>
        public static BaseComponent Base
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取配置组件。
        /// </summary>
        public static ConfigComponent Config
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取数据结点组件。
        /// </summary>
        public static DataNodeComponent DataNode
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取数据表组件。
        /// </summary>
        public static DataTableComponent DataTable
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取调试组件。
        /// </summary>
        public static DebuggerComponent Debugger
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取下载组件。
        /// </summary>
        public static DownloadComponent Download
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取实体组件。
        /// </summary>
        public static EntityComponent Entity
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取事件组件。
        /// </summary>
        public static EventComponent Event
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取文件系统组件。
        /// </summary>
        public static FileSystemComponent FileSystem
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取有限状态机组件。
        /// </summary>
        public static FsmComponent Fsm
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取本地化组件。
        /// </summary>
        public static LocalizationComponent Localization
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取网络组件。
        /// </summary>
        public static NetworkComponent Network
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取对象池组件。
        /// </summary>
        public static ObjectPoolComponent ObjectPool
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取流程组件。
        /// </summary>
        public static ProcedureComponent Procedure
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取资源组件。
        /// </summary>
        public static ResourceComponent Resource
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取场景组件。
        /// </summary>
        public static SceneComponent Scene
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取配置组件。
        /// </summary>
        public static SettingComponent Setting
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取声音组件。
        /// </summary>
        public static SoundComponent Sound
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取界面组件。
        /// </summary>
        public static UIComponent UI
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取网络组件。
        /// </summary>
        public static WebRequestComponent WebRequest
        {
            get;
            private set;
        }

        private static void InitBuiltinComponents()
        {
            Base = GameEntry.GetComponent<BaseComponent>();
            Config = GameEntry.GetComponent<ConfigComponent>();
            DataNode = GameEntry.GetComponent<DataNodeComponent>();
            DataTable = GameEntry.GetComponent<DataTableComponent>();
            Debugger = GameEntry.GetComponent<DebuggerComponent>();
            Download = GameEntry.GetComponent<DownloadComponent>();
            Entity = GameEntry.GetComponent<EntityComponent>();
            Event = GameEntry.GetComponent<EventComponent>();
            FileSystem = GameEntry.GetComponent<FileSystemComponent>();
            Fsm = GameEntry.GetComponent<FsmComponent>();
            Localization = GameEntry.GetComponent<LocalizationComponent>();
            Network = GameEntry.GetComponent<NetworkComponent>();
            ObjectPool = GameEntry.GetComponent<ObjectPoolComponent>();
            Procedure = GameEntry.GetComponent<ProcedureComponent>();
            Resource = GameEntry.GetComponent<ResourceComponent>();
            Scene = GameEntry.GetComponent<SceneComponent>();
            Setting = GameEntry.GetComponent<SettingComponent>();
            Sound = GameEntry.GetComponent<SoundComponent>();
            UI = GameEntry.GetComponent<UIComponent>();
            WebRequest = GameEntry.GetComponent<WebRequestComponent>();
        }
        
    }
}
