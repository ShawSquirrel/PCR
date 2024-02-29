using System.Collections.Generic;
using UnityEngine;

namespace GameLogic
{
    
    public class Manager : MonoBehaviour
    {
        
    }

    public class CharacterManager : Manager
    {
        private Dictionary<Vector2Int, Character> _dict_Character;

        private void Awake()
        {
            InitName();
            _dict_Character = new Dictionary<Vector2Int, Character>();
        }

        private void InitName()
        {
            name = "CharacterManager";
        }


        public void AddCharacter(Character character, Vector2Int pos)
        {
            _dict_Character.Add(pos, character);
        }
    }
}