namespace GameLogic.Survivor
{
    public class EventID_Survivor
    {
        public const int Survivor_UIBeginDragStick = 45001; //开始拖拽摇杆
        public const int Survivor_UIDragStick = 45002;      //拖拽摇杆
        public const int Survivor_UIEndDragStick = 45003;   //结束拖拽摇杆


        public const int Survivor_StartGame = 40001;      //开始幸存者游戏
        public const int Survivor_BeginDragStick = 40002; //开始拖拽摇杆
        public const int Survivor_DragStick = 40003;      //拖拽摇杆
        public const int Survivor_EndDragStick = 40004;   //结束拖拽摇杆
        public const int Survivor_Move = 40005;           //角色移动
        public const int Survivor_MoveStop = 40006;       //角色停止移动

        public const int Survivor_Damage = 40007;  // 角色受击
        public const int Survivor_Release = 40008; // 释放资源
        public const int Survivor_Die = 40009; // 角色死亡
    }
}