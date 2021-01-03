using Cory.RL_Crawler.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Cory.RL_Crawler.Players
{
    public class Player : MonoBehaviour, IEntity, IHittable
    {
        [field: SerializeField]
        public int Health { get; set; } = 10;

        private bool dead = false;

        [field: SerializeField]
        public UnityEvent OnDeath { get; set; }
        [field: SerializeField]
        public UnityEvent OnGetHit { get; set; }

        public void GetHit(int damage, GameObject damageDealer)
        {

            if (!dead)
            {
                Health -= damage;
                OnGetHit?.Invoke();
                if (Health <= 0)
                {
                    OnDeath?.Invoke();
                    dead = true;
                    StartCoroutine(DeathCoroutine());
                }
            }
        }

        IEnumerator DeathCoroutine()
        {
            yield return new WaitForSeconds(0.2f);
            Destroy(gameObject);
        }
    }
}