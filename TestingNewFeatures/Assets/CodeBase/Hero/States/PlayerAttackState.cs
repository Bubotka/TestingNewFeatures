using CodeBase.Infrastructure.Services;
using UnityEngine;

namespace CodeBase.Hero.States
{
    public class PlayerAttackState : PlayerGroundedState
    {
        private HeroAttack.HeroAttack _heroAttack;
        private IInputService _inputService;
        private float _lastTimeAttacted;
        private float _comboWindow = 1f;
        private int _comboCounter=1;

        public PlayerAttackState(Hero hero, HeroAnimator heroAnimator,HeroAttack.HeroAttack heroAttack, HeroLocomotion heroLocomotion,
            HeroStateMachine heroStateMachine, IInputService inputService) : base(hero, heroAnimator, heroLocomotion,heroStateMachine)
        {
            _heroAttack = heroAttack;
            _inputService = inputService;
        }

        public override void Enter()
        {
            Debug.Log("AttackState");
            
            heroAnimator.SetAttack(true);

            if (_comboCounter > 4 || Time.time > _lastTimeAttacted + _comboWindow)
                _comboCounter = 1;
       
            heroAnimator.SetComboCounter(_comboCounter);
        }

        public override void Update()
        {
            base.Update();

            heroLocomotion.Gravity();

            if (hero.TriggerCalled)
            {
                heroStateMachine.ChangeState(hero.PlayerIdleState);
            }
            
        }

        public override void Exit()
        {
            heroAnimator.SetAttack(false);
            hero.TriggerCalled = false;
            _lastTimeAttacted = Time.time;
            ++_comboCounter;    
        }
    }
}