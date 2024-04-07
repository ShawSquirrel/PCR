using UnityEditor;

namespace Scenes.Debug.Editor
{
    public class LogEX
    {
        private const string Debug = "DEBUG_DEBUG";
        private const string Info = "DEBUG_INFO";
        private const string Warning = "DEBUG_WARNING";
        private const string Error = "DEBUG_ERROR";
        private const string Critical = "DEBUG_CRITICAL";

        private const string Dynamic = "DEBUG_DYNAMIC";

        [MenuItem("MLog/动态Log开关/开启动态调整Log等级")]
        private static void EnableLogDynamic()
        {
            AddOrRemoveSymbol(Dynamic, true);
        }

        [MenuItem("MLog/动态Log开关/关闭动态调整Log等级")]
        private static void DisableLogDynamic()
        {
            AddOrRemoveSymbol(Dynamic, false);
        }

        [MenuItem("MLog/Log等级/启动 Debug 等级")]
        private static void LogDebug()
        {
            AddOrRemoveSymbol(Debug, true);
            AddOrRemoveSymbol(Info, false);
            AddOrRemoveSymbol(Warning, false);
            AddOrRemoveSymbol(Error, false);
            AddOrRemoveSymbol(Critical, false);
        }


        [MenuItem("MLog/Log等级/启动 Info 等级")]
        private static void LogInfo()
        {
            AddOrRemoveSymbol(Debug, false);
            AddOrRemoveSymbol(Info, true);
            AddOrRemoveSymbol(Warning, false);
            AddOrRemoveSymbol(Error, false);
            AddOrRemoveSymbol(Critical, false);
        }


        [MenuItem("MLog/Log等级/启动 Warning 等级")]
        private static void LogWarning()
        {
            AddOrRemoveSymbol(Debug, false);
            AddOrRemoveSymbol(Info, false);
            AddOrRemoveSymbol(Warning, true);
            AddOrRemoveSymbol(Error, false);
            AddOrRemoveSymbol(Critical, false);
        }

        [MenuItem("MLog/Log等级/启动 Error 等级")]
        private static void LogError()
        {
            AddOrRemoveSymbol(Debug, false);
            AddOrRemoveSymbol(Info, false);
            AddOrRemoveSymbol(Warning, false);
            AddOrRemoveSymbol(Error, true);
            AddOrRemoveSymbol(Critical, false);
        }

        [MenuItem("MLog/Log等级/启动 Critical 等级")]
        private static void LogCritical()
        {
            AddOrRemoveSymbol(Debug, false);
            AddOrRemoveSymbol(Info, false);
            AddOrRemoveSymbol(Warning, false);
            AddOrRemoveSymbol(Error, false);
            AddOrRemoveSymbol(Critical, true);
        }

        [MenuItem("MLog/Log等级/关闭所有Log")]
        private static void NoLog()
        {
            AddOrRemoveSymbol(Debug, false);
            AddOrRemoveSymbol(Info, false);
            AddOrRemoveSymbol(Warning, false);
            AddOrRemoveSymbol(Error, false);
            AddOrRemoveSymbol(Critical, false);
        }

        /// <summary>
        /// 添加或移除宏定义
        /// </summary>
        /// <param name="symbol">需要添加的宏</param>
        /// <param name="add">是否是添加</param>
        private static void AddOrRemoveSymbol(string symbol, bool add)
        {
            BuildTargetGroup targetGroup = EditorUserBuildSettings.selectedBuildTargetGroup;
            string defines = PlayerSettings.GetScriptingDefineSymbolsForGroup(targetGroup);

            if (add)
            {
                if (!defines.Contains(symbol))
                {
                    defines = $"{defines};{symbol}";
                    PlayerSettings.SetScriptingDefineSymbolsForGroup(targetGroup, defines);
                }
            }
            else
            {
                defines = defines.Replace(symbol, string.Empty).Replace(";;", ";").Trim(';');
                PlayerSettings.SetScriptingDefineSymbolsForGroup(targetGroup, defines);
            }
        }
    }
}