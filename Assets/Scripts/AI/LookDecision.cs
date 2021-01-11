using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Cory.RL_Crawler.AI
{
    public class LookDecision : AI_Desicion
    {
        [SerializeField][Range(1f, 15f)] private float Distance = 5f;
        [SerializeField] private LayerMask raycastMask = new LayerMask();

        [field: SerializeField]
        public UnityEvent OnPlayerSpotted { get; set; }


        public override bool MakeADescison()
        {
            // Targets position - this enemies position
            var direction = enemy_AI.Target.transform.position - transform.position;

            RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, Distance, raycastMask);

            if (hit.collider != null && hit.collider.gameObject.layer == LayerMask.NameToLayer("Player"))
            {
                OnPlayerSpotted?.Invoke();
                return true;
            }
            return false;
        }

        private void OnDrawGizmos()
        {
            // draw the circle only if the enemy is selected and has ai and has a valid target
            if (UnityEditor.Selection.activeObject == gameObject && enemy_AI != null && enemy_AI.Target != null)
            {
                Gizmos.color = Color.yellow;
                var direction = enemy_AI.Target.transform.position - transform.position;
                Gizmos.DrawRay(transform.position, direction.normalized * Distance);
            }
        }

    }
}