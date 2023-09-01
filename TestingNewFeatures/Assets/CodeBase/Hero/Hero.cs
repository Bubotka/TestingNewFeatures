using System;
using CodeBase.Hero.States;
using CodeBase.Infrastructure.Services;
using UnityEngine;
using Zenject;

namespace CodeBase.Hero
{
    public class Hero : MonoBehaviour
    {
        [SerializeField] private Animator _animator;

        [SerializeField] private CharacterController _characterController;
        public CharacterController CharacterController => _characterController;

        [SerializeField] private float _turnSmoothTime;
        [SerializeField] private float _moveSpeed;
        [SerializeField] private float _jumpReduceVelocitySpeed;
        
        [Range(0.75f,1.25f)]
        [SerializeField] private float _groundCheckDistance;

        public float JumpVelocity;

        private HeroAnimator _heroAnimator;
        private HeroLocomotion _heroLocomotion;

        private HeroStateMachine _heroStateMachine;


        #region States

        public PlayerIdleState PlayerIdleState { get; set; }
        public PlayerMoveState PlayerMoveState { get; set; }
        public PlayerJumpState PlayerJumpState { get; set; }
        public PlayerAirState PlayerAirState { get; set; }

        #endregion

        public IInputService InputService => _inputService;
        private IInputService _inputService;

        [Inject]
        public void Construct(IInputService inputService)
        {
            _inputService = inputService;
        }

        private void Awake()
        {
            _heroLocomotion = new HeroLocomotion(_characterController, _turnSmoothTime, _moveSpeed, JumpVelocity,_jumpReduceVelocitySpeed, _groundCheckDistance, _inputService, transform);
            _heroAnimator = new HeroAnimator(_inputService, _animator);

            _heroStateMachine = new HeroStateMachine();

            #region StatesInit

            PlayerIdleState = new PlayerIdleState(this, _heroAnimator,_heroLocomotion, _heroStateMachine, _inputService);
            PlayerMoveState = new PlayerMoveState(this, _heroAnimator, _heroLocomotion, _heroStateMachine);
            PlayerJumpState = new PlayerJumpState(this, _heroAnimator, _heroLocomotion, _heroStateMachine);
            PlayerAirState = new PlayerAirState(this, _heroAnimator,_heroLocomotion, _heroStateMachine);

            #endregion
        }

        private void Start()
        {
            _heroStateMachine.Initialize(PlayerIdleState);
        }

        private void Update()
        {
            _heroStateMachine.CurrentState.Update();
        }
    }
}