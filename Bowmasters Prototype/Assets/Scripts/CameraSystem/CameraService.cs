using System.Collections.Generic;
using CameraSystem.Interfaces;
using PlayerSystem;
using UnityEngine;
using WeaponSystem;
using Zenject;

namespace CameraSystem
{
    public enum CameraTurn
    {
        TURN1,
        TURN2
    }
    
    public class CameraService : ICameraService
    {
        private IPlayerService _playerService;
        private INPCService _npcService;
        private Vector3 turnPlayerPos;
        private Vector3 turnNpcPos;
        private Camera mainCamera;
        private Vector3 offset=new Vector3(0,0,-10f);
        private GameObject projectileToFollow;
        private CameraTurn currentTurn;

        public CameraService(IPlayerService playerService, INPCService npcService, SignalBus signalBus)
        {
            _playerService = playerService;
            _npcService = npcService;
            mainCamera = Camera.main;
            signalBus.Subscribe<SignalSpawnProjectile>(SetProjectileToFollow);
            signalBus.Subscribe<SignalDestroyProjectile>(SwitchCamera);
        }
        
        async public void OnGameStart()
        {
            Vector3 cameraPosPlayer = _playerService.GetCameraPosition();
            Vector3 cameraPosNpc = _npcService.GetCameraPosition();
            turnPlayerPos = cameraPosPlayer + offset;
            turnNpcPos = cameraPosNpc + offset;
            mainCamera.orthographicSize = 10;
            iTween.MoveTo(mainCamera.gameObject, turnNpcPos, 1f);
            currentTurn = CameraTurn.TURN2;
            await new WaitForSeconds(3f);
            iTween.MoveTo(mainCamera.gameObject, turnPlayerPos, 1f);
        }

        private void SetProjectileToFollow(SignalSpawnProjectile spawnProjectileSignal)
        {
            projectileToFollow = spawnProjectileSignal.projectileInfo.projectileObject;
            FollowProjectile();
        }

        public void ResetCameraOrthoSize()
        {
            throw new System.NotImplementedException();
        }
        
        async public void SwitchCamera()
        {
            if (currentTurn == CameraTurn.TURN2)
            {
                iTween.MoveTo(mainCamera.gameObject, turnNpcPos, 1f);
                await new WaitForSeconds(1.2f);
                mainCamera.orthographicSize = 10f;
                currentTurn = CameraTurn.TURN1;
            }
            else if(currentTurn == CameraTurn.TURN1)
            {

                iTween.MoveTo(mainCamera.gameObject, turnPlayerPos, 1f);
                await new WaitForSeconds(2f);
                mainCamera.orthographicSize = 10f;
                currentTurn = CameraTurn.TURN2;
            }
        }

        async public void FollowProjectile()
        {
            while (projectileToFollow != null)
            {
                await new WaitForEndOfFrame();
                mainCamera.transform.localPosition = new Vector3(
                    projectileToFollow.transform.localPosition.x,
                    projectileToFollow.transform.localPosition.y,
                    mainCamera.transform.localPosition.z);
            }
        }
    }
}