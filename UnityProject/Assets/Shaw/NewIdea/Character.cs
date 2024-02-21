using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public Material _Mat_Character;

    private void Awake()
    {
        _Mat_Character = GetComponent<MeshRenderer>().material;
    }

    public void Select()
    {
        _Mat_Character.SetColor("_MainColor", Color.cyan);
    }
    public void NoSelect()
    {
        _Mat_Character.SetColor("_MainColor", Color.white);
    }

    // private void OnMouseDown()
    // {
    //     _Mat_Character.SetColor("_MainColor", Color.cyan);
    //     // Log.Info("OnMouseUp");
    // }


    // private void OnMouseExit()
    // {
    //     _Mat_Character.SetColor("_MainColor", Color.white);
    //     // Log.Info("OnMouseExit");
    // }
}
