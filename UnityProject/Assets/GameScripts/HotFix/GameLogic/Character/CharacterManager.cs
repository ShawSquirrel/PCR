using System;
using System.Collections.Generic;
using TEngine;
using UnityEngine;

namespace GameLogic
{
    public class CharacterManager : MonoBehaviour
    {
        public List<Character> _AllCharacter = new List<Character>();
        public List<Character> _FriendlyCharacter = new List<Character>();
        public List<Character> _EnemyCharacter = new List<Character>();

        private void Awake()
        {
            LevelManager.Instance._CharacterManager = this;
        }

        public void AddFriendlyCharacter(Character character)
        {
            if (_FriendlyCharacter.Contains(character))
            {
                Log.Info("已存在");
                return;
            }

            _FriendlyCharacter.Add(character);
            _AllCharacter.Add(character);
        }

        public void AddEnemyCharacter(Character character)
        {
            if (_EnemyCharacter.Contains(character))
            {
                Log.Info("已存在");
                return;
            }

            _EnemyCharacter.Add(character);
            _AllCharacter.Add(character);
        }
    }
}