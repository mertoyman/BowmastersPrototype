using InputSystem;
using UnityEngine;

namespace PlayerSystem
{
    public interface IPlayerService
    {
        void SetPlayerData(InputData inputData, bool gettingInput);
        bool CanShoot { get; set; }
        void SetPlayerHealth(float characterHealth);
        Vector3 GetCameraPosition();
    }
}