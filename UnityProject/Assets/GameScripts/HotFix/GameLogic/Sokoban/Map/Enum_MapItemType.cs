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
        
        
        Null = 99
    }
/*
switch (_type)
{
     case (Enum_MaptemType)0: // 空
         break;
     case (Enum_MaptemType)1: // 墙
         break;
     case (Enum_MaptemType)2: // 空地
         break;
     case (Enum_MaptemType)4: // 目标位置
         break;
     case (Enum_MaptemType)10: // 箱子 | 空地
         break;
     case (Enum_MaptemType)12: // 箱子 | 目标位置
         break;
     case (Enum_MaptemType)18: // 玩家 | 空地
         break;
     case (Enum_MaptemType)20: // 玩家 | 目标位置
         break;
}
*/
    
}