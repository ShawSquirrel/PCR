using System;
using GameLogic;
using TEngine;
using UnityEngine;

public class CustomModule : MonoBehaviour
{
    private static CameraModule m_cameraModule;

    public static CameraModule CameraModule
    {
        get
        {
            if (m_cameraModule == null)
            {
                m_cameraModule = GameModule.Get<CameraModule>();
            }

            return m_cameraModule;
        }
    }
    private static CustomProcedureModule m_procedureModule;

    public static CustomProcedureModule CustomProcedureModule
    {
        get
        {
            if (m_procedureModule == null)
            {
                m_procedureModule = GameModule.Get<CustomProcedureModule>();
            }

            return m_procedureModule;
        }
    }

    private static VideoModule m_videoModule;

    public static VideoModule VideoModule
    {
        get
        {
            if (m_videoModule == null)
            {
                m_videoModule = GameModule.Get<VideoModule>();
            }

            return m_videoModule;
        }
    }

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

}