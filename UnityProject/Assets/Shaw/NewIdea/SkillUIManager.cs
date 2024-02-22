using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SkillUIManager : MonoBehaviour
{
    public static SkillUIManager _Instance;
    public List<Toggle> _ToggleList = new List<Toggle>();

    public Action<int> OnSelectSkillEvent;
    public int Type_Skill = 1;
    
    private void Awake()
    {
        _Instance = this;
        foreach (Toggle toggle in _ToggleList)
        {
            toggle.onValueChanged.AddListener((isOn) => OnSkillValueChanged(toggle, isOn));
        }
    }


    private void OnSkillValueChanged(Toggle toggle, bool isOn)
    {
        if (isOn)
        {
            switch (toggle.name)
            {
                case "1":
                    OnSelectSkillEvent?.Invoke(1);
                    Type_Skill = 1;
                    break;
                case "2":
                    OnSelectSkillEvent?.Invoke(2);
                    Type_Skill = 2;
                    break;
                case "3":
                    OnSelectSkillEvent?.Invoke(3);
                    Type_Skill = 3;
                    break;
                default:
                    break;
            }
        }
    }
}