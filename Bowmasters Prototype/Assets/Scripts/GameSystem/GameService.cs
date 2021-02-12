using CameraSystem.Interfaces;
using InputSystem;
using PlayerSystem;
using UnityEngine;
using WeaponSystem;
using Zenject;

namespace GameSystem
{
    public class GameService : IInitializable
    {
        private IPlayerService _playerService;
        private INPCService _npcService;
        private ICameraService _cameraService;

        public GameService(IPlayerService playerService, INPCService npcService, ICameraService cameraService, SignalBus signalBus)
        {
            _playerService = playerService;
            _npcService = npcService;
            _cameraService = cameraService;
            signalBus.Subscribe<SignalSpawnProjectile>(DisableService);
        }

        private void DisableService(SignalSpawnProjectile projectile)
        {
            if (projectile.projectileInfo.isPlayer)
            {
                _playerService.CanShoot = false;
                _npcService.NPCShoot();
            }
            else
            {
                _playerService.CanShoot = true;
            }
        }
        
        public void Initialize()
        {
            _playerService.CanShoot = true;
            _cameraService.OnGameStart();
        }
        
    }
}