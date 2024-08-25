using System;
using GroundSpawnerSpace;
using UnityEngine;
using Random = UnityEngine.Random;

namespace GroundSpace
{
    public class GroundTile : MonoBehaviour
    {
        public GameObject[] ObstaclePrefabs;
        public Transform[] ObstacleSpawnPoints;
        [SerializeField] private float _timeDestroy;

        private void Start()
        {
            SpawnObstacle();
        }

        private void OnTriggerEnter(Collider other)
        {
            GroundSpawner.Instance.SpawnTile();
            
            Destroy(gameObject, _timeDestroy);
        }

        private void SpawnObstacle()
        {
            var chooseSpawnPrefab = ObstaclePrefabs[Random.Range(0, ObstaclePrefabs.Length)];
            var obstaclePoint = ObstacleSpawnPoints[Random.Range(0, ObstacleSpawnPoints.Length)].position;

            Instantiate(chooseSpawnPrefab, obstaclePoint, Quaternion.identity);
        }
    }
}

