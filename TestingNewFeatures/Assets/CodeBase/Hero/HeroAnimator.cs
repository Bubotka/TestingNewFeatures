using CodeBase.Infrastructure.Services;
using UnityEngine;

namespace CodeBase.Hero
{
    public class HeroAnimator
    {
        private static readonly int SpeedHash = Animator.StringToHash("Speed");
        private static readonly int IdleHash = Animator.StringToHash("Idle");
        private static readonly int JumpHash = Animator.StringToHash("Jump");
        private static readonly int SprintHash = Animator.StringToHash("Sprint");
        private static readonly int IsGroundedHash = Animator.StringToHash("IsGrounded");
        private static readonly int IsAirHash = Animator.StringToHash("IsAir");
        private static readonly int AttackHash = Animator.StringToHash("Attack");
        private static readonly int HitHash = Animator.StringToHash("Hit");
        private static readonly int DieHash = Animator.StringToHash("Die");

        private IInputService _inputService;
        private Animator _animator;

        public HeroAnimator(IInputService inputService, Animator animator)
        {
            _inputService = inputService;
            _animator = animator;
        }

        public float GetSpeedValue() => 
            _animator.GetFloat(SpeedHash);

        public void PlayLocomotion() =>
            _animator.SetFloat(SpeedHash, _inputService.ReadMoveValue().SqrMagnitude(), 0.1f, Time.deltaTime);

        public void StopLocomotion() =>
            _animator.SetFloat(SpeedHash, 0);

        public void SetSprint(bool value) => 
            _animator.SetBool(SprintHash,value);

        public void PlayAir() =>
            _animator.SetTrigger(IsAirHash);

        public void PlayAttack() =>
            _animator.SetTrigger(AttackHash);

        public void PlayJump() =>
            _animator.SetTrigger( JumpHash);

        public void PlayJumpFall() =>
            _animator.SetTrigger( IsGroundedHash);

        public void PlayHit() =>
            _animator.SetTrigger(HitHash);

        public void PlayDeath() =>
            _animator.SetTrigger(DieHash);

        public void SetIdle(bool value) =>
            _animator.SetBool(IdleHash, value);
    }
}