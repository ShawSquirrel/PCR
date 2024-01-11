using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using TEngine;
using UnityEngine;

namespace GameLogic
{
    public class CameraModule : Module
    {
        private Dictionary<int, CinemachineVirtualCamera> m_virtualCameraDict;
        public int Count => m_virtualCameraDict.Count;

        protected override void Awake()
        {
            base.Awake();
            m_virtualCameraDict = new Dictionary<int, CinemachineVirtualCamera>();
            
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
