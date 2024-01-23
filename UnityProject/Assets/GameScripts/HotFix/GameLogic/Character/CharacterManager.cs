using System;
using System.Collections.Generic;
using TEngine;
using UnityEngine;

namespace GameLogic
{
    public class CharacterManager : Entity
    {
        public List<Character> _AllCharacter = new List<Character>();
        public List<Character> _FriendlyCharacter = new List<Character>();
        public List<Character> _EnemyCharacter = new List<Character>();
        public Transform _FriendlyRoot;
        public Transform _EnemyRoot;

        protected virtual void Awake()
        {
            base.Awake();
            LevelManager.Instance._CharacterManager = this;
            _TF.SetParent(LevelManager.Instance._Root);
            
            _FriendlyRoot = new GameObject("FriendlyRoot").transform;
            _FriendlyRoot.SetParent(_TF);
            _EnemyRoot    = new GameObject("EnemyRoot").transform;
            _EnemyRoot.SetParent(_TF);
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
            
            character._TF.SetParent(_FriendlyRoot);
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
            
            character._TF.SetParent(_EnemyRoot);
        }
    }
}