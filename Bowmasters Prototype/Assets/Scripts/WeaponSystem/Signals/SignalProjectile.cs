using UnityEngine;

namespace WeaponSystem
{
    public struct ProjectileInfo
    {
        public ProjectileController projectileController;
        public bool isPlayer;
        public GameObject projectileObject;
    }
    
    public class SignalDestroyProjectile
    {
        public ProjectileInfo projectileInfo;
    }
    
    public class SignalSpawnProjectile
    {
        public ProjectileInfo projectileInfo;
    }
}