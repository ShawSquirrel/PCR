using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : MonoBehaviour
{
    public Action OnDestroyEvent;
    public void AddListen(Action onDestroy)
    {
        OnDestroyEvent = onDestroy;
    }
    private void OnDestroy()
    {
        OnDestroyEvent?.Invoke();
    }
}
