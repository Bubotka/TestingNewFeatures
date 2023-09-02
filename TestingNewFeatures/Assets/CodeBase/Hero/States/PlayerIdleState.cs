using CodeBase.Infrastructure.Services;
using UnityEngine;

namespace CodeBase.Hero.States
{
    public class PlayerIdleState : PlayerGroundedState
    {
        private IInputService _inputService;
        
        public PlayerIdleState(Hero hero, HeroAnimator heroAnimator, HeroLocomotion heroLocomotion,
            HeroStateMachine heroStateMachine, IInputService inputService) : base(hero, heroAnimator, heroLocomotion,heroStateMachine)
        {
            _inputService = inputService;
        }

        public override void Enter()
        {
            Debug.Log("IdleState");
            heroAnimator.SetIdle(true);
            heroAnimator.StopLocomotion();
        }

        public override void Update()
        {
            base.Update();
            
            heroLocomotion.Gravity();

            if (_inputService.ReadMoveValue().sqrMagnitude>0.1f&&heroLocomotion.IsGrounded()) 
                heroStateMachine.ChangeState(hero.PlayerMoveState);
            
            if(_inputService.IsAttackPressed()&& heroLocomotion.IsGrounded())
                heroStateMachine.ChangeState(hero.PlayerAttackState);
        }

        public override void Exit()
        {
            heroAnimator.SetIdle(false);
        }
    }
}