using System.Collections.Generic;
using Core.Interfaces;
using UnityEngine;

namespace Core.Utilities
{
    public class ObjectPooler : MonoBehaviour
    {
        public static ObjectPooler Instance;

        #region Singleton

        private void Awake()
        {
            Instance = this;
        }

        #endregion

        [SerializeField] private Transform canvasTransform;
        [SerializeField] private List<Pool> pools;
        private Dictionary<string, Queue<GameObject>> _poolDictionary;

        private void Start()
        {
            _poolDictionary = new Dictionary<string, Queue<GameObject>>();

            foreach (Pool pool in pools)
            {
                Queue<GameObject> objectPool = new Queue<GameObject>();

                for (int i = 0; i < pool.size; i++)
                {
                    GameObject newObject = Instantiate(pool.prefab, transform);
                    newObject.SetActive(false);
                    if (pool.RelatedToUi)
                    {
                        newObject.transform.SetParent(canvasTransform);
                    }

                    objectPool.Enqueue(newObject);
                }

                _poolDictionary.Add(pool.tag, objectPool);
            }
        }

        public GameObject SpawnFromPool(string tag, Vector2 position, Quaternion rotation)
        {
            if (!_poolDictionary.ContainsKey(tag))
            {
                Debug.LogWarning("Pool with tag " + tag + " doesn't exist");
                return null;
            }

            GameObject spawnedObject = _poolDictionary[tag].Dequeue();
            spawnedObject.transform.position = position;
            spawnedObject.transform.rotation = rotation;
            
            var pooledObject = spawnedObject.GetComponent<IPooledObject>();
            if (pooledObject.ActivateOnSpawn)
            {
                spawnedObject.SetActive(true);
            }
            pooledObject.OnObjectSpawn();
            
            _poolDictionary[tag].Enqueue(spawnedObject);

            return spawnedObject;
        }
    }
}