using UnityEngine;
using WeaponSystem;

namespace PlayerSystem
{
    public class NPCService : INPCService
    {
        private NPCController _npcController;
        private IProjectileService _projectileService;
        private ScriptableObjectCharacter _characterObj;
        private float _health;

        public NPCService(IProjectileService projectileService, ScriptableObjectCharacter scriptableObjectCharacter)
        {
            _projectileService = projectileService;
            _characterObj = scriptableObjectCharacter;
           SpawnNpc(_health);
           
        }

        public void SpawnNpc(float health)
        {
            _npcController = new NPCController(_characterObj, _projectileService, health);
        }
        
        public void NPCShoot()
        {
            
            _npcController.RandomShoot();
        }

        public float GetNpcHealth()
        {
            return _health;
        }

        public Vector3 GetCameraPosition()
        {

           return _npcController.GetSpawnPos();
        }
    }
}