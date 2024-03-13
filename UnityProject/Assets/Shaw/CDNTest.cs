using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class CDNTest : MonoBehaviour
{
    public RawImage _RawImage;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        string url = @"https://a.unity.cn/client_api/v1/buckets/184731bb-9475-48ea-9939-300be938187d/content/Slice 2.png";

        UnityWebRequest request = UnityWebRequestTexture.GetTexture(url);
        yield return request.SendWebRequest();

        if (request.isNetworkError || request.isHttpError)
        {
            Debug.Log(request.error);
            yield break;
        }
        Texture2D texture = DownloadHandlerTexture.GetContent(request);

        //把贴图赋到RawImage
        _RawImage.texture = texture;
        Debug.Log(request.result);
    }

    // Update is called once per frame
    void Update()
    {
    }
}