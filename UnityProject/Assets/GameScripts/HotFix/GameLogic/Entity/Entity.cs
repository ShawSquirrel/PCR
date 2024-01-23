using UnityEngine;

namespace GameLogic
{
    public class Entity : MonoBehaviour
    {
        [HideInInspector]
        public GameObject _GO;
        [HideInInspector]
        public Transform _TF;

        public Camera _Camera;

        protected virtual void Awake()
        {
            _GO = gameObject;
            _TF = transform;

            CustomModule.CameraModule.AddCameraStack(_Camera);
        }

        
    }

}