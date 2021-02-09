using PlayerSystem;
using UnityEngine;

namespace WeaponSystem
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class ProjectileView : MonoBehaviour
    {
        private ProjectileController _projectileController;
        
        [SerializeField] private Rigidbody2D rb;

        public void SetController(ProjectileController projectileController)
        {
            _projectileController = projectileController;
        }
        
        public void Shoot(float force, Vector2 direction)
        {
            if (force > 30)
                force = 30;
            rb.AddForce(force * direction, ForceMode2D.Impulse);
            Debug.Log("Force " + force + "Direction " + direction);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.GetComponent<ITakeDamage>() != null)
            {
                other.gameObject.GetComponent<ITakeDamage>().DamageAmount(50f);
            }

            DestroyProjectile();
        }

        private void DestroyProjectile()
        {
            _projectileController.DestroyProjectile();
            Destroy(gameObject);
        }
    }
}