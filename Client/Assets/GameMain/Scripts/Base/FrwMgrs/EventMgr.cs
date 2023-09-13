

using System;
using System.Collections.Generic;
using GameFramework.Event;
using UnityGameFramework.Runtime;

namespace GameMain.Base
{
    public class EventMgr:Singleton<EventMgr>
    {
        
        public void Subscribe(int eventId, EventHandler<GameEventArgs> eventHandler)
        {
            GameCompMgr.Event.Subscribe(eventId,  eventHandler);
        }
        public void Unsubscribe(int eventId, EventHandler<GameEventArgs> eventHandler)
        {
            GameCompMgr.Event.Unsubscribe(eventId,  eventHandler);
        }

    }
}