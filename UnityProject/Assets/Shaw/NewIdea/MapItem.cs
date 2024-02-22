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
        StateMachine._Instance.MapItemMouseEnterEvent?.Invoke(this);
    }

    private void OnMouseOver()
    {
        StateMachine._Instance.MapItemMouseOverEvent?.Invoke(this);
    }

    private void OnMouseDown()
    {
        StateMachine._Instance.MapItemMouseDownEvent?.Invoke(this);
    }

    private void OnMouseExit()
    {
        StateMachine._Instance.MapItemMouseExitEvent?.Invoke(this);
    }
}