using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

public enum Enum_SkillState
{
    Skill1,
    Skill2,
    Skill3
}

public class Skill
{
    private GameObject _GO;
    private Enum_SkillState _enumSkillState;

    public Skill(Enum_SkillState skillState)
    {
        _enumSkillState = skillState;
    }

    public void LoadEffect()
    {
        if (_GO != null) return;
        switch (_enumSkillState)
        {
            case Enum_SkillState.Skill1:
                _GO = Object.Instantiate(AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Shaw/Assets/Effect1.prefab"));
                break;
            case Enum_SkillState.Skill2:
                _GO = Object.Instantiate(AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Shaw/Assets/Effect2.prefab"));
                break;
            case Enum_SkillState.Skill3:
                _GO = Object.Instantiate(AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Shaw/Assets/Effect3.prefab"));
                break;
        }
    }

    public void SetPos(MapItem mapItem)
    {
        LoadEffect();
        if (_GO == null)
        {
            return;
        }

        _GO.transform.position = mapItem.transform.position + new Vector3(0, 1, 0);
    }
}