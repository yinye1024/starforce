
// 实现普通的单例模式
// where 限制模板的类型, new()指的是这个类型必须要能被实例化


namespace GameMain.Base
{
    public abstract class Singleton<T> where T : new()
    {
        private static T _instance;
        private static readonly object Mutex = new object();

        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (Mutex)
                    {
                        // 保证我们的单例，是线程安全的;
                        if (_instance == null)
                        {
                            _instance = new T();
                        }
                    }
                }

                return _instance;
            }
        }
    }
}




