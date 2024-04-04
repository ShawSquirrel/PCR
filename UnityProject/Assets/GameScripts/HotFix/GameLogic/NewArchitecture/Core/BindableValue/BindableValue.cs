using System;

namespace GameLogic.NewArchitecture.Core.BindableValue
{
    /// <summary>
    /// 回调值
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BindableValue<T>
    {
        private Action<T> _action;
        private T _value;

        public T Value
        {
            get => _value;
            set
            {
                if (value.Equals(_value) == true) return;
                _value = value;
                _action?.Invoke(_value);
            }
        }

        public void AddListen(Action<T> action)
        {
            _action += action;
        }

        public void RemoveListen(Action<T> action)
        {
            _action -= action;
        }

        public void RemoveAllListen()
        {
            _action = null;
        }

        public void SetValue(T t)
        {
            Value = t;
        }

        public void SetValueWithoutCallback(T t)
        {
            _value = t;
        }
    }
}