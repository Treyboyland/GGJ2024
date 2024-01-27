using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameEvent-", menuName = "Utility/Game Event")]
public class GameEvent : ScriptableObject
{
    List<GameEventListener> listeners = new List<GameEventListener>();

    public void Register(GameEventListener eventListener)
    {
        foreach (var listener in listeners)
        {
            if (eventListener == listener)
            {
                return;
            }
        }

        listeners.Add(eventListener);
    }

    public void Unregister(GameEventListener eventListener)
    {
        listeners.Remove(eventListener);
    }

    public void Invoke()
    {
        foreach (var listener in listeners)
        {
            if (listener != null)
            {
                listener.OnEventInvoked.Invoke();
            }
        }
    }
}
