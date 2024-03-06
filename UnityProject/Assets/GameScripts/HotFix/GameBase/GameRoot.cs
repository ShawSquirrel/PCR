using System;
using System.Collections.Generic;
using TEngine;
using UnityEngine;

namespace GameBase
{
    public abstract class GameRoot
    {
        private UnityArgs _unityArgs;

        private Dictionary<Type, System> _Dict_Manager = new Dictionary<Type, System>();

        public GameRoot(GameObject obj)
        {
            _unityArgs = new UnityArgs { _Obj = obj, _TF = obj.transform };
            Awake();
        }

        private Transform _systemRoot;

        private Transform SystemRoot
        {
            get
            {
                if (_systemRoot == null)
                {
                    _systemRoot = new GameObject("SystemRoot").transform;
                    _systemRoot.transform.SetParent(_unityArgs._TF);
                }

                return _systemRoot;
            }
        }


        protected T AddManager<T>() where T : System, new()
        {
            if (_Dict_Manager.TryGetValue(typeof(T), out var t))
            {
                return t as T;
            }

            GameObject obj = new GameObject($"{typeof(T).Name}");
            obj.transform.SetParent(SystemRoot);
            t           = new T();
            t._Obj      = obj;
            t._TF       = obj.transform;
            t._GameRoot = this;
            _Dict_Manager.Add(typeof(T), t);

            t.Awake();

            return (T)t;
        }

        protected void RemoveManager<T>() where T : System, new()
        {
            if (_Dict_Manager.TryGetValue(typeof(T), out var t))
            {
                T target = t as T;
                target.OnDestroy();
                GameObject.Destroy(target._Obj);
            }
        }

        protected T GetManager<T>() where T : System
        {
            if (_Dict_Manager.TryGetValue(typeof(T), out var t))
            {
                return t as T;
            }

            return null;
        }

        protected virtual void Awake()
        {
            
        }
    }
}