using System;
using System.Collections.Generic;
using TEngine;
using UnityEngine;
using UnityEngine.EventSystems;

public enum State
{
    NoSelected,
    Selected,
    Action,
}

public class StateMachine : MonoBehaviour
{
    public static StateMachine _Instance;
    public FSM<State> _FSM = new FSM<State>();


    // public Action<MapItem> ClickMapItem;
    // public Action<Character> ClickCharacter;
    public Action NullMouseDown;

    public Action<MapItem> MapItemMouseEnterEvent;
    public Action<MapItem> MapItemMouseOverEvent;
    public Action<MapItem> MapItemMouseDownEvent;
    public Action<MapItem> MapItemMouseExitEvent;

    public Action<Character> CharacterMouseEnterEvent;
    public Action<Character> CharacterMouseOverEvent;
    public Action<Character> CharacterMouseDownEvent;
    public Action<Character> CharacterMouseExitEvent;


    public Character Character;

    public LayerMask _LayerMask;

    private void Awake()
    {
        _Instance = this;
        _FSM.AddState(State.NoSelected, new State_NoSelected(_FSM, this));
        _FSM.AddState(State.Selected, new State_Selected(_FSM, this));
        _FSM.AddState(State.Action, new State_Action(_FSM, this));

        _FSM.StartState(State.NoSelected);
    }

    public virtual void SelectCharacter(Character character)
    {
        if (Character != null)
        {
            Character.NoSelect();
        }

        Character = character;
        Character.Select();
    }

    public virtual void ResetCharacter()
    {
        if (Character != null)
        {
            Character.NoSelect();
        }

        Character = null;
    }


    private void Update()
    {
        _FSM.Update();
        if (Input.GetMouseButtonDown(0))
        {
            if (EventSystem.current.IsPointerOverGameObject()) return;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, _LayerMask))
            {
                // GameObject obj = hit.collider.gameObject;
                // Log.Info($"点击的物体 {obj.name}");
                // if (obj.CompareTag("Character"))
                // {
                //     ClickCharacter?.Invoke(obj.GetComponent<Character>());
                // }
                // else if (obj.CompareTag("MapItem"))
                // {
                //     ClickMapItem?.Invoke(obj.GetComponent<MapItem>());
                // }
                // else
                // {
                //     ClickNull?.Invoke();
                // }
            }

            else
            {
                NullMouseDown?.Invoke();
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
                Skill skill = new Skill(OnSelectSkill(SkillUIManager._Instance.Type_Skill));
                skill.SetPos(mapItem);
                mFSM.ChangeState(State.Action);
            }
        }

        private Enum_SkillState OnSelectSkill(int obj)
        {
            return obj switch
            {
                1 => Enum_SkillState.Skill1,
                2 => Enum_SkillState.Skill2,
                3 => Enum_SkillState.Skill3,
                _ => throw new ArgumentOutOfRangeException(nameof(obj), obj, null)
            };
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

            mTarget.CharacterMouseDownEvent += OnClickCharacter;
        }

        protected override void OnExit()
        {
            base.OnExit();
            mTarget.CharacterMouseDownEvent -= OnClickCharacter;
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
            mTarget.NullMouseDown += OnClickNull;
            mTarget.MapItemMouseDownEvent += OnClickMapItem;
        }

        protected override void OnExit()
        {
            base.OnExit();
            mTarget.NullMouseDown -= OnClickNull;
            mTarget.MapItemMouseDownEvent -= OnClickMapItem;
        }
    }

    public class State_Action : GameState
    {
        public bool isComplele;

        public State_Action(FSM<State> fsm, StateMachine target) : base(fsm, target)
        {
        }

        protected override void OnEnter()
        {
            base.OnEnter();
            isComplele = false;
        }

        protected override void OnUpdate()
        {
            base.OnUpdate();
            if (isComplele)
            {
                mFSM.ChangeState(State.NoSelected);
                mTarget.ResetCharacter();
            }
        }

        protected override void OnExit()
        {
            base.OnExit();
        }
    }
}