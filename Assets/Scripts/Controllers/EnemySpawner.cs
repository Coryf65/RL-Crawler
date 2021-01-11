using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cory.RL_Crawler.Controllers
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private GameObject enemyPrefab = null;
        [SerializeField] private List<GameObject> spawnPoints = null;
        [SerializeField] private int enemiesToSpawn = 20;
        [SerializeField] private float minDelay = 0.8f;
        [SerializeField] private float maxDelay = 1.5f;

        private void Start()
        {
            if (spawnPoints.Count > 0)
            {
                foreach (var spawnPoint in spawnPoints)
                {
                    SpawnEnemy(spawnPoint.transform.position);
                }
            }
            StartCoroutine(SpawnCoroutine());
        }

        IEnumerator SpawnCoroutine()
        {
            // only soawn if we don't exceed the max
            while (enemiesToSpawn > 0)
            {
                enemiesToSpawn--;
                var randomIndex = Random.Range(0, spawnPoints.Count);

                var randomOffset = Random.insideUnitCircle;
                var spawnPoint = spawnPoints[randomIndex].transform.position + (Vector3)randomOffset;

                SpawnEnemy(spawnPoint);

                var randomTime = Random.Range(minDelay, maxDelay);

                yield return new WaitForSeconds(randomTime);
            }
        }

        private void SpawnEnemy(Vector3 spawnPoint)
        {
            Instantiate(enemyPrefab, spawnPoint, Quaternion.identity);
        }
    }
}