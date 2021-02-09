using UnityEngine;

namespace WeaponSystem
{
    public interface IProjectileService
    {
        void SpawnProjectile(float force, float angle, Vector2 position, bool player);
    }
}