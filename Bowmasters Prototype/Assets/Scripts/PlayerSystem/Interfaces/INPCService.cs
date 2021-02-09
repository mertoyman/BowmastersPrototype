using UnityEngine;

namespace PlayerSystem
{
    public interface INPCService
    {
        void NPCShoot();
        float GetNpcHealth();
        Vector3 GetCameraPosition();
    }
}