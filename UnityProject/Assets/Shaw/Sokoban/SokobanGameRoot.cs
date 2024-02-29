using System;
using System.Collections.Generic;
using GameLogic;
using UnityEngine;

public class GameRoot<T> : MonoBehaviour where T : class
{
    public static T _Instance;
    private Dictionary<Type, Manager> _Dict_Manager = new Dictionary<Type, Manager>();

    private Transform _managerRoot;
    private Transform _controllerRoot;

    protected virtual void Awake()
    {
        if (_Instance == null)
        {
            _Instance = this as T;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public Transform _ManagerRoot
    {
        get
        {
            if (_managerRoot == null)
            {
                _managerRoot = new GameObject("ManagerRoot").transform;
                _managerRoot.transform.SetParent(transform);
            }

            return _managerRoot;
        }
    }

    public Transform _ControllerRoot
    {
        get
        {
            if (_controllerRoot == null)
            {
                _controllerRoot = new GameObject("ControllerRoot").transform;
                _controllerRoot.transform.SetParent(transform);
            }

            return _controllerRoot;
        }
    }

    public T AddManager<T>() where T : Manager
    {
        Manager t;
        if (_Dict_Manager.TryGetValue(typeof(T), out t))
        {
            return t as T;
        }
        else
        {
            GameObject gameObject = new GameObject();
            gameObject.transform.SetParent(_ManagerRoot);
            t = gameObject.AddComponent<T>();
            _Dict_Manager.Add(typeof(T), t);
        }

        return t as T;
    }

    public T GetManager<T>() where T : Manager
    {
        Manager t;
        if (_Dict_Manager.TryGetValue(typeof(T), out t))
        {
            return t as T;
        }

        return null;
    }
}

public class SokobanGameRoot : GameRoot<SokobanGameRoot>
{
    protected override void Awake()
    {
        base.Awake();
        AddManager<SokobanMapManager>();
    }
}