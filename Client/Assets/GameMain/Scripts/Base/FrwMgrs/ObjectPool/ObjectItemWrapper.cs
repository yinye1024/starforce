using GameFramework;
using GameFramework.ObjectPool;

namespace GameMain.Base
{
    public class ObjectItemWrapper: ObjectBase
    {
        public static ObjectItemWrapper Create(ObjectItem target)
        {
            // 在 pool 做 release 的时候会调用 ReferencePool.Release 释放ObjectItemWrapper，所以这里只要Acquire就行了
            ObjectItemWrapper objItemItemWrapper = ReferencePool.Acquire<ObjectItemWrapper>();
            objItemItemWrapper.Initialize(target);
            return objItemItemWrapper;
        }

        protected override void Release(bool isShutdown)
        {
            ObjectItem objItem = (ObjectItem)Target;
            objItem.OnRelease();
        }
    }
}