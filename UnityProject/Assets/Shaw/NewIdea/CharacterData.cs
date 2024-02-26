using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Enum_LeftOrRight
{
    Left,
    Right
}

[CreateAssetMenu(fileName = "CharacterData", menuName = "ScriptableObjects/Character", order = 1)]
public class CharacterData : ScriptableObject
{
    public int _Hp;
    public int _Atk;

    public Vector2Int _Pos;
    public Enum_LeftOrRight _LeftOrRight;
}