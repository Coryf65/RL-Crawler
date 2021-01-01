using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cory.RL_Crawler.ScriptableObjects
{
    [CreateAssetMenu(fileName = "EnemyDataSO", menuName = "Enemies/EnemyData", order = 1)]
    public class EnemyData_SO : ScriptableObject
    {
        [field: SerializeField]
        public int MaxHealth { get; set; } = 3;

        [field: SerializeField]
        public int Damage { get; set; } = 1;
    }
}