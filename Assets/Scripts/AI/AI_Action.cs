using Cory.RL_Crawler.Enemies;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cory.RL_Crawler.AI
{
    public abstract class AI_Action : MonoBehaviour
    {
        protected AI_ActionData aiActionData;
        protected AI_MovementData aiMovementData;
        protected Enemy_AI enemy_AI;

        private void Awake()
        {
            aiActionData = transform.root.GetComponentInChildren<AI_ActionData>();
            aiMovementData = transform.root.GetComponentInChildren<AI_MovementData>();
            enemy_AI = transform.root.GetComponent<Enemy_AI>();
        }

        public abstract void TakeAction();
    }
}