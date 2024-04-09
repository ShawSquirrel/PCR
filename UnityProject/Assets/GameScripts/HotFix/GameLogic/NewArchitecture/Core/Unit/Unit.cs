using System.Collections.Generic;
using UnityEngine;
using NotImplementedException = System.NotImplementedException;

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
        public Vector3 Position => _TF.position;
        public Vector3 LocalPosition => _TF.localPosition;

        public Unit(Transform parent, string name)
        {
            _Obj = new GameObject(name);
            _TF = _Obj.transform;
            _TF.position = Vector3.zero;

            SetParent(parent);
            S_GameObjectToUnitDict.Add(_Obj, this);
        }

        public Unit(GameObject obj, Transform parent)
        {
            _Obj = obj;
            _TF = _Obj.transform;

            _TF.position = Vector3.zero;

            SetParent(parent);
            S_GameObjectToUnitDict.Add(_Obj, this);
        }
        public Unit(GameObject obj, Transform parent, string name)
        {
            _Obj = obj;
            _TF = _Obj.transform;

            _TF.position = Vector3.zero;

            SetParent(parent);
            SetName(name);
            S_GameObjectToUnitDict.Add(_Obj, this);
        }

        public Unit(GameObject obj)
        {
            _Obj = obj;
            _TF = _Obj.transform;

            _TF.position = Vector3.zero;

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

        public T GetComponentInChildren<T>() where T : Component
        {
            return _Obj.GetComponentInChildren<T>();
        }

        public virtual IUnit SetName(string name)
        {
            _Obj.name = name;
            return this;
        }

        public virtual IUnit SetPos(Vector3 pos)
        {
            _TF.position = pos;
            return this;
        }

        public virtual IUnit SetLocalPos(Vector3 pos)
        {
            _TF.localPosition = pos;
            return this;
        }

        public virtual void Destroy()
        {
            if (_Obj == null) return;
            S_GameObjectToUnitDict.Remove(_Obj);
            Object.Destroy(_Obj);
            _TF = null;
            _Obj = null;
        }

        public virtual IUnit Enable()
        {
            if (_Obj.activeSelf != true) ;
            _Obj.SetActive(true);
            return this;
        }

        public virtual IUnit Disable()
        {
            if (_Obj.activeSelf != false) ;
            _Obj.SetActive(false);
            return this;
        }

        public virtual IUnit SetLocalRotation(Quaternion quaternion)
        {
            _TF.localRotation = quaternion;
            return this;
        }

        public virtual IUnit SetRotation(Quaternion quaternion)
        {
            _TF.rotation = quaternion;
            return this;
        }

        public virtual IUnit SetParent(Unit parent)
        {
            return SetParent(parent._TF);
        }

        public virtual IUnit SetParent(Transform parent)
        {
            _TF.SetParent(parent);
            return this;
        }
    }
}