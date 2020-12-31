using Cory.RL_Crawler.ScriptableObjects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Cory.RL_Crawler.Weapons
{
    public abstract class Bullet : MonoBehaviour
    {
        [field: SerializeField]
        public virtual BulletData_SO BulletData { get; set; }
    }
}