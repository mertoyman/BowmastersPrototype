using PlayerSystem;
using UnityEngine;
using Zenject;

namespace InputSystem
{
    public enum InputStatus
    {
        INVALID,
        VALID
    }

    public class InputService : IInputService, ITickable
    {
        private IPlayerService _playerService;
        private IInputComponent inputComponent;
        private Camera cam;

        private Vector2 forwardCharacterDirection;

        public InputService(IPlayerService playerService)
        {
            _playerService = playerService;
            inputComponent = new MouseInput(this);
            cam = Camera.main;
        }

        public void SendPlayerData(InputData inputData, bool receiveInput)
        {
            _playerService.SetPlayerData(inputData, receiveInput);
        }

        public void Tick()
        {
            if (_playerService.CanShoot)
            {
                inputComponent.OnTick();
            }
        }

        public bool CheckForCharacterPresence(Vector2 position)
        {
            if (cam != null)
            {
                Ray hitRay = cam.ScreenPointToRay(position);
                RaycastHit2D hitInfo = Physics2D.GetRayIntersection(hitRay, 100);
                if (hitInfo.collider != null)
                {
                    //Debug.Log("COLLIDER NAME"+hitInfo.collider.name);   
                    if (hitInfo.collider.GetComponent<PlayerView>() != null)
                    {
                        //Debug.Log("[InputService] PlayerDetected");
                        forwardCharacterDirection =
                            hitInfo.collider.GetComponent<PlayerView>().GetForwardDirection();
                        return true;
                    }
                }
            }

            return false;
        }

        public Vector2 GetPlayerForwardDirection()
        {
            return forwardCharacterDirection;
        }
    }
}