using System.Collections.Generic;
using UnityEngine;

namespace GameLogic
{
    public class Class_CharacterData
    {
        public string _Str_CharacterName;
    }

    public class Manager : MonoBehaviour
    {
        
    }

    public class CharacterManager : Manager
    {
        private Dictionary<string, Class_CharacterData> _dict_Character;

        private void Awake()
        {
            InitName();
            _dict_Character = new Dictionary<string, Class_CharacterData>();
        }

        private void InitName()
        {
            name = "CharacterManager";
        }


        public void AddCharacter(Class_CharacterData characterData)
        {
            _dict_Character.Add(characterData._Str_CharacterName, characterData);
            
            
        }
    }
}