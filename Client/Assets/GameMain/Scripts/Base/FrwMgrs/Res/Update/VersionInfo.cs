//------------------------------------------------------------
// 对应的是打包出来的 AssetBundles\Full\WindowsVersion.txt 文件
// 这个文件会放到http服务器上，客户端检查更新的时候通过web获取该文件，并转换成 VersionInfo 对象。
//------------------------------------------------------------

using GameFramework;

namespace GameMain.Game
{
    public class VersionInfo
    {
        public static VersionInfo FromJson(string jsonStr)
        {
            return Utility.Json.ToObject<VersionInfo>(jsonStr);
        }

        // 是否需要强制更新游戏应用
        public bool ForceUpdateGame
        {
            get;
            set;
        }

        // 最新的游戏版本号
        public string LatestGameVersion
        {
            get;
            set;
        }

        // 最新的游戏内部版本号
        public int InternalGameVersion
        {
            get;
            set;
        }

        // 最新的资源内部版本号
        public int InternalResourceVersion
        {
            get;
            set;
        }

        // 资源更新下载地址
        public string UpdatePrefixUri
        {
            get;
            set;
        }

        // 资源版本列表长度
        public int VersionListLength
        {
            get;
            set;
        }

        // 资源版本列表哈希值
        public int VersionListHashCode
        {
            get;
            set;
        }

        // 资源版本列表压缩后长度
        public int VersionListCompressedLength
        {
            get;
            set;
        }

        // 资源版本列表压缩后哈希值
        public int VersionListCompressedHashCode
        {
            get;
            set;
        }
    }
}
