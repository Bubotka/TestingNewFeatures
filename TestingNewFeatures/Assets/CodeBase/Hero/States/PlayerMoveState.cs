using UnityEngine;

namespace CodeBase.Hero.States
{
    public class PlayerMoveState : PlayerGroundedState
    {
        
        public PlayerMoveState(Hero hero,HeroAnimator heroAnimator,HeroLocomotion heroLocomotion, HeroStateMachine heroStateMachine) : base(hero,heroAnimator,heroLocomotion,heroStateMachine)
        {
            
        }

        public override void Enter()
        {
            heroLocomotion.SetDefaultMoveSpeed();
            Debug.Log("MoveState");
        }

        public override void Update()
        {
            base.Update();
            
            heroAnimator.PlayLocomotion();

            if(heroAnimator.GetSpeedValue()<=0.01f&& heroLocomotion.IsGrounded()&&!hero.InputService.IsJumpPressed())
                heroStateMachine.ChangeState(hero.PlayerIdleState);

            if(heroLocomotion.IsGrounded() && hero.InputService.IsSprintPress())
                heroStateMachine.ChangeState(hero.PlayerSprintState);
            
            if(heroStateMachine.CurrentState!=hero.PlayerAttackState&& heroLocomotion.IsGrounded()&& hero.InputService.IsAttackPressed())
                heroStateMachine.ChangeState(hero.PlayerAttackState);

            heroLocomotion.Move();
        }

        public override void Exit()
        {
           heroAnimator.StopLocomotion();
        }
    }
}