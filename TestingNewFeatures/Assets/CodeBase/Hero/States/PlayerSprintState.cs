using UnityEngine;

namespace CodeBase.Hero.States
{
    public class PlayerSprintState : PlayerGroundedState
    {
        
        public PlayerSprintState(Hero hero,HeroAnimator heroAnimator,HeroLocomotion heroLocomotion, HeroStateMachine heroStateMachine) : base(hero,heroAnimator,heroLocomotion,heroStateMachine)
        {
            
        }

        public override void Enter()
        {
            heroLocomotion.Sprint();
            heroAnimator.SetSprint(true);
        }

        public override void Update()
        {
            base.Update();
            
            Debug.Log("Sprint");

            if (heroLocomotion.IsGrounded()&&!hero.InputService.IsSprintPress())
            {
                heroStateMachine.ChangeState(hero.PlayerMoveState);
            }
            
            else if (heroLocomotion.IsGrounded() && hero.InputService.ReadMoveValue().sqrMagnitude <= 0.1f)
            {
                heroStateMachine.ChangeState(hero.PlayerIdleState);
            }

            heroLocomotion.Move();
        }

        public override void Exit()
        {
            heroAnimator.SetSprint(false);
        }
    }
}