using InputSystem;
using UnityEngine;
using WeaponSystem;

namespace PlayerSystem
{
    public class PlayerService : IPlayerService
    {
        private PlayerController _playerController;
        private IProjectileService _projectileService;
        private ScriptableObjectCharacter _characterObj;
        private bool _canShoot;
        private float _health;

        public PlayerService(IProjectileService projectileService, ScriptableObjectCharacter scriptableObjectCharacter)
        {
            _characterObj = scriptableObjectCharacter;
            _projectileService = projectileService;
            SpawnPlayer(_health);
        }

        public void SpawnPlayer(float health)
        {
            _playerController = new PlayerController(_characterObj,_projectileService, health);
        }
        
        public void SetPlayerData(InputData inputData, bool gettingInput)
        {
            _playerController.SetShootInfo(inputData.forceValue, inputData.angleValue, gettingInput);
        }

        public bool CanShoot {
            get => _canShoot;
            set => _canShoot = value;
        }

        public void SetPlayerHealth(float characterHealth)
        {
            _playerController.SetHealth(characterHealth);
        }
        
        public Vector3 GetCameraPosition()
        {

            return _playerController.GetSpawnPos();
        }
    }
}