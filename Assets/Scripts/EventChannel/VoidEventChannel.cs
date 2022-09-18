using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/EventChannel/VoidEventChannel", fileName = "VoidEventChannel_")]
public class VoidEventChannel : ScriptableObject
{
    Action voidDelegate;
    public void Boardcast()
    {
        voidDelegate?.Invoke();
    }

    public void AddListener(Action action)
    {
        voidDelegate+=action;
    }

    public void removeListener(Action action)
    {
        voidDelegate-=action;
    }
}
