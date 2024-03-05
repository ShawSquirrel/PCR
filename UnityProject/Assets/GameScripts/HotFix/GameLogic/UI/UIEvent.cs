using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameLogic
{
    public class UIEvent
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

    public class MapItemEvent
    {
        public const int MouseEnterEventID = 20000; //鼠标进入
        public const int MouseOverEventID = 20001;  //鼠标在上方
        public const int MouseDownEventID = 20002;  //鼠标按下
        public const int MouseExitEventID = 20003;  //鼠标退出
    }

    public class SokobanEvent
    {
        public const int Sokoban_MakeMapClickItem = 30001; //推箱子制作地图
    }

    public class SurvivorEvent
    {
        public const int Survivor_StartGame = 40001;        //开始幸存者游戏
        public const int Survivor_BeginDragStick = 40002;   //开始拖拽摇杆
        public const int Survivor_DragStick = 40003;        //拖拽摇杆
        public const int Survivor_EndDragStick = 40004;     //结束拖拽摇杆
        public const int Survivor_UIBeginDragStick = 40005; //开始拖拽摇杆
        public const int Survivor_UIDragStick = 40006;      //拖拽摇杆
        public const int Survivor_UIEndDragStick = 40007;   //结束拖拽摇杆
    }
}