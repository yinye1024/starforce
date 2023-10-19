namespace GameMain.Base
{
    public interface INetworkAgent
    {
        public void RouteS2C(PacketS2C packetS2C);
    }
}