using System;
using UnityEngine;

namespace Cory.RL_Crawler.ScriptableObjects
{
    [CreateAssetMenu(fileName = "WeaponDataSO", menuName = "Weapons/WeaponData", order = 2)]
    public class WeaponData_SO : ScriptableObject
    {
        [field: SerializeField]
        public BulletData_SO BulletData { get; set; }

        [field: SerializeField]
        [field: Range(0, 100)]
        public int AmmoCapacity { get; set; } = 100;

        [field: SerializeField]
        public bool AutomaticFire { get; set; } = false;

        [field: SerializeField]
        [field: Range(0.1f, 2f)]
        public float WeaponDelay { get; set; } = .1f;

        [field: SerializeField]
        [field: Tooltip("Spread of the bullets.")]
        [field: Range(0, 10)]
        public float SpreadAngle { get; set; } = 5;

        [SerializeField]
        private bool multiBulletShot = false;

        [SerializeField]
        [field: Tooltip("How many bullets are spawned per Ammo / Shot.")]
        [field: Range(1, 10)]
        private int bulletCount = 1;

        internal int GetBulletCountToSpawn()
        {
            if (multiBulletShot)
            {
                return bulletCount;
            }

            return 1;
        }
    }
}