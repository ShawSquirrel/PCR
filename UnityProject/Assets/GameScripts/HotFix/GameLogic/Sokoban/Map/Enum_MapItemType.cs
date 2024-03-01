using System;

namespace GameLogic.Sokoban
{
    [Flags]
    public enum Enum_MaptemType
    {
        Empty = 0,       // 空
        Wall = 1 << 0,   // 墙
        Ground = 1 << 1, // 空地
        Target = 1 << 2, // 目标位置
        Box = 1 << 3,    // 箱子
        Player = 1 << 4, // 玩家
    }
/*
switch (_Dict_Map[newPos]._Type)
{
    case (Enum_Sokoban)0: // 空
        break;
    case (Enum_Sokoban)1: // 墙
        break;
    case (Enum_Sokoban)2: // 空地
        break;
    case (Enum_Sokoban)4: // 目标位置
        break;
    case (Enum_Sokoban)10: // 箱子 | 空地
        break;
    case (Enum_Sokoban)12: // 箱子 | 目标位置
        break;
    case (Enum_Sokoban)18: // 玩家 | 空地
        break;
    case (Enum_Sokoban)20: // 玩家 | 目标位置
        break;
}
*/
    
}