using UnityEngine;

namespace GameLogic.NewArchitecture.Game
{
    public static class PlayerPrefsUtils
    {
        public static string Tag = "PlayerPrefsUtils\t";

        public static void SetInt(string key, int value)
        {
            PlayerPrefs.SetInt(key, value);
            MLog.Debug(Tag + $"SetInt{key} : {value}");
        }

        public static void SetFloat(string key, float value)
        {
            PlayerPrefs.SetFloat(key, value);
            MLog.Debug(Tag + $"SetInt{key} : {value}");
        }

        public static void SetString(string key, string value)
        {
            PlayerPrefs.SetString(key, value);
            MLog.Debug(Tag + $"SetInt{key} : {value}");
        }

        public static int GetInt(string key, int defaultValue = 0)
        {
            return PlayerPrefs.GetInt(key, defaultValue);
        }

        public static float GetFloat(string key, float defaultValue = 0)
        {
            return PlayerPrefs.GetFloat(key, defaultValue);
        }

        public static string GetString(string key, string defaultValue = "")
        {
            return PlayerPrefs.GetString(key, defaultValue);
        }
    }
}