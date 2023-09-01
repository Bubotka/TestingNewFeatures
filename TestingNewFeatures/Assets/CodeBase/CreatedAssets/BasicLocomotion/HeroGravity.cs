using UnityEngine;

namespace CodeBase.CreatedAssets.BasicLocomotion
{
    public class HeroGravity: MonoBehaviour
    {
        [SerializeField] private CharacterController _characterController;
        
        [Range(0,1)]
        [SerializeField] private float _gravityValue;
        
        
        private void Update()
        {
            if(!_characterController.isGrounded)
                _characterController.Move(Physics.gravity*Time.deltaTime);
        }
    }
}