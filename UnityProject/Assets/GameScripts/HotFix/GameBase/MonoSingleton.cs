using System;
using UnityEngine;

namespace GameBase
{
    public class MonoSingleton<T> : MonoBehaviour where T : MonoSingleton<T>
    {
        /// <summary>
        /// 静态实例
        /// </summary>
        protected static T _instance;

        /// <summary>
        /// 静态属性：封装相关实例对象
        /// </summary>
        public static T _Instance
        {
            get
            {
                // if (mInstance == null)
                // {
                //     mInstance = SingletonCreator.CreateMonoSingleton<T>();
                // }

                return _instance;
            }
        }

        protected virtual void Awake()
        {
            if (_instance == null)
            {
                _instance = this as T;
            }
            else
            {
                Destroy(this.gameObject);
            }
        }
    }
}