using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cory.RL_Crawler.AI
{
    public class DistanceDecision : AI_Desicion
    {
        [field: SerializeField]
        [field: Range(0.1f, 15)]
        public float Distance { get; set; } = 10;

        public override bool MakeADescison()
        {
            if (Vector3.Distance(enemy_AI.Target.transform.position, transform.position) < Distance)
            {
                if (aiActionData.TargetSpotted == false)
                {
                    aiActionData.TargetSpotted = true;
                }
            }
            else
            {
                aiActionData.TargetSpotted = false;
            }
            
            return aiActionData.TargetSpotted;            
        }

        protected void OnDrawGizmos()
        {
            // visualize the Distance for the Detection Zone
            if (UnityEditor.Selection.activeObject == gameObject)
            {
                Gizmos.color = Color.green;
                Gizmos.DrawWireSphere(transform.position, Distance);
                Gizmos.color = Color.white; // reset the gizmos
            }
        }
    }
}