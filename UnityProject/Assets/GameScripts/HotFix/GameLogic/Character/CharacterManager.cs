using System.Collections.Generic;
using UnityEngine;

namespace GameLogic
{
    public class CharacterManager : MonoBehaviour
    {
        private Dictionary<string, Character> _dict_Character;
        private void Awake()
        {
            InitName();
            _dict_Character = new Dictionary<string, Character>();
        }

        private void InitName()
        {
            name = "CharacterManager";
        }
    }
}