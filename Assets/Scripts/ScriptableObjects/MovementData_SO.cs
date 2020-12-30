using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cory.RL_Crawler.ScriptableObjects
{
    [CreateAssetMenu(fileName = "MovementDataSO", menuName = "Entity/MovementData", order = 1)]
    public class MovementData_SO : ScriptableObject
    {
        [Range(1,10)] public float maxSpeed = 5f;        
        [Range(.1f,100f)] public float acceleration = 50f;
        [Range(.1f, 100f)] public float deacceleration = 50f;
    }
}