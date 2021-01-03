using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cory.RL_Crawler.Enemies
{
    public abstract class EnemyAttack : MonoBehaviour
    {
        private Enemy_AI enemy_AI;
        protected bool waitOnNextAttack;

        [field: SerializeField]
        public float AttackDelay { get; private set; } = 1;

        private void Awake()
        {
            enemy_AI = GetComponent<Enemy_AI>();
        }

        public abstract void Attack(int damage);

        protected IEnumerator WaitBeforeAttacking()
        {
            waitOnNextAttack = true;
            yield return new WaitForSeconds(AttackDelay);
            waitOnNextAttack = false;
        }

        protected GameObject GetTarget()
        {
            return enemy_AI.Target;
        }

    }
}