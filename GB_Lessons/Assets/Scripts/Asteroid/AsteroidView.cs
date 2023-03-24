using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Asteroid2D
{
    [Serializable]
    public struct AsteroidView
    {
        public GameObject _asteroidPrefab;
        public Sprite[] Sprites;
        public float size;
        public float minSize;
        public float maxSize;
        public float spawnRate;
        public float speed;
        public float maxLiveTime;
    }
}
