using System;
using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using UnityEngine;

namespace ProjectHearthaven.Controllers
{
    [Serializable]
    public class Pool
    {
        public GameObject prefab;

        [Range(0, 1000)]
        public int size;
    }

    public class ObjectPoolController : MonoBehaviour
    {
        [TableList]
        public List<Pool> pools;

        public Dictionary<string, Queue<GameObject>> poolDictionary;

        public static ObjectPoolController Instance
        {
            get { return _instance; }
        }

        private static ObjectPoolController _instance;

        private void Awake()
        {
            if (_instance != null && _instance != this)
            {
                Destroy(gameObject);
            }
            else
            {
                _instance = this;
            }

            poolDictionary = new Dictionary<string, Queue<GameObject>>();

            foreach (Pool pool in pools)
            {
                Queue<GameObject> objectPool = new Queue<GameObject>();

                for (int i = 0; i < pool.size; i++)
                {
                    GameObject obj = Instantiate(pool.prefab, transform);
                    obj.SetActive(false);
                    objectPool.Enqueue(obj);
                }

                poolDictionary.Add(pool.prefab.name, objectPool);
            }
        }

        public T GetPooledObject<T>(string tag, Vector3 position)
            where T : MonoBehaviour
        {
            if (!poolDictionary.ContainsKey(tag))
            {
                Debug.LogWarning($"Pool with tag {tag} doesn't exist.");
                return null;
            }

            GameObject objectToSpawn = poolDictionary[tag].Dequeue();

            objectToSpawn.transform.position = position;
            objectToSpawn.SetActive(true);

            poolDictionary[tag].Enqueue(objectToSpawn);

            return objectToSpawn.GetComponent<T>();
        }

        public T GetPooledObject<T>(string tag, Vector3 position, Quaternion rotation)
            where T : MonoBehaviour
        {
            if (!poolDictionary.ContainsKey(tag))
            {
                Debug.LogWarning($"Pool with tag {tag} doesn't exist.");
                return null;
            }

            GameObject objectToSpawn = poolDictionary[tag].Dequeue();

            objectToSpawn.transform.SetPositionAndRotation(position, rotation);
            objectToSpawn.SetActive(true);

            poolDictionary[tag].Enqueue(objectToSpawn);

            return objectToSpawn.GetComponent<T>();
        }

        public T GetPooledObject<T>(
            string tag,
            Vector3 position,
            Quaternion rotation,
            Transform parent
        )
            where T : MonoBehaviour
        {
            if (!poolDictionary.ContainsKey(tag))
            {
                Debug.LogWarning($"Pool with tag {tag} doesn't exist.");
                return null;
            }

            GameObject objectToSpawn = poolDictionary[tag].Dequeue();

            objectToSpawn.transform.SetPositionAndRotation(position, rotation);
            objectToSpawn.transform.SetParent(parent);
            objectToSpawn.SetActive(true);

            poolDictionary[tag].Enqueue(objectToSpawn);

            return objectToSpawn.GetComponent<T>();
        }

        public T GetPooledObject<T>(
            string tag,
            Vector3 position,
            Quaternion rotation,
            Transform parent,
            bool worldPositionStays
        )
            where T : MonoBehaviour
        {
            if (!poolDictionary.ContainsKey(tag))
            {
                Debug.LogWarning($"Pool with tag {tag} doesn't exist.");
                return null;
            }

            GameObject objectToSpawn = poolDictionary[tag].Dequeue();

            objectToSpawn.transform.SetPositionAndRotation(position, rotation);
            objectToSpawn.transform.SetParent(parent, worldPositionStays);
            objectToSpawn.SetActive(true);

            poolDictionary[tag].Enqueue(objectToSpawn);

            return objectToSpawn.GetComponent<T>();
        }

        [Button("Sort Lists")]
        public void SortLists()
        {
            pools = pools.OrderBy(i => i.prefab.name.ToString()).ToList();
        }
    }
}
