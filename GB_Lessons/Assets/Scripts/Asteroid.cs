using System.Drawing;
using UnityEngine;
using UnityEngine.UI;

public class Asteroid : MonoBehaviour
{
    [SerializeField] private Sprite[] sprites;


    public float MinSize { get => minSize; set => minSize = value; }
    public float MaxSize { get => maxSize; set => maxSize = value; }
    public float Size { get => size; set => size = value; }

    [SerializeField] private float size = 1.0f;
    [SerializeField] private float minSize = 0.5f;
    [SerializeField] private float maxSize = 1.5f;

    [SerializeField] private float speed = 50.0f;
    [SerializeField] private float maxLiveTime = 30.0f;

    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rigidbody;
    

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        _spriteRenderer.sprite = sprites[Random.Range(0, sprites.Length)];

        this.transform.eulerAngles = new Vector3(0.0f, 0.0f, Random.value * 360.0f);
        this.transform.localScale = Vector3.one * this.Size;

        _rigidbody.mass = this.Size;
    }

    public void SetTrajectory(Vector2 direction)
    {
        _rigidbody.AddForce(direction * this.speed);

        Destroy(this.gameObject, this.maxLiveTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            if ((this.Size * 0.5f) >= this.MinSize)
            {
                CreateSplit();
                CreateSplit();
            }
            gameObject.SetActive(false);
        }
        
    }

    private void CreateSplit()
    {
        Vector2 position = this.transform.position;
        position += Random.insideUnitCircle * 0.5f;

        Asteroid half = Instantiate(this, position, this.transform.rotation);
        half.Size = this.Size * 0.5f;
        half.SetTrajectory(Random.insideUnitCircle.normalized * this.speed);
    }


}
