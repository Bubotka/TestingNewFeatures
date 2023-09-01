using CodeBase.Infrastructure.Services;
using UnityEngine;

namespace CodeBase.Hero
{
    public class HeroLocomotion
    {
        public float JumpVelocity;
        
        private CharacterController _characterController;
        private float _turnSmoothVelocity;
        private IInputService _inputService;
        private Camera _camera;
        private Transform _heroTransform;

        private float _turnSmoothTime = 0.2f;
        private float _moveSpeed;
        private readonly float _sprintMoveSpeed;
        private float _currentMoveSpeed;
        private float _jumpReduceVelocitySpeed;
        private readonly float _groundCheckDistance;

        public Vector3 MovementVector { get;  set; }

        public HeroLocomotion(CharacterController characterController, float turnSmoothTime, float moveSpeed,float sprintMoveSpeed,
            float jumpVelocity, float jumpReduceVelocitySpeed,float groundCheckDistance, IInputService inputService, Transform heroTransform)
        {
            _characterController = characterController;
            _turnSmoothTime = turnSmoothTime;
            _inputService = inputService;
            _camera = Camera.main;
            _heroTransform = heroTransform;
            _moveSpeed = moveSpeed;
            _sprintMoveSpeed = sprintMoveSpeed;
            JumpVelocity = jumpVelocity;
            _jumpReduceVelocitySpeed = jumpReduceVelocitySpeed;
            _groundCheckDistance = groundCheckDistance;

            _currentMoveSpeed = moveSpeed;
        }

        public void Move()
        {
            MovementVector = Vector3.zero;

            if (_inputService.ReadMoveValue().sqrMagnitude > 0.1)
            {
                Vector3 direction = new Vector3(_inputService.ReadMoveValue().x, 0, _inputService.ReadMoveValue().y);

                float targetAngle = GetRotateAngle(direction);
                float angle = SmoothAngle(targetAngle);
                _heroTransform.rotation = Quaternion.Euler(0f, angle, 0f);

                MovementVector = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            }

            _characterController.Move(MovementVector * _currentMoveSpeed * Time.deltaTime);
        }

        public void Jump()
        {
            Vector3 jumpVector = Vector3.zero;

            JumpVelocity -= _jumpReduceVelocitySpeed * Time.deltaTime;

            jumpVector.y += Mathf.Sqrt(JumpVelocity * -2 * Physics.gravity.y);

            if (jumpVector.y >= 0)
                _characterController.Move((MovementVector * _moveSpeed + jumpVector) * Time.deltaTime);
        }

        public void Sprint()
        {
            _currentMoveSpeed = _sprintMoveSpeed;
        }

        public void SetDefaultMoveSpeed()
        {
            _currentMoveSpeed = _moveSpeed;
        }

        public void Inertia()
        {
            _characterController.Move(MovementVector * _currentMoveSpeed * Time.deltaTime);
        }

        public bool IsGrounded()
        {
            Vector3 raycastOrigin = _heroTransform.position + _characterController.center;
            
            Debug.DrawRay(raycastOrigin,Vector3.down*_groundCheckDistance);

            return Physics.Raycast(raycastOrigin, Vector3.down, out RaycastHit hit, _groundCheckDistance);
        }

        private float SmoothAngle(in float targetAngle) =>
            Mathf.SmoothDampAngle(_heroTransform.eulerAngles.y, targetAngle, ref _turnSmoothVelocity, _turnSmoothTime);

        private float GetRotateAngle(Vector3 direction) =>
            Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + _camera.transform.eulerAngles.y;
    }
}