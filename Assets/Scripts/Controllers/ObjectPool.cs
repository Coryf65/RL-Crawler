using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cory.RL_Crawler.Controllers
{
    public class ObjectPool : MonoBehaviour
    {
        [Tooltip("Game Object to display")]
        [SerializeField] protected GameObject objectToSpawn;
        [Tooltip("the total amount of objects available to spawn")]
        [SerializeField] protected int poolSize;

        protected int currentSize;
        protected Queue<GameObject> objectPool; // FIFO

        private void Awake()
        {
            objectPool = new Queue<GameObject>();
        }

        public virtual GameObject SpawnObject(GameObject currentObject = null)
        {
            if (currentObject == null)
            {
                currentObject = objectToSpawn;
            }

            // thing to spawn
            GameObject spawnedObject = null;

            if (currentSize < poolSize)
            {
                // we can soawn more
                spawnedObject = Instantiate(currentObject, transform.position, Quaternion.identity);
                spawnedObject.name = currentObject.name + "_" + currentSize;
                currentSize++;
            } else
            {
                spawnedObject = objectPool.Dequeue(); // get the first to go, the oldest
                spawnedObject.transform.position = transform.position;
                spawnedObject.transform.rotation = Quaternion.identity;
            }

            objectPool.Enqueue(spawnedObject);

            return spawnedObject;
        }
    }
}