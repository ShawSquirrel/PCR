using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using GameConfig;
using Sirenix.OdinInspector;
using Spine;
using Spine.Unity;
using TEngine;
using UnityEngine;
using UnityEngine.Serialization;

namespace GameLogic
{
    public struct AnimEvent
    {
        public Action OnComplete;


        public void Reset()
        {
            OnComplete = null;
        }
    }

    [RequireComponent(typeof(SkeletonAnimation))]
    public class AnimComponent : MonoBehaviour
    {
        private static Dictionary<TAnimState, string> S_AnimNameDict;

        public AnimEvent _Event;

        public string _NormalPrefix;
        public string _SkillPrefix;
        public TAnimState _AnimState;
        private Dictionary<TAnimState, string> _animNameDict = new Dictionary<TAnimState, string>();
        private SkeletonAnimation _anim;


        protected void Awake()
        {
            _anim = GetComponent<SkeletonAnimation>();

            if (S_AnimNameDict == null)
            {
                S_AnimNameDict = new Dictionary<TAnimState, string>();
                foreach (SAnim anim in ConfigSystem.Instance.Tables.TAnim.DataList)
                {
                    S_AnimNameDict[anim.State] = anim.Name;
                }
            }
        }

        private void Start()
        {
            _anim.AnimationState.Complete += OnComplete;
        }

        private void OnComplete(TrackEntry trackentry)
        {
            _Event.OnComplete?.Invoke();
            _Event.Reset();
        }

        public void Play(TAnimState animState, bool loop = true, Action OnComplete = null)
        {
            _Event.Reset();
            switch (animState)
            {
                case TAnimState.BalloonFlyingDown:
                case TAnimState.BalloonFlyingLoop:
                case TAnimState.BalloonFlyingUp:
                case TAnimState.BalloonIn:
                case TAnimState.BalloonOut:
                case TAnimState.DearIdol:
                case TAnimState.DearJump:
                case TAnimState.DearSmile:
                case TAnimState.EatJun:
                case TAnimState.EatNormal:
                case TAnimState.FriendHightouch:
                case TAnimState.ManaIdle:
                case TAnimState.ManaJump:
                case TAnimState.NoWeaponIdle:
                case TAnimState.NoWeaponJoyShort:
                case TAnimState.NoWeaponRun:
                case TAnimState.NoWeaponRunSuper:
                case TAnimState.RunHighJump:
                case TAnimState.RunJump:
                case TAnimState.RunSpringJump:
                case TAnimState.Smile:
                case TAnimState.StaminaKarinOjigi:
                case TAnimState.UnitRaceEatShaveice:
                case TAnimState.UnitRaceRunCarpet:
                case TAnimState.UnitRaceSurfing:
                case TAnimState.UnitRaceSurfingIn:
                case TAnimState.UnitRaceSurfingOut:
                case TAnimState.UnitRaceSurfingUp:
                    PlayUniversalAnim(animState, loop);
                    break;
                case TAnimState.Attack:
                case TAnimState.AttackSkipQuest:
                case TAnimState.Damage:
                case TAnimState.Die:
                case TAnimState.Idle:
                case TAnimState.JoyLong:
                case TAnimState.JoyLongReturn:
                case TAnimState.JoyShort:
                case TAnimState.JoyShortReturn:
                case TAnimState.Landing:
                case TAnimState.MultiIdleNoWeapon:
                case TAnimState.MultiIdleStandBy:
                case TAnimState.MultiStandBy:
                case TAnimState.Run:
                case TAnimState.RunGamestart:
                case TAnimState.StandBy:
                case TAnimState.Walk:
                    PlayNormalAnim(animState, loop);
                    break;
                case TAnimState.JoyResult:
                case TAnimState.Skill0:
                case TAnimState.Skill1:
                case TAnimState.Skill2:
                case TAnimState.SkillEvolution0:
                    PlaySkillAnim(animState, loop);
                    break;
            }

            _AnimState        = animState;
            _Event.OnComplete = OnComplete;
        }

        private void PlayNormalAnim(TAnimState animState, bool loop = true)
        {
            if (_AnimState == animState) return;
            if (!_animNameDict.TryGetValue(animState, out string animName))
            {
                animName                 = $"{_NormalPrefix}_{S_AnimNameDict[animState]}";
                _animNameDict[animState] = animName;
            }

            _anim.AnimationState.SetAnimation(0, animName, loop);
        }

        private void PlaySkillAnim(TAnimState animState, bool loop = true)
        {
            if (_AnimState == animState) return;
            if (!_animNameDict.TryGetValue(animState, out string animName))
            {
                animName                 = $"{_SkillPrefix}_{S_AnimNameDict[animState]}";
                _animNameDict[animState] = animName;
            }

            _anim.AnimationState.SetAnimation(0, animName, loop);
        }

        private void PlayUniversalAnim(TAnimState animState, bool loop = true)
        {
            if (_AnimState == animState) return;
            if (!_animNameDict.TryGetValue(animState, out string animName))
            {
                animName                 = $"000000_{S_AnimNameDict[animState]}";
                _animNameDict[animState] = animName;
            }

            _anim.AnimationState.SetAnimation(0, animName, loop);
        }

        public void SetFlip(bool isLeft)
        {
            _anim.initialFlipX = isLeft;
        }

        public TAnimState _TestState;
        
        [Button("TestPlay")]
        public void TestPlay()
        {
            Play(_TestState);
        }
    }
}