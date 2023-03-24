using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Asteroid2D
{
    internal class AsteroidModel
    {
        private GameObject _gameObject;
        private Rigidbody2D _rigidbody;
        private BoxCollider2D _collider;
        private SpriteRenderer _spriteRenderer;

        public AsteroidModel(GameObject asteroidObject)
        {
            _gameObject= asteroidObject;
            _collider = asteroidObject.GetComponent<BoxCollider2D>();
        }

        public GameObject AsteroidObject { get => _gameObject; set => _gameObject = value; }
        
        public void CheckCollision()
        {
            //Physics2D.OverlapBox();
        }

    }
}
