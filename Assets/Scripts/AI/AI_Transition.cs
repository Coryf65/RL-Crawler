using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cory.RL_Crawler.AI
{
    public class AI_Transition : MonoBehaviour
    {
        [field: SerializeField]
        public List<AI_Desicion> Desicions { get; set; }

        // The state we transition to
        [field: SerializeField]
        public AI_State PositiveResult { get; set; }
        
        // what we do if one of those descicison fail
        [field: SerializeField]
        public AI_State NegativeResult { get; set; }
    }
}
