using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameLogic
{
    public class UIEvent
    {
        public const int StartGameEventID = 10000;       //开始游戏
        public const int CharacterActionEventID = 10001; //人物回合开始
    }

    public class MapItemEvent
    {
        public const int MouseEnterEventID = 20000; //鼠标进入
        public const int MouseOverEventID = 20001;  //鼠标在上方
        public const int MouseDownEventID = 20002;  //鼠标按下
        public const int MouseExitEventID = 20003;  //鼠标退出
    }
}