using Cory.RL_Crawler.ScriptableObjects;
using UnityEngine;
using UnityEngine.Events;

namespace Cory.RL_Crawler.Interfaces
{
    public class Enemy : MonoBehaviour, IHittable
    {
        [field: SerializeField]
        public EnemyData_SO EnemyDataSO { get; set; }

        [field: SerializeField]
        public int Health { get; private set; } = 2;

        [field: SerializeField]
        public UnityEvent OnGetHit { get; set; }

        private void Start()
        {
            Health = EnemyDataSO.MaxHealth;
        }

        public void GetHit(int damage, GameObject damageDealer)
        {
            Health--;

            OnGetHit?.Invoke();
            
            if (Health <= 0)
            {
                Destroy(gameObject);    
            }
        }
    }
}