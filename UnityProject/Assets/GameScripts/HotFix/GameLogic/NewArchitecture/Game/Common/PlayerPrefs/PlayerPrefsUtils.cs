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
    }
}