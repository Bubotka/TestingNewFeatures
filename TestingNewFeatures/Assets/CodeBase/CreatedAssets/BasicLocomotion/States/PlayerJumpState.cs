using UnityEngine;

namespace CodeBase.CreatedAssets.BasicLocomotion.States
{
    public class PlayerJumpState : PlayerBaseState
    {
        private HeroLocomotion _heroLocomotion;

        public PlayerJumpState(Hero hero, HeroAnimator heroAnimator,HeroLocomotion heroLocomotion, HeroStateMachine heroStateMachine) : base(hero, heroAnimator, heroStateMachine)
        {
            _heroLocomotion = heroLocomotion;
        }

        public override void Enter()
        {
            Debug.Log("JumpState");
            heroAnimator.PlayJump();
        }

        public override void Update()
        { 
            _heroLocomotion.Jump();

            if (_heroLocomotion.JumpVelocity <= 0)
            {
                _heroLocomotion.JumpVelocity = hero.JumpVelocity;
                heroStateMachine.ChangeState(hero.PlayerAirState);
            }
        }

        public override void Exit()
        {
        }
    }
}