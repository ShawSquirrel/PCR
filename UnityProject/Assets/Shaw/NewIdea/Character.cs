using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public Material _Mat_Character;

    public BindableProperty<int> _Hp;
    public int atk;
    private static readonly int MainColor = Shader.PropertyToID("_MainColor");

    private void Awake()
    {
        _Mat_Character = GetComponent<MeshRenderer>().material;


        _Hp.Register((i) =>
        {
            if (i < 0)
            {
                Destroy(this.gameObject);
            }
        });
    }

    public void Select()
    {
        _Mat_Character.SetColor(MainColor, Color.cyan);
    }
    public void NoSelect()
    {
        _Mat_Character.SetColor(MainColor, Color.white);
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
