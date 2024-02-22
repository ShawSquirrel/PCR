using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public CharacterData CharacterData;
    
    public Material _Mat_Character;

    public BindableProperty<int> _Hp = new BindableProperty<int>();
    public int atk;
    private static readonly int MainColor = Shader.PropertyToID("_MainColor");

    private void Start()
    {
        _Mat_Character = GetComponent<MeshRenderer>().material;

        //MapItem mapItem= MapController._Instance.map
        //MapController._Instance.MapItemToCharacter[]

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
