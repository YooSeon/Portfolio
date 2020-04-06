using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudPooer : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefabs;
        public int size;
    }

    public List<Pool> listPool;
    public Dictionary<string,Queue<GameObject>> dictionaryPool;

    public static CloudPooer instance;


    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        dictionaryPool = new Dictionary<string, Queue<GameObject>>();

        foreach (Pool pool in listPool)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for (int i = 0; i < pool.size; i++)
            {
                GameObject go = Instantiate(pool.prefabs);
                go.SetActive(false);
                objectPool.Enqueue(go);
            }

            dictionaryPool.Add(pool.tag, objectPool);
        }
    }

    public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation)
    {
        if (!dictionaryPool.ContainsKey(tag))
        {
            return null;
        }

        GameObject objectFromPool = dictionaryPool[tag].Dequeue();

        objectFromPool.SetActive(true);
        objectFromPool.transform.position = position;
        objectFromPool.transform.rotation = rotation;

        dictionaryPool[tag].Enqueue(objectFromPool);

        return objectFromPool;

    }
}
