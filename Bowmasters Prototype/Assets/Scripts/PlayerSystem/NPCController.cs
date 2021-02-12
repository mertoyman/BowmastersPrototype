using UnityEngine;
using WeaponSystem;

namespace PlayerSystem
{
    public class NPCController : CharacterController
    {
        private NPCView _npcView;
        private Vector2 fixedPos;

        public NPCController(ScriptableObjectCharacter npc, IProjectileService projectileService, float health)
        {
            _scriptableObjectCharacter = npc;
            _projectileService = projectileService;
            GameObject npcObject = GameObject.Instantiate(npc.npcView.gameObject);
            npcObject.transform.position = npc.npcSpawnPosition;
            _npcView = npcObject.GetComponent<NPCView>();
            health = npc.health;
            _npcView.SetNpcController(this);
            SetHealthBarFirst(health);
            fixedPos = npcObject.transform.position;
        }

        async public void RandomShoot()
        {
            await new WaitForSeconds(5);
            float randomAngle = -UnityEngine.Random.Range(10.0f, 30.0f);
            float randomForce = -UnityEngine.Random.Range(25, 40);
            _projectileService.SpawnProjectile(randomForce, randomAngle, _npcView.ShootPos, false);
            
        }
        
        public void SetHealthBarFirst(float health)
        {
            _npcView.SetHealthBarLimits(0, health);
        }

        public override void SetHealth(float health)
        {
            _npcView.SetBarHealth(health);
        }
        
        public Vector2 GetSpawnPos()
        {
            return fixedPos;
        }
    }
}