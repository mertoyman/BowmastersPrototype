using UnityEngine;
using UnityEngine.PlayerLoop;
using WeaponSystem;

namespace PlayerSystem
{
    public class PlayerController : CharacterController
    {
        private PlayerView _playerView;
        private Vector2 fixedPos;

        public PlayerController(ScriptableObjectCharacter player, IProjectileService projectileService, float health)
        {
            _scriptableObjectCharacter = player;
            _projectileService = projectileService;
            GameObject playerObj = GameObject.Instantiate(player.playerView.gameObject);
            playerObj.transform.position = player.playerSpawnPosition;
            _playerView = playerObj.GetComponent<PlayerView>();
            health = player.health;
            fixedPos = playerObj.transform.position;
            _playerView.SetPlayerController(this);
            SetHealthBarFirst(health);
        }

        public void SetShootInfo(float force, float angle, bool gettingInput)
        {
            _playerView.SetShootInfo(force, angle,gettingInput);
            
            if (!gettingInput && _projectileService != null)
            {
                Debug.Log("Force " + force + "Angle " + angle);
                _projectileService.SpawnProjectile(force, angle, _playerView.ShootPos, true);
            }
           
        }
        
        public void SetHealthBarFirst(float health)
        {
            _playerView.SetHealthBarLimits(0, health);
        }

        public override void SetHealth(float health)
        {
            _playerView.SetBarHealth(health);
        }

        public Vector2 GetSpawnPos()
        {
            return fixedPos;
        }
    }
}