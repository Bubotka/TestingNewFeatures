using UnityEngine;

namespace CodeBase.Infrastructure.Services
{
    public interface IInputService
    {
        Vector2 ReadMoveValue();
        bool IsJumpPressed();
        bool IsSprintPress();
        bool IsAttackPressed();
    }
}