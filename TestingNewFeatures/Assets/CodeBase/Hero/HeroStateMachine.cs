using CodeBase.Hero.States;
using UnityEngine;

namespace CodeBase.Hero
{
    public class HeroStateMachine 
    {
        public PlayerBaseState CurrentState { get; set; }
        public PlayerBaseState LastState { get; set; }
        
        
        public void Initialize(PlayerBaseState state)
        {
            CurrentState = state; 
            CurrentState.Enter();
        }

        public void ChangeState(PlayerBaseState newState)
        {
            LastState = CurrentState;
            CurrentState.Exit();
            CurrentState = newState;
            CurrentState.Enter();
        }
    }
}
