using PlayerSystem;
using UnityEngine;
using WeaponSystem;
using Zenject;
using Zenject.SpaceFighter;

namespace WeaponSystem
{
    public class ProjectileController
    {
        protected ProjectileService _projectileService;
        protected ProjectileView _projectileView;
        protected bool _isPlayer;

        public ProjectileController(ProjectileService projectileService, float force, Vector2 direction, Vector2 spawnPos, SignalBus signalBus, bool isPlayer)
        {
            _isPlayer = isPlayer;
            _projectileService = projectileService; 
            GameObject projectile = GameObject.Instantiate(GetProjectileView().gameObject);
            projectile.transform.position = spawnPos;
            _projectileView = projectile.GetComponent<ProjectileView>();
            _projectileView.SetController(this);
            _projectileView.Shoot(force, direction);
            signalBus.TryFire(new SignalSpawnProjectile(){ projectileInfo = InitializeProjectileInfo() });
        }

        public ProjectileInfo InitializeProjectileInfo()
        {
            ProjectileInfo projectileInfo;
            projectileInfo.isPlayer = _isPlayer;
            projectileInfo.projectileObject = _projectileView.gameObject;
            projectileInfo.projectileController = this;
            return projectileInfo;
        }
        
        protected ProjectileView GetProjectileView()
        {

            return _projectileService.ReturnWeaponScriptable().projectileView;
        }
        
        public void DestroyProjectile()
        {
            
            _projectileService.GetSignalBus().TryFire(new SignalDestroyProjectile()
                { projectileInfo = InitializeProjectileInfo()});
        }
    }
}