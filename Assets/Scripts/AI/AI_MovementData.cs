using UnityEngine;

namespace Cory.RL_Crawler.AI
{
    public class AI_MovementData : MonoBehaviour
    {
        [field: SerializeField]
        public Vector2 Direction { get; set; }
        [field: SerializeField]
        public Vector2 PointOfInterest { get; set; }
    }
}