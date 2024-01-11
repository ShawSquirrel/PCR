using System;
using UnityEditor;

public class SpinePostprocessor : AssetPostprocessor
{
    private const string _Path = "Assets/AssetRaw/Spine";
    private void OnPreprocessAsset()
    {
        if (!assetPath.StartsWith(_Path))
        {
            return;
        }
        
        
    }
}
