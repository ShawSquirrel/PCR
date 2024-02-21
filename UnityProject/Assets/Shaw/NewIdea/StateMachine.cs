using System;
using TEngine;
using UnityEngine;

public enum State
{
    NoSelected,
    Selected,
}

public class StateMachine : MonoBehaviour
{
    public static StateMachine _Instance;
    public FSM<State> _FSM = new FSM<State>();


    public Action<GameObject> ClickMapItem;
    public Action<GameObject> ClickCharacter;
    public Action ClickNull;


    public Character Character;
    public GameObject Effect;

    private void Awake()
    {
        _Instance = this;
        _FSM.AddState(State.NoSelected, new State_NoSelected(_FSM, this));
        _FSM.AddState(State.Selected, new State_Selected(_FSM, this));

        _FSM.StartState(State.NoSelected);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                GameObject obj = hit.collider.gameObject;
                Log.Info($"点击的物体 {obj.name}");
                if (obj.tag.Contains("Character"))
                {
                    ClickCharacter?.Invoke(obj);
                }
                else if (obj.tag.Contains("MapItem"))
                {
                    ClickMapItem?.Invoke(obj);
                }
                else
                {
                    ClickNull?.Invoke();
                }
            }

            else
            {
                ClickNull?.Invoke();
            }
        }
    }

    public class GameState : AbstractState<State, StateMachine>
    {
        public GameState(FSM<State> fsm, StateMachine target) : base(fsm, target)
        {
        }

        protected virtual void OnClickNull()
        {
            mTarget.Character.NoSelect();
            mFSM.ChangeState(State.NoSelected);
        }

        protected virtual void OnClickCharacter(GameObject obj)
        {
            mTarget.Character.Select();
            mFSM.ChangeState(State.Selected);
        }

        protected virtual void OnClickMapItem(GameObject obj)
        {
            GameObject effect = Instantiate(mTarget.Effect);
            effect.SetActive(true);
            effect.transform.position = obj.transform.position + new Vector3(0, 1f, 0);
        }
    }

    public class State_NoSelected : GameState
    {
        public State_NoSelected(FSM<State> fsm, StateMachine target) : base(fsm, target)
        {
        }

        protected override void OnEnter()
        {
            base.OnEnter();

            mTarget.ClickCharacter += OnClickCharacter;
        }

        protected override void OnExit()
        {
            base.OnExit();
            mTarget.ClickCharacter -= OnClickCharacter;
        }
    }

    public class State_Selected : GameState
    {
        public State_Selected(FSM<State> fsm, StateMachine target) : base(fsm, target)
        {
        }

        protected override void OnEnter()
        {
            base.OnEnter();
            mTarget.ClickNull += OnClickNull;
            mTarget.ClickMapItem += OnClickMapItem;
        }

        protected override void OnExit()
        {
            base.OnExit();
            mTarget.ClickNull -= OnClickNull;
            mTarget.ClickMapItem -= OnClickMapItem;
        }
    }
}