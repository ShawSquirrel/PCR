using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterData", menuName = "ScriptableObjects/Character", order = 1)]
public class CharacterData : ScriptableObject
{
    public int _Hp;
    public int _Atk;
}