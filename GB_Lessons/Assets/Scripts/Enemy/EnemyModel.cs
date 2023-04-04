using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroid2D
{
    internal class EnemyModel
    {
        private GameObject _gameObject;
        private Rigidbody2D _rigidbody;
        private BoxCollider2D _collider;
        private SpriteRenderer _spriteRenderer;

        public EnemyModel(GameObject enemyObject)
        {
            _gameObject = enemyObject;
            _collider = enemyObject.GetComponent<BoxCollider2D>();
        }

        public GameObject EnemyObject { get => _gameObject; set => _gameObject = value; }
    }
}
