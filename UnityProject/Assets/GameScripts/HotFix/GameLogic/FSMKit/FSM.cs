using System;
using System.Collections.Generic;

namespace TEngine
{
    public class FSM<T>
    {
        protected Dictionary<T, IState> mStates = new Dictionary<T, IState>();

        public void AddState(T id, IState state)
        {
            mStates.Add(id, state);
        }


        public CustomState State(T t)
        {
            if (mStates.ContainsKey(t))
            {
                return mStates[t] as CustomState;
            }

            var state = new CustomState();
            mStates.Add(t, state);
            return state;
        }

        private IState mCurrentState;
        private T mCurrentStateId;

        public IState CurrentState => mCurrentState;
        public T CurrentStateId => mCurrentStateId;
        public T PreviousStateId { get; private set; }

        public long FrameCountOfCurrentState = 1;

        public void ChangeState(T t)
        {
            if (t.Equals(CurrentStateId)) return;

            if (mStates.TryGetValue(t, out var state))
            {
                if (mCurrentState != null && state.Condition())
                {
                    mCurrentState.Exit();
                    PreviousStateId = mCurrentStateId;
                    mCurrentState   = state;
                    mCurrentStateId = t;
                    mOnStateChanged?.Invoke(PreviousStateId, CurrentStateId);
                    FrameCountOfCurrentState = 1;
                    mCurrentState.Enter();
                }
            }
        }

        private Action<T, T> mOnStateChanged = (_, __) => { };

        public void OnStateChanged(Action<T, T> onStateChanged)
        {
            mOnStateChanged += onStateChanged;
        }

        public void StartState(T t)
        {
            if (mCurrentState != null) mCurrentState.Exit();
            if (mStates.TryGetValue(t, out var state))
            {
                PreviousStateId          = t;
                mCurrentState            = state;
                mCurrentStateId          = t;
                FrameCountOfCurrentState = 0;
                state.Enter();
            }
        }
        public void ExitState()
        {
            if (mCurrentState != null) mCurrentState.Exit();
            PreviousStateId = mCurrentStateId;
            mCurrentState = null;
            mCurrentStateId = default;
        }

        public void FixedUpdate()
        {
            mCurrentState?.FixedUpdate();
        }

        public void Update()
        {
            mCurrentState?.Update();
            FrameCountOfCurrentState++;
        }

        public void OnGUI()
        {
            mCurrentState?.OnGUI();
        }

        public void Clear()
        {
            if (mCurrentState != null) mCurrentState.Exit();
            mCurrentState   = null;
            mCurrentStateId = default;
            mStates.Clear();
        }
        
    }
}