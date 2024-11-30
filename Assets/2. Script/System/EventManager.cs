using System.Collections.Generic;
using UnityEngine;

public class GameEvent { }

public class EventManager : Singleton<EventManager>
{
    public System.Action OnActionSerach;

    public static readonly Dictionary<GameEvent, System.Action> eventDictionary = new Dictionary<GameEvent, System.Action>();

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
}