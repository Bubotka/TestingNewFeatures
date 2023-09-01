using UnityEngine;

namespace CodeBase.Hero.States
{
    public class PlayerAirState : PlayerBaseState
    {
        private readonly HeroLocomotion _heroLocomotion;

        public PlayerAirState(Hero hero, HeroAnimator heroAnimator, HeroLocomotion heroLocomotion,
            HeroStateMachine heroStateMachine) : base(hero, heroAnimator, heroStateMachine)
        {
            _heroLocomotion = heroLocomotion;
        }

        public override void Enter()
        {
            if(heroStateMachine.LastState!=hero.PlayerJumpState)
                heroAnimator.PlayAir();
        }

        public override void Update()
        {
            _heroLocomotion.Inertia();
            
            if (_heroLocomotion.IsGrounded())
            {
                heroStateMachine.ChangeState(hero.PlayerIdleState);
            }
        }

        public override void Exit()
        {
            heroAnimator.PlayJumpFall();
            heroAnimator.StopLocomotion();
            
            _heroLocomotion.MovementVector = Vector3.zero;
        }
    }
}