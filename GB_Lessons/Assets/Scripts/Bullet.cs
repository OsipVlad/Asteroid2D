using UnityEngine;

namespace Asteroid2D
{
    public class Bullet : MonoBehaviour
    {
        private Rigidbody2D _rigidbody;

        public float speed = 500.0f;
        public float maxLiveTime = 10.0f;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        public void Project(Vector2 direction)
        {
            _rigidbody.AddForce(direction * this.speed);
            Destroy(this.gameObject, this.maxLiveTime);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            Destroy(this.gameObject);
        }
    }
}
