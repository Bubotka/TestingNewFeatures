using CodeBase.Infrastructure.Services;
using UnityEngine;

namespace CodeBase.Hero.States
{
    public class PlayerIdleState : PlayerGroundedState
    {
        private readonly HeroLocomotion _heroLocomotion;
        private IInputService _inputService;
        
        public PlayerIdleState(Hero hero, HeroAnimator heroAnimator, HeroLocomotion heroLocomotion,
            HeroStateMachine heroStateMachine, IInputService inputService) : base(hero, heroAnimator, heroStateMachine)
        {
            _heroLocomotion = heroLocomotion;
            _inputService = inputService;
        }

        public override void Enter()
        {
            Debug.Log("IdleState");
            heroAnimator.SetIdle(true);
        }

        public override void Update()
        {
            base.Update();

            _heroLocomotion.IsGrounded();
            
            Debug.Log("Jump "+_heroLocomotion.IsGrounded());
            
            if (_inputService.ReadMoveValue().sqrMagnitude>0.1f) 
                heroStateMachine.ChangeState(hero.PlayerMoveState);
        }

        public override void Exit()
        {
            heroAnimator.SetIdle(false);
        }
    }
}