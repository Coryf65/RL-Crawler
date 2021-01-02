using Cory.RL_Crawler.Interfaces;
using Cory.RL_Crawler.ScriptableObjects;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Cory.RL_Crawler.Enemies
{
    public class Enemy : MonoBehaviour, IHittable, IEntity
    {
        [field: SerializeField]
        public EnemyData_SO EnemyDataSO { get; set; }

        [field: SerializeField]
        public int Health { get; private set; } = 2;

        [field: SerializeField]
        public UnityEvent OnGetHit { get; set; }

        [field: SerializeField]
        public UnityEvent OnDeath { get; set; }

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
                OnDeath?.Invoke();
                StartCoroutine(WaitToDie()); // allows the sound to play on destroy
            }
        }

        IEnumerator WaitToDie()
        {
            yield return new WaitForSeconds(.55f);
            Destroy(gameObject);
        }
    }
}