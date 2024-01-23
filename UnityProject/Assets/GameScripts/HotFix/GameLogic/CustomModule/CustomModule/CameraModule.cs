using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using TEngine;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace GameLogic
{
    public class CameraModule : Module
    {
        private Dictionary<int, CinemachineVirtualCamera> m_virtualCameraDict;
        public Camera _MainCamera;
        public int Count => m_virtualCameraDict.Count;

        protected override void Awake()
        {
            base.Awake();
            _MainCamera         = GetComponentInChildren<Camera>();
            m_virtualCameraDict = new Dictionary<int, CinemachineVirtualCamera>();
            _MainCamera.GetComponent<UniversalAdditionalCameraData>().cameraStack.Add(GameModule.UI.UICamera);
        }

        public void AddCameraStack(Camera camera)
        {
            _MainCamera.GetComponent<UniversalAdditionalCameraData>().cameraStack.Add(camera);
        }

        public void SetCameraSolo(int id)
        {
            m_virtualCameraDict[id].enabled = false;
            m_virtualCameraDict[id].enabled = true;
        }

        public void AddVirtualCamera(int id, CinemachineVirtualCamera virtualCamera)
        {
            m_virtualCameraDict[id] = virtualCamera;
        }
        public void RemoveVirtualCamera(int id)
        {
            m_virtualCameraDict.Remove(id);
        }
    }
}
