using CameraSystem;
using CameraSystem.Interfaces;
using GameSystem;
using InputSystem;
using PlayerSystem;
using WeaponSystem;
using Zenject;


public class GameInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        SignalBusInstaller.Install(Container);
        Container.DeclareSignal<SignalDestroyProjectile>();
        Container.DeclareSignal<SignalSpawnProjectile>();
        
        Container.Bind(typeof(IPlayerService))
            .To<PlayerService>()
            .AsSingle()
            .NonLazy();
        
        Container.Bind(typeof(INPCService))
            .To<NPCService>()
            .AsSingle()
            .NonLazy();
        
        Container.Bind(typeof(IInputService), typeof(ITickable))
            .To<InputService>()
            .AsSingle()
            .NonLazy();

        Container.Bind(typeof(IInitializable))
            .To<GameService>()
            .AsSingle()
            .NonLazy();

		Container.Bind(typeof(IProjectileService))
			.To<ProjectileService>()
			.AsSingle()
			.NonLazy();
        
        Container.Bind(typeof(ICameraService))
            .To<CameraService>()
            .AsSingle()
            .NonLazy();

        
    }
}