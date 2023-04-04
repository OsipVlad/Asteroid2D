using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroid2D
{
    [RequireComponent(typeof(PoolObject))]
    public class Bullet : MonoBehaviour
    {
        
        private Rigidbody2D _rigidbody;
        private PoolObject _poolObject;
        [SerializeField] private float speed = 500.0f;
        [SerializeField] private float maxLiveTime = 10.0f;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _poolObject = GetComponent<PoolObject>();
        }

        //public void Project(Vector2 direction)
        //{
        //    _rigidbody.AddForce(direction * this.speed);
        //    //Destroy(this.gameObject, this.maxLiveTime);
        //}
        private IEnumerator Destroy()
        {
            yield return new WaitForSeconds(maxLiveTime);
            _poolObject.ReturnToPool();
        }
        
    }
}
