using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cory.RL_Crawler.AI
{
    public class IdleAction : AI_Action
    {
        public override void TakeAction()
        {            
            aiMovementData.Direction = Vector2.zero;
            aiMovementData.PointOfInterest = transform.position;

            enemy_AI.Move(aiMovementData.Direction, aiMovementData.PointOfInterest);
        }
    }
}