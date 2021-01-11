using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Cory.RL_Crawler.Items
{
    public class LootDrop : MonoBehaviour
    {
        // spawns "items" when the enemy dies
        [SerializeField] private List<ItemSpawnData> itemsToDrop = new List<ItemSpawnData>();
        float[] itemWeights;

        [Tooltip("The General Chance in Percent of Dropping an Item, 0% -> 100%")]
        [SerializeField][Range(0, 1)] private float dropChance;

        private void Start()
        {
            itemWeights = itemsToDrop.Select(item => item.rate).ToArray();
        }

        public void DropItem()
        {
            var dropRandomGenerator = Random.value;

            if (dropRandomGenerator < dropChance)
            {
                int index = GetRandomWeightedIndex(itemWeights);
                Instantiate(itemsToDrop[index].itemPrefab, transform.position, Quaternion.identity);
            }
        }

        /// <summary>
        /// Roulette Wheel Selection / Fitness Proportionate Selection
        /// </summary>
        /// <param name="itemWeights"></param>
        /// <returns></returns>
        private int GetRandomWeightedIndex(float[] itemWeights)
        {
            // creating a roulette wheel selection / Fitness Proportinate Selection
            float sum = 0f;
            for (int i = 0; i < itemWeights.Length; i++)
            {
                sum += itemWeights[i];
            }

            float randomValue = Random.Range(0, sum);
            float tempSum = 0; // minvalue for the given item

            for (int i = 0; i < itemsToDrop.Count; i++)
            {
                // 0 -> Weight[0] item 1            (0 -> 0.5)
                // Weight[0] -> Weight[0]+Weight[1] (0.5 -> 0.7)
                // tempSum -> tempSum + Weights[N]
                if (randomValue >= tempSum && randomValue < tempSum + itemWeights[i])
                {
                    return i;
                }
                
                tempSum += itemWeights[i];                
            }

            return 0;
        }
    }


    // Value type
    [Serializable]
    public struct ItemSpawnData
    {
        [Range(0, 1)] public float rate;
        public GameObject itemPrefab;
    }
}