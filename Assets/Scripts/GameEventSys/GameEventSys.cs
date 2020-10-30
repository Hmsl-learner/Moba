using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameEventType
{
    Null,
    EnemyKilled,
    SoldierKilled,
}
public class GameEventSys : IGameSys
{
    private Dictionary<GameEventType, IGameEventSubject> mGameEvents = new Dictionary<GameEventType, IGameEventSubject>();
    public override void Init()
    {
        base.Init();
        InitGameEvents();
    }
    public void InitGameEvents()
    {
    }
    // 注册
    public void RegisterObserver(GameEventType eventType,IGameEventObserver observer)
    {
        IGameEventSubject sub = GetGameEvent(eventType);
        if (sub == null) return;
        sub.RegisterObserver(observer);
        observer.SetSubject(sub);
        
    }
    // 注销
    public void RemoveObserver(GameEventType eventType, IGameEventObserver observer)
    {
        IGameEventSubject sub = GetGameEvent(eventType);
        if (sub == null) return;
        sub.RemoveObserver(observer);
        observer.SetSubject(null);
        
    }
    public void NotifySubject(GameEventType eventType)
    {
        IGameEventSubject sub = GetGameEvent(eventType);
        if (sub == null) return;
        sub.Notify();
    }

    public IGameEventSubject GetGameEvent(GameEventType eventType)
    {
        if (mGameEvents.ContainsKey(eventType) == false)
        {
            switch (eventType)
            {
                case GameEventType.EnemyKilled:
                    mGameEvents.Add(GameEventType.EnemyKilled, new SoldierKilledSubject());
                    break;
                case GameEventType.SoldierKilled:
                    mGameEvents.Add(GameEventType.SoldierKilled, new SoldierKilledSubject());
                    break;
                default:
                    Debug.LogError("找不到" + eventType + "对应的主题");
                    return null;
            }
            
        }

        return mGameEvents[eventType];
    }

}
