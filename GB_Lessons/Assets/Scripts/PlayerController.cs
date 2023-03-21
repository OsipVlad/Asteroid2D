using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Bullet bulletPrefab;
    [SerializeField] private GameObject player;
    [SerializeField] private float thrustSpeed = 1.0f;
    [SerializeField] private float turnSpeed = 1.0f;

    private bool _trusting;
    private float _turnDirection;

    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = player.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _trusting = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow);
        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            _turnDirection = 1.0f;
        }
        else if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            _turnDirection = -1.0f;
        }
        else
        {
            _turnDirection = 0.0f;
        }

        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) 
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
        if(_turnDirection != 0.0f ) 
        {
            _rigidbody.AddTorque(_turnDirection * this.turnSpeed);
        }
    }

    private void Shoot()
    {
        Bullet bullet = Instantiate(this.bulletPrefab, player.transform.position, player.transform.rotation);
        bullet.Project(player.transform.up);
    }











}
