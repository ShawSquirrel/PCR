using TEngine;
using UnityEngine;
using UnityEngine.Serialization;

namespace GameLogic
{
    public class ProcedureLoadLevel1 : CustomProcedureBase
    {
        public ProcedureLoadLevel1(FSM<EProcedure> fsm, CustomProcedureModule target) : base(fsm, target)
        {
        }

        protected override void OnEnter()
        {
            base.OnEnter();
            LoadMap();
            LoadCharacter();
            LoadCommandManager();
            LoadBattleManager();
            LoadLevel();
        }

        private void LoadBattleManager()
        {
            GameObject battleArea = GameModule.Resource.LoadAsset<GameObject>("BattleArea");
            battleArea.name = "BattleArea";
        }

        private void LoadCommandManager()
        {
            GameObject commandObj = new GameObject("Command");
            commandObj.AddComponent<CommandManager>();
        }

        private void LoadLevel()
        {
            LevelManager.Instance.Init();
        }

        private void LoadCharacter()
        {
            GameObject characterObj = new GameObject("Character");
            characterObj.AddComponent<CharacterManager>();

            LoadFriendly();
            LoadEnemy();
        }

        private void LoadFriendly()
        {
            GameObject player = GameModule.Resource.LoadAsset<GameObject>("优衣");
            Character character = player.AddComponent<Character>();
            character.name = "优衣1";
            LevelManager.Instance._CharacterManager.AddFriendlyCharacter(character);
            LevelManager.Instance._MapManager.SetCharacterPos(character, new Vector2Int(1,1), true);
        }

        private void LoadEnemy()
        {
            GameObject player = GameModule.Resource.LoadAsset<GameObject>("优衣");
            Character character = player.AddComponent<Character>();
            character.name = "优衣2";
            LevelManager.Instance._CharacterManager.AddEnemyCharacter(character);
            LevelManager.Instance._MapManager.SetCharacterPos(character, new Vector2Int(2,1), true);
        }

        private void LoadMap()
        {
            TextAsset textAsset = GameModule.Resource.LoadAsset<TextAsset>("Map");
            MapData mapData = DealText(textAsset.text);
            

            GameObject mapObj = new GameObject("Map");
            MapManager map = mapObj.AddComponent<MapManager>();
            map.Init(mapData);


            GameObject aStarObj = new GameObject("AStar");
            AStarManager aStar = aStarObj.AddComponent<AStarManager>();
            aStar.Init(mapData);
        }

        private MapData DealText(string mapText)
        {
            string text = mapText;
            string[] mapRow = text.Trim('\n').Split('\n');
            string[] mapCol = mapRow[0].Trim('\t').Split('\t');
            int x = mapRow.Length;
            int y = mapCol.Length;

            int[,] mapList = new int[x, y];

            for (int i = 0; i < x; i++)
            {
                mapCol = mapRow[i].Trim('\t').Split('\t');
                for (int ii = 0; ii < y; ii++)
                {
                    mapList[ii, i] = int.Parse(mapCol[ii]);
                }
            }

            return new MapData
                   {
                       _MapList = mapList,
                       _Width   = x,
                       _Length  = y
                   };
        }
    }
}

public struct MapData
{
    public int[,] _MapList;
    public int _Width;
    public int _Length;
}