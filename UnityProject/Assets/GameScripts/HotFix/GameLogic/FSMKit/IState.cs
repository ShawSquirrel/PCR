/****************************************************************************
 * Copyright (c) 2016 - 2022 liangxiegame UNDER MIT License
 *
 * https://qframework.cn
 * https://github.com/liangxiegame/QFramework
 * https://gitee.com/liangxiegame/QFramework
 ****************************************************************************/

using System;
using System.Collections.Generic;

namespace TEngine
{
    public interface IState
    {
        bool Condition();
        void Enter();
        void Update();
        void FixedUpdate();

        void OnGUI();
        void Exit();
    }
}