namespace CodeBase.Hero.States
{
    public abstract class PlayerBaseState
    {
        protected Hero hero;
        protected HeroAnimator heroAnimator;

        protected HeroStateMachine heroStateMachine;

        protected PlayerBaseState(Hero hero,HeroAnimator heroAnimator, HeroStateMachine heroStateMachine)
        {
            this.hero = hero;
            this.heroAnimator = heroAnimator;
            this.heroStateMachine = heroStateMachine;
        }

        public abstract void Enter();
        public abstract void Update();
        public abstract void Exit();
    }
}
