using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroid2D
{

    public class PoolObject: MonoBehaviour
    {
        public void ReturnToPool()
        {
            gameObject.SetActive(false);
        }
    }
}
