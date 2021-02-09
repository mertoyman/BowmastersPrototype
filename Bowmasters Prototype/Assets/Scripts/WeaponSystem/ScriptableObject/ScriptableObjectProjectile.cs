using UnityEngine;

namespace WeaponSystem
{
    [CreateAssetMenu(fileName = "ProjectileScriptableObj", menuName = "Bowmasters/CreateProjectile", order = 0)]
    public class ScriptableObjectProjectile : ScriptableObject
    {
        public ProjectileView projectileView;
    }
}