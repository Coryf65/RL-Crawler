using Cory.RL_Crawler.Interfaces;
using Cory.RL_Crawler.ScriptableObjects;
using UnityEngine;

namespace Cory.RL_Crawler.Weapons
{
    public class NormalBullet : Bullet
    {
        protected Rigidbody2D rigidbody2D;
        private bool isDead = false;

        public override BulletData_SO BulletData 
        { 
            get => base.BulletData;
            set 
            {
                base.BulletData = value;
                rigidbody2D = GetComponent<Rigidbody2D>();
                rigidbody2D.drag = BulletData.Friciton;
            }
        }

        private void FixedUpdate()
        {
            if (rigidbody2D != null && BulletData != null)
            {
                // using move position due to our bullet being Kinematic
                rigidbody2D.MovePosition(transform.position + BulletData.BulletSpeed * transform.right * Time.fixedDeltaTime);
            }
        }

        /// <summary>
        /// When we hit something
        /// </summary>
        /// <param name="collision"></param>
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (isDead) { return; }

            isDead = true;

            var hittable = collision.GetComponent<IHittable>();

            hittable?.GetHit(BulletData.Damage, gameObject);

            if (collision.gameObject.layer == LayerMask.NameToLayer("Obstacle"))
            {
                HitObstacle(collision);
            }else if (collision.gameObject.layer == LayerMask.NameToLayer("Enemies"))
            {
                HitEnemy(collision);
            }
            Destroy(gameObject);
        }

        /// <summary>
        /// Hit an Enemy
        /// </summary>
        /// <param name="collision"></param>
        private void HitEnemy(Collider2D collision)
        {
            // Do a knockback effect if needed
            var knockback = collision.GetComponent<IKnockback>();
            knockback?.Knockback(transform.right, BulletData.KnockbackPower, BulletData.KnockbackDelay);

            // creating hit effect, around Radius
            float radius = 0.5f;
            Vector2 randomOffset = Random.insideUnitCircle * radius;

            Instantiate(BulletData.ImpactEffectEntity, collision.transform.position + (Vector3)randomOffset, Quaternion.identity);
        }

        /// <summary>
        /// Hit an Obstacle, using a RayCast
        /// </summary>
        /// <param name="collision"></param>
        private void HitObstacle(Collider2D collision)
        {
            // creating hit effect, at closest raycast to wall, our bullet is facing "Right" we rotate that sprite
            RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right);

            if (hit.collider != null)
            {
                // point in world space
                Instantiate(BulletData.ImpactEffectObstacle, hit.point, Quaternion.identity);
            }
        }
    }
}