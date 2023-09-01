using CodeBase.Hero.States;
using UnityEngine;

namespace CodeBase.Hero
{
    public class HeroStateMachine 
    {
        public PlayerBaseState CurrentState { get; set; }
        
        public void Initialize(PlayerBaseState state)
        {
            CurrentState = state; 
            CurrentState.Enter();
        }

        public void ChangeState(PlayerBaseState newState)
        {
            CurrentState.Exit();
            CurrentState = newState;
            CurrentState.Enter();
        }
    }
}
