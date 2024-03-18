using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameLogic
{
    public class UIEventID
    {
        public const int StartGameEventID = 10000;          //开始游戏
        public const int CharacterActionEventID = 10001;    //人物回合开始
        public const int Sokoban_StartGame = 10002;         //开始推箱子
        public const int Sokoban_SelectLevel = 10003;       //选中关卡
        public const int Sokoban_Success = 10004;           //推箱子胜利
        public const int Sokoban_Menu = 10005;              //推箱子菜单
        public const int Sokoban_Restart = 10006;           //推箱子重玩
        public const int Sokoban_NextLevel = 10007;         //推箱子下一关
        public const int Sokoban_MakeMap = 10008;           //推箱子制作地图
        public const int Sokoban_MakeMapSelectType = 10009; //推箱子制作地图
        public const int Sokoban_MakeMapSave = 10010;       //推箱子制作地图
        public const int Sokoban_MakeMapClose = 10011;      //推箱子制作地图
        public const int Sokoban_MakeMapRevert = 10012;     //推箱子制作地图
        public const int Sokoban_Move = 10013;              //推箱子制作地图
        public const int PlayVideo = 10014;
        public const int PauseVideo = 10015;
    }

    public class SokobanEvent
    {
        public const int Sokoban_MakeMapClickItem = 30001; //推箱子制作地图
    }

}