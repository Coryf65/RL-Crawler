using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cory.RL_Crawler.AI
{
    public class ChaseAction : AI_Action
    {
        public override void TakeAction()
        {
            // find something
            var direction = enemy_AI.Target.transform.position - transform.position;
            aiMovementData.Direction = direction.normalized;
            aiMovementData.PointOfInterest = enemy_AI.Target.transform.position;

            // move to the POI
            enemy_AI.Move(aiMovementData.Direction, aiMovementData.PointOfInterest);
        }
    }
}