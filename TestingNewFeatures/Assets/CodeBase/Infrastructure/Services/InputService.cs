using UnityEngine;
using UnityEngine.InputSystem;

namespace CodeBase.Infrastructure.Services
{
    public class InputService : IInputService
    {
        private PlayerInput _playerInput;

        public InputService()
        {
            _playerInput = new PlayerInput();
            _playerInput.Enable();
        }

        public Vector2 ReadMoveValue() => 
            _playerInput.Player.Move.ReadValue<Vector2>();

        public bool IsJumpPressed() => 
            _playerInput.Player.Jump.triggered;
    }
}
