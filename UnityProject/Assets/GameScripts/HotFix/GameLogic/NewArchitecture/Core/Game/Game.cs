using System;
using System.Collections.Generic;
using UnityEngine;

namespace GameLogic.NewArchitecture.Core
{
    public abstract class Game : IGame
    {
        protected Dictionary<Type, System> _systemDict;
        protected Dictionary<Type, Model> _modelDict;
        public Unit Unit;

        public virtual void Awake()
        {
            _systemDict = new Dictionary<Type, System>();
            _modelDict  = new Dictionary<Type, Model>();
        }

        public virtual void Destroy()
        {
        }

        public virtual void Init()
        {
        }

        public virtual void Release()
        {
        }

        public virtual void ExecuteEmpty()
        {
        }

        public virtual void InitUnit(Transform parent, string name)
        {
            if (Unit != null) return;
            Unit = new Unit(parent, name);
        }
        public virtual void DestroyUnit()
        {
            if (Unit == null) return;
            Unit.Destroy();
            Unit = null;
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
            t.Create();
            _systemDict.Add(type, t);
            if (hasUnit)
            {
                t.InitUnit(Unit._TF, type.Name);
            }

            return t;
        }

        public virtual void RemoveSystem<T>() where T : System, new()
        {
            Type type = typeof(T);
            if (_systemDict.TryGetValue(type, out var system) == false)
            {
                return;
            }
            system.Destroy();
            _systemDict.Remove(type);
        }
        

        public virtual void RemoveAllSystem()
        {
            foreach (var (type, system) in _systemDict)
            {
                system.Destroy();
            }

            _systemDict.Clear();
        }
        public virtual void RemoveAllModel()
        {
            foreach (var (type, model) in _modelDict)
            {
                model.Release();
                model.Destroy();
            }

            _modelDict.Clear();
        }

        public virtual T GetModel<T>() where T : Model, new()
        {
            Type type = typeof(T);
            if (_modelDict.TryGetValue(type, out Model model) == false)
            {
                return null;
            }

            return model as T;
        }

        public virtual T AddModel<T>() where T : Model, new()
        {
            Type type = typeof(T);
            T t;
            if (_modelDict.TryGetValue(type, out Model model) == true)
            {
                t = model as T;
                return t;
            }

            t = new T();
            t.Awake();
            _modelDict.Add(type, t);
            return t;
        }

    }
}