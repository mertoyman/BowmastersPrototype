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
            await new WaitForSeconds(2);
            float randomAngle = -UnityEngine.Random.Range(30.0f, 50.0f);
            _projectileService.SpawnProjectile(-100, randomAngle, _npcView.ShootPos, false);
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