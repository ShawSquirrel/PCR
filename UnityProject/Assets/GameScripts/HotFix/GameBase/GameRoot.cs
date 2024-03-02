using System;
using System.Collections.Generic;
using UnityEngine;

namespace GameBase
{
    public class GameRoot : MonoSingleton<GameRoot>
    {
        public Action OnUpdate;
        
        
        private Dictionary<Type, Manager> _Dict_Manager = new Dictionary<Type, Manager>();

        private Transform _managerRoot;
        private Transform _controllerRoot;

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


        public T AddManager<T>() where T : Manager, new()
        {
            if (_Dict_Manager.TryGetValue(typeof(T), out var t))
            {
                return t as T;
            }

            GameObject obj = new GameObject($"{typeof(T).Name}");
            obj.transform.SetParent(_ManagerRoot);
            t = new T();
            t._Obj = obj;
            t._TF = obj.transform;
            t._GameRoot = this;
            _Dict_Manager.Add(typeof(T), t);
            
            t.Awake();

            return (T)t;
        }

        public T GetManager<T>() where T : Manager
        {
            if (_Dict_Manager.TryGetValue(typeof(T), out var t))
            {
                return t as T;
            }

            return null;
        }


        private void Update()
        {
            OnUpdate?.Invoke();
        }
    }
}