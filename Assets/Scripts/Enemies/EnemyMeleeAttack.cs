using Cory.RL_Crawler.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cory.RL_Crawler.Enemies
{
    public class EnemyMeleeAttack : EnemyAttack
    {
        public override void Attack(int damage)
        {
            if (waitOnNextAttack == false)
            {
                var hittable = GetTarget().GetComponent<IHittable>();
                hittable?.GetHit(damage, gameObject);
                StartCoroutine(WaitBeforeAttacking());
            }
        }
    }
}