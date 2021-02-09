using PlayerSystem;
using UnityEngine;
using UnityEngine.Serialization;
using WeaponSystem;
using Zenject;

[CreateAssetMenu(fileName = "ScriptableObjectInstaller", menuName = "Bowmasters/Installers/ScriptableObjectInstaller")]
public class ScriptableObjectInstaller : ScriptableObjectInstaller<ScriptableObjectInstaller>
{
    public ScriptableObjectCharacter scriptableObjectCharacter;
    public ScriptableObjectProjectile scriptableObjectProjectile;
    
    public override void InstallBindings()
    {
        Container.BindInstances(scriptableObjectCharacter);
        Container.BindInstances(scriptableObjectProjectile);
    }
}