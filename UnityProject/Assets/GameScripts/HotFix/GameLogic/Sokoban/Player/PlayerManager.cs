using TEngine;
using UnityEngine;
using UnityEngine.Rendering;

namespace GameLogic.Sokoban
{
    public class PlayerManager : GameBase.Manager
    {
        public Transform PlayRoot { get; private set; }
        public Vector3 Pos { get; private set; }
        public GameObject Character { get; private set; }

        public override void Awake()
        {
            base.Awake();
            PlayRoot = new GameObject("PlayRoot").transform;
            PlayRoot.SetParent(_Obj.transform);
        }

        public void LoadCharacter(string characterName)
        {
            GameObject character = GameModule.Resource.LoadAsset<GameObject>(characterName);
            character.name = characterName;
            character.transform.SetParent(PlayRoot);
            character.AddComponent<SortingGroup>().sortingLayerName = "Player";

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
    }
}