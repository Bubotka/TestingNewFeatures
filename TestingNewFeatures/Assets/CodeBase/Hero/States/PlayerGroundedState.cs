using UnityEngine;

namespace CodeBase.Hero.States
{
    public class PlayerGroundedState : PlayerBaseState
    {
        public PlayerGroundedState(Hero hero, HeroAnimator heroAnimator, HeroStateMachine heroStateMachine) : base(hero, heroAnimator, heroStateMachine)
        {
        }

        public override void Enter()
        {
            
        }

        public override void Update()
        {
            if(hero.CharacterController.isGrounded&& hero.InputService.IsJumpPressed())
                heroStateMachine.ChangeState(hero.PlayerJumpState);
        }

        public override void Exit()
        {
            
        }
    }
}