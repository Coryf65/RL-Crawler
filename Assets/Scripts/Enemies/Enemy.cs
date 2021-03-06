using Cory.RL_Crawler.Controllers;
using Cory.RL_Crawler.Interfaces;
using Cory.RL_Crawler.ScriptableObjects;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Cory.RL_Crawler.Enemies
{
    public class Enemy : MonoBehaviour, IHittable, IEntity, IKnockback
    {
        [field: SerializeField]
        public EnemyData_SO EnemyDataSO { get; set; }

        [field: SerializeField]
        public int Health { get; private set; } = 2;

        [field: SerializeField]
        public EnemyAttack enemyAttack { get; set; }

        [field: SerializeField]
        private bool dead = false;
        private MovementHandler movementHandler = null;

        [field: SerializeField]
        public UnityEvent OnGetHit { get; set; }

        [field: SerializeField]
        public UnityEvent OnDeath { get; set; }

        private void Awake()
        {
            if (enemyAttack == null)
            {
                enemyAttack = GetComponent<EnemyAttack>();
            }

            movementHandler = GetComponent<MovementHandler>();
        }

        private void Start()
        {
            Health = EnemyDataSO.MaxHealth;
        }

        public void GetHit(int damage, GameObject damageDealer)
        {

            if (dead) { return; }

            Health--;
            OnGetHit?.Invoke();

            if (Health <= 0)
            {
                dead = true;
                OnDeath?.Invoke();
            }
        }

        public void Die()
        {
            Destroy(gameObject);
        }

        public void PerformAttack()
        {
            if (!dead)
            {
                enemyAttack.Attack(EnemyDataSO.Damage);
            }
        }

        public void Knockback(Vector2 direction, float power, float duration)
        {
            movementHandler.Knockback(direction, power, duration);
        }
    }
}