using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cory.RL_Crawler.Weapons
{
    public class BulletImpact : MonoBehaviour
    {
        public void DestroyAfterAnimation()
        {
            Destroy(gameObject);
        }
    }
}