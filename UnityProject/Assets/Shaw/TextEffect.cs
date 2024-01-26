using System;
using DG.Tweening;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;

public class TextEffect : MonoBehaviour
{
    public TextMeshPro _Text;

    public float _LastTime;

    private void Awake()
    {
        _LastTime = Time.time;
    }
}
