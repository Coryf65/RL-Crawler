using Cory.RL_Crawler.Interfaces;
using Cory.RL_Crawler.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Cory.RL_Crawler.Players
{
    public class Player : MonoBehaviour, IEntity, IHittable
    {

        [SerializeField] private int maxHealth;

        private int health;

        public int Health { 
            
            get => health;
            set 
            {
                health = Mathf.Clamp(value, 0, maxHealth); // not allow more than max
                health_UI.UpdateUI(health);
            } 
        }

        private bool dead = false;

        [field: SerializeField]
        public Health_UI health_UI { get; set; }

        [field: SerializeField]
        public UnityEvent OnDeath { get; set; }
        [field: SerializeField]
        public UnityEvent OnGetHit { get; set; }

        private void Start()
        {
            Health = maxHealth;
            health_UI.Initialize(Health);
        }

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
                    // play death animation
                }
            }
        }
    }
}