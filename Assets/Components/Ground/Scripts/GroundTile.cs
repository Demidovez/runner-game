using System;
using System.Collections;
using GroundSpawnerSpace;
using UnityEngine;
using Random = UnityEngine.Random;

namespace GroundSpace
{
    public class GroundTile : MonoBehaviour
    {
        public GameObject[] ObstaclePrefabs;
        public Transform[] ObstacleLines;
        public LayerMask LayerMask;
        [SerializeField] private float _timeDestroy;

        private void Start()
        {
            StartCoroutine(SpawnObstacle());
        }

        private void OnTriggerEnter(Collider other)
        {
            GroundSpawner.Instance.SpawnTile();
            
            Destroy(gameObject, _timeDestroy);
        }

        private IEnumerator SpawnObstacle()
        {
            foreach (var obstacleSpawnPoints in ObstacleLines)
            {
                foreach (Transform obstacle in obstacleSpawnPoints)
                {
                    var obstaclePoint = obstacle.position;
                    bool hasPreviousObstacle = Physics.Linecast(obstaclePoint, obstaclePoint - new Vector3(0, 0, 15), LayerMask);
                    bool hasHereObstacle = Physics.Linecast(obstaclePoint + new Vector3(0, 10, 0), obstaclePoint, LayerMask);

                    if (hasPreviousObstacle || hasHereObstacle)
                    {
                        continue;
                    }

                    var chooseSpawnPrefab = ObstaclePrefabs[Random.Range(0, ObstaclePrefabs.Length)];
                    Instantiate(chooseSpawnPrefab, obstaclePoint, Quaternion.identity);

                    yield return null;
                }
            }
        }
    }
}

