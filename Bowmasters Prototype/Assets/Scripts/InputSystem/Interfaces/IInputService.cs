using UnityEngine;

namespace InputSystem
{
    public interface IInputService
    {
        bool CheckForCharacterPresence(Vector2 position);
        void SendPlayerData(InputData inputData, bool receiveInput);
        //Vector2 GetCharacterForwardDirection();
        Vector2 GetPlayerForwardDirection();
    }
}