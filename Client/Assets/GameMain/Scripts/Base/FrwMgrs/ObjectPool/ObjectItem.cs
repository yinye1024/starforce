namespace GameMain.Base
{
    public interface  ObjectItem
    {
        // 第一次创建的时候调用
        public void OnCreate();
        // 每次从pool里获取之后调用
        public void OnSpawn();
        // 每次返回给 pool 之前时候调用
        public void OnUnSpawn();
        // 每次从池里销毁的时候调用
        public void OnRelease();
    }
}