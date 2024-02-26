using System;
using System.Collections;
using System.Collections.Generic;
using GameBase;
using UnityEngine;

namespace GameLogic
{
    public class GameRoot : MonoSingleton<GameRoot>
    {
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
}