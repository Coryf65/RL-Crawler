using UnityEngine;
using Random = UnityEngine.Random;

namespace Cory.RL_Crawler.ScriptableObjects
{
    [CreateAssetMenu(fileName = "ResourceDataSO", menuName = "Items/ResourceData", order = 1)]
    public class ResourceData_SO : ScriptableObject
    {
        [field: SerializeField]
        public ResourceType ResourceType { get; set; }

        [SerializeField] private int minDropAmount = 1;
        [SerializeField] private int maxDropAmount = 5;

        public int GetAmount()
        {
            // 1 -> 5
            return Random.Range(minDropAmount, maxDropAmount + 1);
        }
    }

    public enum ResourceType
    {
        None,
        Health,
        Ammo
    }
}