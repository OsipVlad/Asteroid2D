using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroid2D
{
    [Serializable]
    public struct EnemyView
    {
        public GameObject _enemyPrefab;
        public Sprite[] Sprites;
        public float size;
        public float spawnRate;
        public float fireRate;
        public float speed;
        
    }
}
