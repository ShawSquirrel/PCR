using System.Collections.Generic;
using TEngine;
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
    private GameObject _Owner;
    private GameObject _GO;
    private Enum_SkillState _enumSkillState;

    public Skill(Enum_SkillState skillState)
    {
        _enumSkillState = skillState;

        LoadEffect();
    }


    public void LoadEffect()
    {
        if (_GO != null) return;
        switch (_enumSkillState)
        {
            case Enum_SkillState.Skill1:
                _GO = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Shaw/Assets/Effect1.prefab");
                break;
            case Enum_SkillState.Skill2:
                _GO = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Shaw/Assets/Effect2.prefab");
                break;
            case Enum_SkillState.Skill3:
                _GO = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Shaw/Assets/Effect3.prefab");
                break;
        }

    }

    public void SetPos(MapItem mapItem)
    {
        if (_GO == null)
        {
            return;
        }

        List<MapItem> allMapItem = new List<MapItem>()
        {
            MapController._Instance.GetTargetUpMapItem(mapItem),
            MapController._Instance.GetTargetLeftMapItem(mapItem),
            // MapController._Instance.GetTargetUpMapItem(mapItem),
            // MapController._Instance.GetTargetUpMapItem(mapItem),
        };
        
        foreach (MapItem item in allMapItem)
        {
            InstantiateEffect(item);
        }
    }

    private void InstantiateEffect(MapItem targetMapItem)
    {
        if (targetMapItem == null) return;
        GameObject effectObj = Object.Instantiate(_GO);
        effectObj.transform.position = targetMapItem.transform.position + new Vector3(0, 1, 0);
        effectObj.GetComponent<Effect>().AddListen(OnDestroy);
    }

    private void OnDestroy()
    {
        FSM<State> fsm = StateMachine._Instance._FSM;
        if (fsm.CurrentStateId == State.Action)
        {
            ((StateMachine.State_Action)fsm.CurrentState).isComplele = true;
        }
    }
}