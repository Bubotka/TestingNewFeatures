using UnityEngine;

namespace CodeBase.Hero
{
    public class HeroAnimationTriggers : MonoBehaviour
    {
        [SerializeField] private Hero _hero;
        
        
        private void AnimationFinished()
        {
            _hero.AnimationFinished();
        }
    }
}
