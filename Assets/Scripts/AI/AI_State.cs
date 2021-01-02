using Cory.RL_Crawler.Enemies;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cory.RL_Crawler.AI
{
    public class AI_State : MonoBehaviour
    {
        private Enemy_AI enemy_AI = null;
        [SerializeField]
        private List<AI_Action> aI_Actions = null;
        [SerializeField]
        private List<AI_Transition> aI_Transitions = null;

        private void Awake()
        {
            enemy_AI = transform.root.GetComponent<Enemy_AI>();
        }

        public void UpdateState()
        {
            // take an aciton
            foreach (var action in aI_Actions)
            {
                action.TakeAction();
            }

            foreach (var transition in aI_Transitions)
            {
                // player in range ? -> True -> IDLE

                // player visible ? -> True -> CHASE

                bool result = false;

                foreach (var desicion in transition.Desicions)
                {
                    result = desicion.MakeADescison();
                    if (result == false) { break; }
                }
                if (result)
                {
                    if (transition.PositiveResult != null)
                    {
                        enemy_AI.ChangeToState(transition.PositiveResult);
                        return;
                    }
                } else
                {
                    if (transition.NegativeResult != null)
                    {
                        enemy_AI.ChangeToState(transition.NegativeResult);
                        return;
                    }
                }
            }
        }
    }
}
