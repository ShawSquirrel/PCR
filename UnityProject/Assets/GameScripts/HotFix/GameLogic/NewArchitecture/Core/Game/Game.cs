using System;
using System.Collections.Generic;
using UnityEngine;

namespace GameLogic.NewArchitecture.Core
{
    public abstract class Game : IGame
    {
        protected Dictionary<Type, System> _systemDict;
        public Unit Unit;

        public virtual void Init()
        {
        }

        public virtual void InitUnit(Transform parent, string name)
        {
            Unit = new Unit(parent, name);
        }

        public virtual T GetSystem<T>() where T : System, new()
        {
            Type type = typeof(T);
            if (_systemDict.TryGetValue(type, out var system) == false)
            {
                return null;
            }

            return system as T;
        }

        /// <summary>
        /// 测试
        /// </summary>
        /// <param name="hasUnit"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public virtual T AddSystem<T>(bool hasUnit = false) where T : System, new()
        {
            Type type = typeof(T);
            T t;
            if (_systemDict.TryGetValue(type, out System system) == true)
            {
                t = system as T;
                return t;
            }

            t = new T();
            t.Init();

            if (hasUnit)
            {
                t.InitUnit(Unit._TF, type.Name);
            }

            return t;
        }
    }
}