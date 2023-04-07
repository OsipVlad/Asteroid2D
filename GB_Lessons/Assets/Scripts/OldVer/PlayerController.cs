using UnityEngine;

namespace Asteroid2D
{

    public class PlayerController : MonoBehaviour
    {
        [Header("Player Ship")]
        [SerializeField] private GameObject player;
        [SerializeField] private Transform _flame;
        [SerializeField] private float thrustSpeed = 1.0f;
        [SerializeField] private float turnSpeed = 1.0f;
        [Header("Bullet")]
        [SerializeField] private int poolCount = 10;
        [SerializeField] private bool autoExpand = false;
        
        private bool _trusting;
        private float _turnDirection;

        private Rigidbody2D _rigidbody;

        private void Start()
        {
            _rigidbody = player.GetComponent<Rigidbody2D>();
        }

        private void Update()
        {

            _trusting = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow);
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                _turnDirection = 1.0f;
            }
            else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                _turnDirection = -1.0f;
            }
            else
            {
                _turnDirection = 0.0f;
            }

            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                Shoot();
            }
        }

        private void FixedUpdate()
        {
            if (_trusting)
            {
                _rigidbody.AddForce(player.transform.up * this.thrustSpeed);
            }
            if (_turnDirection != 0.0f)
            {
                _rigidbody.AddTorque(_turnDirection * this.turnSpeed);
            }
        }

        private void Shoot()
        {
            GameObject bym = Pool.singleton.Get("Bullet");
            if(bym != null)
            {
                bym.transform.position = player.transform.up;
                bym.SetActive(true);
            }
        }











    }
}
