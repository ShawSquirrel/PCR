using System;
using System.Collections;
using System.Collections.Generic;
using TEngine;
using UnityEngine;
using UnityEngine.EventSystems;

public class MapItem : MonoBehaviour
{
    public Material _Mat_Item;

    private void Awake()
    {
        _Mat_Item = GetComponent<MeshRenderer>().material;
    }

    private void OnMouseEnter()
    {
        _Mat_Item.SetColor("_MainColor", Color.cyan);
        // Log.Info("OnMouseUp");
    }


    private void OnMouseExit()
    {
        _Mat_Item.SetColor("_MainColor", Color.white);
        // Log.Info("OnMouseExit");
    }
}