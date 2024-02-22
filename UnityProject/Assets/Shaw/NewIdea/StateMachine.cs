using System;
using System.Collections.Generic;
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


    public Action<MapItem> ClickMapItem;
    public Action<Character> ClickCharacter;
    public Action ClickNull;


    public MapItem[,] LeftMap = new MapItem[3, 3];
    public MapItem[,] RightMap = new MapItem[3, 3];

    public Character Character;
    // public GameObject Effect;

    public LayerMask _LayerMask;

    private void Awake()
    {
        _Instance = this;
        _FSM.AddState(State.NoSelected, new State_NoSelected(_FSM, this));
        _FSM.AddState(State.Selected, new State_Selected(_FSM, this));

        _FSM.StartState(State.NoSelected);
    }

    protected virtual void SelectCharacter(Character character)
    {
        if (Character != null)
        {
            Character.NoSelect();
        }

        Character = character;
        Character.Select();
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, _LayerMask))
            {
                GameObject obj = hit.collider.gameObject;
                Log.Info($"点击的物体 {obj.name}");
                if (obj.CompareTag("Character"))
                {
                    ClickCharacter?.Invoke(obj.GetComponent<Character>());
                }
                else if (obj.CompareTag("MapItem"))
                {
                    ClickMapItem?.Invoke(obj.GetComponent<MapItem>());
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
            mTarget.Character = null;
            mFSM.ChangeState(State.NoSelected);
        }

        protected virtual void OnClickCharacter(Character character)
        {
            mTarget.SelectCharacter(character);
            mFSM.ChangeState(State.Selected);
        }

        protected virtual void OnClickMapItem(MapItem mapItem)
        {
            if (mapItem.gameObject.layer != mTarget.Character.gameObject.layer)
            {
                Skill skill = new Skill(Enum_SkillState.Skill1);
                skill.SetPos(mapItem);
            }
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