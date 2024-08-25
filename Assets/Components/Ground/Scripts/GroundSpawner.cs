using System;
using UnityEngine;

namespace GroundSpawnerSpace
{
    public class GroundSpawner : MonoBehaviour
    {
        public static GroundSpawner Instance;
        
        public GameObject GroundTilePrefab;
        [SerializeField] private float _tileVisibleInStart;
        private Vector3 _nextSpawnPoint;

        private void Awake() => Instance = this;
        
        private void Start()
        {
            for (int i = 0; i < _tileVisibleInStart; i++)
            {
                SpawnTile();
            }
        }
        
        public void SpawnTile()
        {
            GameObject groundTemp = Instantiate(GroundTilePrefab, _nextSpawnPoint, Quaternion.identity);

            _nextSpawnPoint = groundTemp.transform.GetChild(1).transform.position;
        }
    } 
}

