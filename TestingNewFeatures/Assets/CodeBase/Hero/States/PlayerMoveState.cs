using UnityEngine;

namespace CodeBase.Hero.States
{
    public class PlayerMoveState : PlayerGroundedState
    {
        private HeroLocomotion _heroLocomotion;
        public PlayerMoveState(Hero hero,HeroAnimator heroAnimator,HeroLocomotion heroLocomotion, HeroStateMachine heroStateMachine) : base(hero,heroAnimator,heroStateMachine)
        {
            _heroLocomotion = heroLocomotion;
        }

        public override void Enter()
        {
            Debug.Log("MoveState");
        }

        public override void Update()
        {
            base.Update();
            
            if(heroAnimator.GetSpeedValue()<=0.01f&& hero.CharacterController.isGrounded&&!hero.InputService.IsJumpPressed())
                heroStateMachine.ChangeState(hero.PlayerIdleState);

            _heroLocomotion.Move();
            _heroLocomotion.IsGrounded();
            
            Debug.Log("Jump " + _heroLocomotion.IsGrounded());

            heroAnimator.PlayLocomotion();
        }

        public override void Exit()
        {
            heroAnimator.StopLocomotion();
        }
    }
}