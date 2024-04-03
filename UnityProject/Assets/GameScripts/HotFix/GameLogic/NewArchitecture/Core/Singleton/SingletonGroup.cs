using System;
using System.Collections.Generic;

namespace GameLogic.NewArchitecture.Core
{
    public static class SingletonGroup
    {
        private static Dictionary<Type, ISingleton> _singletonDict;
        private static Dictionary<Type, ISingleton> _monoSingletonDict;

        static SingletonGroup()
        {
            _singletonDict = new Dictionary<Type, ISingleton>();
            _monoSingletonDict = new Dictionary<Type, ISingleton>();
        }
        public static T GetSingleton<T>() where T : class, ISingleton, new()
        {
            Type type = typeof(T);
            if (_singletonDict.TryGetValue(type, out ISingleton singleton) == true)
            {
                return singleton as T;
            }

            T t = new T();
            _singletonDict.Add(typeof(T), t);
            t.OnSingletonInit();
            return t;
        }
    }
}