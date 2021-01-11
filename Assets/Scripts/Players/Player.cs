using Cory.RL_Crawler.Interfaces;
using Cory.RL_Crawler.UI;
using Cory.RL_Crawler.ScriptableObjects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Cory.RL_Crawler.Items;

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

        private PlayerWeapon playerWeapon;

        [field: SerializeField]
        public Health_UI health_UI { get; set; }

        [field: SerializeField]
        public UnityEvent OnDeath { get; set; }
        [field: SerializeField]
        public UnityEvent OnGetHit { get; set; }

        private void Awake()
        {
            // the weapon is a child to our player
            playerWeapon = GetComponentInChildren<PlayerWeapon>();
        }

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

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.layer == LayerMask.NameToLayer("Pickups"))
            {
                Resource pickup = collision.gameObject.GetComponent<Resource>();

                if (pickup != null)
                {
                    switch (pickup.ResourceData.ResourceType)
                    {
                        case ResourceType.Health:

                            if (Health >= maxHealth)
                            {
                                return;
                            } else
                            {
                                Health += pickup.ResourceData.GetAmount();
                                pickup.PlayPickupSound();
                            }
                            break;
                        case ResourceType.Ammo:

                            if (playerWeapon.AmmoFull)
                            {
                                return;
                            } else
                            {
                                playerWeapon.AddAmmo(pickup.ResourceData.GetAmount());
                                pickup.PlayPickupSound();
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
        }
    }
}