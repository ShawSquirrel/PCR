using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Character : MonoBehaviour
{
    public CharacterData _CharacterData;

    public Material _Mat_Character;

    public BindableProperty<int> _Hp = new BindableProperty<int>();
    public int _Atk;
    private static readonly int MainColor = Shader.PropertyToID("_MainColor");

    private void Start()
    {
        _Mat_Character = GetComponent<MeshRenderer>().material;
        _Hp.SetValueWithoutEvent(_CharacterData._Hp);
        _Atk = _CharacterData._Atk;
        MapItem mapItem = null;
        switch (_CharacterData._LeftOrRight)
        {
            case Enum_LeftOrRight.Left:
                mapItem = MapController._Instance.LeftMap[_CharacterData._Pos.x, _CharacterData._Pos.y];
                break;
            case Enum_LeftOrRight.Right:
                mapItem = MapController._Instance.RightMap[_CharacterData._Pos.x, _CharacterData._Pos.y];
                break;
        }

        if (mapItem != null) MapController._Instance.MapItemToCharacter[mapItem] = this;

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

    private void OnMouseEnter()
    {
        StateMachine._Instance.CharacterMouseEnterEvent?.Invoke(this);
    }

    private void OnMouseOver()
    {
        StateMachine._Instance.CharacterMouseOverEvent?.Invoke(this);
    }

    private void OnMouseDown()
    {
        StateMachine._Instance.CharacterMouseDownEvent?.Invoke(this);
    }

    private void OnMouseExit()
    {
        StateMachine._Instance.CharacterMouseExitEvent?.Invoke(this);
    }
}