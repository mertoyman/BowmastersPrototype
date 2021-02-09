using UnityEngine;
using WeaponSystem;

namespace PlayerSystem
{
    public class CharacterController
    {
        protected IProjectileService _projectileService;
        protected ScriptableObjectCharacter _scriptableObjectCharacter;
        public virtual void SetHealth(float health)
        {
            
        }
    }
}