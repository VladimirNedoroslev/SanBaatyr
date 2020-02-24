using Core.Utilities;
using UnityEngine;

namespace Core.Enemies
{
    public class EnemySpawner : MonoBehaviour
    {
        public int enemiesToSpawn;
        public float spawnRate;
        
        private int spawnedEnemies = 0;
        private float _lastSpawnTime; 
        private ObjectPooler _objectPooler;

        void Start()
        {
            _objectPooler = ObjectPooler.Instance;
        }

        private void FixedUpdate()
        {
            if (CanSpawn())
            {
                _objectPooler.SpawnFromPool(ObjectPoolerTags.BasicVirus, GetRandomPosition(transform.position), Quaternion.identity);
                spawnedEnemies++;
                _lastSpawnTime = Time.time;
            }
        }

        private bool CanSpawn()
        {
            return spawnedEnemies < enemiesToSpawn && Time.time > _lastSpawnTime + spawnRate;
        }

        private Vector2 GetRandomPosition(Vector2 pivotPosition)
        {
            var x = Random.Range(0, 2f);
            var y = Random.Range(0, 2f);
            return new Vector2(pivotPosition.x + x, pivotPosition.y + y);
        }
    }
}