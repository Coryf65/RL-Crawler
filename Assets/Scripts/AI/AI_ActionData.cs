using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cory.RL_Crawler.AI
{
    public class AI_ActionData : MonoBehaviour
    {
        [field: SerializeField]
        public bool Attack { get; set; }

        [field: SerializeField]
        public bool TargetSpotted { get; set; }

        [field: SerializeField]
        public bool Arrived { get; set; }
    }
}