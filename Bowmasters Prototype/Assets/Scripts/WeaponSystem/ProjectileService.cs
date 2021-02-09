using UnityEngine;
using Zenject;

namespace WeaponSystem
{
    public class ProjectileService : IProjectileService
    {
        readonly SignalBus _signalBus;
        private ScriptableObjectProjectile _scriptableObjectProjectile;
        private ProjectileController _projectileController;

        public ProjectileService(SignalBus signalBus, ScriptableObjectProjectile scriptableObjectProjectile)
        {
            _signalBus = signalBus;
            _scriptableObjectProjectile = scriptableObjectProjectile;
            signalBus.Subscribe<SignalDestroyProjectile>(DestroyProjectile);
        }

        public void SpawnProjectile(float force, float angle, Vector2 spawnPos, bool player)
        {
            Vector2 direction = new Vector2((float)Mathf.Cos(angle * Mathf.Deg2Rad),
                                              Mathf.Sin(angle * Mathf.Deg2Rad));

            _projectileController = new ProjectileController(this, force, direction, spawnPos, _signalBus, player);
        }
        
        public ScriptableObjectProjectile ReturnWeaponScriptable()
        {
            return _scriptableObjectProjectile;
        }

        public SignalBus GetSignalBus()
        {
            return _signalBus;
        }
        
        public void DestroyProjectile(SignalDestroyProjectile projectileDestroy)
        {
            projectileDestroy.projectileInfo.projectileController = null;
        }
    }
}