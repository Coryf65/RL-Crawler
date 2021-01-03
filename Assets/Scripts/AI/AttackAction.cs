using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cory.RL_Crawler.AI
{
    public class AttackAction : AI_Action
    {
        public override void TakeAction()
        {
            aiMovementData.Direction = Vector2.zero;
            aiMovementData.PointOfInterest = enemy_AI.Target.transform.position;
            enemy_AI.Move(aiMovementData.Direction, aiMovementData.PointOfInterest);
            aiActionData.Attack = true;
            enemy_AI.Attack();
        }
    }
}