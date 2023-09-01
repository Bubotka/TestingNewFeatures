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
            Debug.Log("AirState");
        }

        public override void Update()
        {
            _heroLocomotion.Inertia();
            
            if (hero.CharacterController.isGrounded)
            {
                heroStateMachine.ChangeState(hero.PlayerIdleState);
            }
        }

        public override void Exit()
        {
            heroAnimator.PlayJumpFall();
            heroAnimator.StopLocomotion();
        }
    }
}