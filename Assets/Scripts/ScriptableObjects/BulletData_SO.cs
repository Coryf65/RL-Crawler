using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cory.RL_Crawler.ScriptableObjects
{
    [CreateAssetMenu(fileName = "BulletDataSO", menuName = "Weapons/BulletData", order = 3)]
    public class BulletData_SO : ScriptableObject
    {
        [field: SerializeField]
        public GameObject bulletPrefab { get; set; }

        [field: SerializeField]
        [field: Range(1, 100)]
        public float BulletSpeed { get; internal set; } = 1;

        [field: SerializeField]
        [field: Range(1, 100)]
        public int Damage { get; set; } = 1;

        [field: SerializeField]
        [field: Range(0, 100)]
        public float Friciton { get; internal set; } = 0;

        [field: SerializeField]
        [field: Tooltip("Do these Bullets bounce off walls ?")]
        public bool Bouncey { get; set; } = false;

        [field: SerializeField]
        [field: Tooltip("Do these Bullets Penatrate through enemies and beyond ?")]
        public bool Peircing { get; set; } = false;

        [field: SerializeField]
        [field: Tooltip("Are these bullets a ray, like a laser beam and not solid ?")]
        public bool IsRaycast { get; set; } = false;

        [field: SerializeField]
        [field: Tooltip("The power / force applied to an Entity hit with Knockback")]
        [field: Range(1, 20)]
        public float KnockbackPower { get; set; } = 5;

        [field: SerializeField]
        [field: Tooltip("Amount of time in seconds the knockback effect pushes a Entity")]
        [field: Range(0.01f, 1f)]
        public float KnockbackDelay { get; set; } = .1f;

        [field: SerializeField]
        [field: Tooltip("The type of hit effect on a Obsticle, box / wall")]
        public GameObject ImpactEffectObstacle { get; set; }

        [field: SerializeField]
        [field: Tooltip("The type of hit effect on a Enemy / Entity, gremlin, goblin, goul")]
        public GameObject ImpactEffectEntity { get; set; }
    }
}