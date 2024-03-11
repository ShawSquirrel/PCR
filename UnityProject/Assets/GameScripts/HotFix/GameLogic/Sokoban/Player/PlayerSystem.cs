using DG.Tweening;
using TEngine;
using UnityEngine;
using UnityEngine.Rendering;

namespace GameLogic.Sokoban
{
    public class PlayerSystem : GameBase.System
    {
        public Transform PlayRoot { get; private set; }
        public Vector3 Pos { get; private set; }
        public GameObject Character { get; private set; }

        // public bool IsMoving;

        public override void Awake()
        {
            base.Awake();
            PlayRoot = new GameObject("PlayRoot").transform;
            PlayRoot.SetParent(_Obj.transform);
        }

        public void LoadCharacter(string characterName, float offset = 0f)
        {
            GameObject character = GameModule.Resource.LoadAsset<GameObject>(characterName);
            character.name = characterName;
            character.transform.SetParent(PlayRoot);
            character.AddComponent<SortingGroup>().sortingLayerName = "Player";
            character.transform.Find("Body").position               = Vector3.zero + new Vector3(0, offset);
            
            Character = character;
        }

        public void OnReset()
        {
            GameObject.Destroy(Character);
            Character = null;
        }

        public void SetPos(Vector2Int pos)
        {
            Pos = new Vector3(pos.x, pos.y);
            Character.transform.position = Pos;
        }
        public void SetPos(Vector2Int pos, float time)
        {
            // IsMoving = true;
            
            Pos = new Vector3(pos.x, pos.y);
            Character.transform.position = Pos;
            // Character.transform.DOMove(Pos, time).OnComplete(() => IsMoving = false);
        }
    }
}