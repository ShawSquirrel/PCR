using System.Collections.Generic;
using UnityEngine;

namespace GameLogic.NewArchitecture.Core
{
    public class Unit : IUnit
    {
        public static Dictionary<GameObject, Unit> S_GameObjectToUnitDict;

        static Unit()
        {
            S_GameObjectToUnitDict = new Dictionary<GameObject, Unit>();
        }

        public GameObject _Obj;
        public Transform _TF;

        public Unit(Transform parent, string name)
        {
            _Obj = new GameObject(name);
            _TF = _Obj.transform;
            _TF.position = Vector3.zero;

            _TF.SetParent(parent);
            S_GameObjectToUnitDict.Add(_Obj, this);
        }

        public Unit(GameObject obj, Transform parent, string name = "")
        {
            _Obj = obj;
            _TF = _Obj.transform;
            if (!string.IsNullOrEmpty(name)) _TF.name = name;

            _TF.position = Vector3.zero;

            _TF.SetParent(parent);
            S_GameObjectToUnitDict.Add(_Obj, this);
        }

        public T AddComponent<T>() where T : Component
        {
            return _Obj.AddComponent<T>();
        }

        public T GetComponent<T>() where T : Component
        {
            return _Obj.GetComponent<T>();
        }

        public Transform SetName(string name)
        {
            _Obj.name = name;
            return _TF;
        }

        public Transform SetPos(Vector3 pos)
        {
            _TF.position = pos;
            return _TF;
        }

        public Transform SetLocalPos(Vector3 pos)
        {
            _TF.localPosition = pos;
            return _TF;
        }

        public virtual void Destroy()
        {
            if (_Obj == null) return;
            S_GameObjectToUnitDict.Remove(_Obj);
            Object.Destroy(_Obj);
            _TF = null;
            _Obj = null;
        }

        public virtual void Enable()
        {
            _Obj.SetActive(true);
        }

        public virtual void Disable()
        {
            _Obj.SetActive(false);
        }
    }
}