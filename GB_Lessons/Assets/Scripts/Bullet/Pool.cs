using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroid2D
{
    [System.Serializable]
    public class PoolItem
    {
        public GameObject _prefab;
        public int _amount;
    }
    public class Pool : MonoBehaviour
    {
        public static Pool singleton;
        public List<PoolItem> items;
        public List<GameObject> pooledItems;

        private void Awake()
        {
            singleton = this;
        }
        void Start()
        {
            pooledItems = new List<GameObject>();
            foreach (PoolItem item in items)
            {
                for (int i = 0; i < item._amount; i++)
                {
                    GameObject obj = Instantiate(item._prefab);
                    obj.SetActive(false);
                    pooledItems.Add(obj);
                }
            }
        }

        public GameObject Get(string tag)
        {
            for(int i = 0; i < pooledItems.Count; i++)
            {
                if (!pooledItems[i].activeInHierarchy && pooledItems[i].tag == tag)
                {
                    return pooledItems[i];
                }
            }
            return null;
        }

        
    }
}