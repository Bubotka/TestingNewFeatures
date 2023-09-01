using UnityEngine;

namespace CodeBase.Hero.States
{
    public class PlayerGroundedState : PlayerBaseState
    {
        protected HeroLocomotion heroLocomotion;

        public PlayerGroundedState(Hero hero,HeroAnimator heroAnimator, HeroLocomotion heroLocomotion, HeroStateMachine heroStateMachine) : base(hero, heroAnimator, heroStateMachine)
        {
            this.heroLocomotion = heroLocomotion;
        }

        public override void Enter()
        {
            
        }

        public override void Update()
        {
            if(heroLocomotion.IsGrounded() && hero.InputService.IsJumpPressed())
                heroStateMachine.ChangeState(hero.PlayerJumpState);

            else if(!heroLocomotion.IsGrounded())
                heroStateMachine.ChangeState(hero.PlayerAirState);
        }

        public override void Exit()
        {
            
        }
    }
}