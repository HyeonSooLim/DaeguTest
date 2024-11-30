using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameEvent { }

public class EventManager : Singleton<EventManager>
{
    public System.Action OnActionSerach;

    public static readonly Dictionary<GameEvent, System.Action> eventDictionary = new Dictionary<GameEvent, System.Action>();
    public static readonly Dictionary<Type, System.Action<GameEvent>> eventDic = new Dictionary<Type, System.Action<GameEvent>>();

    public void AddListener(GameEvent gameEvent, System.Action action)
    {
        if (!eventDictionary.ContainsKey(gameEvent))
        {
            eventDictionary.Add(gameEvent, action);
        }
        else
        {
            Debug.LogWarning("This event is already exist.");
        }
    }

    public void AddListener<T>(Action<T> action) where T : GameEvent
    {
        if (!eventDic.ContainsKey(typeof(T)))
        {
            eventDic.Add(typeof(T), (e) => action((T)e));
        }
        else
        {
            Debug.LogWarning("This event is already exist.");
        }
    }

    public void RemoveListener(GameEvent gameEvent)
    {
        if (eventDictionary.ContainsKey(gameEvent))
        {
            eventDictionary[gameEvent] = null;
            eventDictionary.Remove(gameEvent);
        }
        else
        {
            Debug.LogWarning("This event is not exist.");
        }
    }

    public void RemoveListener<T>(Action<T> action) where T : GameEvent
    {
        if (eventDic.ContainsKey(typeof(T)))
        {
            eventDic.Remove(typeof(T));
        }
        else
        {
            Debug.LogWarning("This event is not exist.");
        }
    }

    public void BroadCast(GameEvent gameEvent)
    {
        if (eventDictionary.TryGetValue(gameEvent, out System.Action action))
        {
            action.Invoke();
        }
        else
        {
            Debug.LogWarning("This event is not exist.");
        }
    }

    public void BroadCastByType(GameEvent gameEvent)
    {
        if (eventDic.TryGetValue(gameEvent.GetType(), out System.Action<GameEvent> action))
        {
            action.Invoke(gameEvent);
        }
        else
        {
            Debug.LogWarning("This event is not exist.");
        }
    }
}