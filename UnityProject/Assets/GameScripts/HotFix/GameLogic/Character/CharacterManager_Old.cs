using System;
using System.Collections.Generic;
using TEngine;
using UnityEngine;

namespace GameLogic
{
    public class CharacterManager_Old : Entity
    {
        public List<Character_Old> _AllCharacter = new List<Character_Old>();
        public List<Character_Old> _FriendlyCharacter = new List<Character_Old>();
        public List<Character_Old> _EnemyCharacter = new List<Character_Old>();
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

        public void AddFriendlyCharacter(Character_Old characterOld)
        {
            if (_FriendlyCharacter.Contains(characterOld))
            {
                Log.Info("已存在");
                return;
            }

            _FriendlyCharacter.Add(characterOld);
            _AllCharacter.Add(characterOld);
            
            characterOld._TF.SetParent(_FriendlyRoot);
        }

        public void AddEnemyCharacter(Character_Old characterOld)
        {
            if (_EnemyCharacter.Contains(characterOld))
            {
                Log.Info("已存在");
                return;
            }

            _EnemyCharacter.Add(characterOld);
            _AllCharacter.Add(characterOld);
            
            characterOld._TF.SetParent(_EnemyRoot);
        }
    }
}