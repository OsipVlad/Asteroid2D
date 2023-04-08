using UnityEngine;
using UnityEngine.Pool;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Shape _shapePrefab;
    [SerializeField] private int _spawnAmount;
    [SerializeField] private bool _usePool;
    [SerializeField] private int _defaultCapacity = 10;
    [SerializeField] private int _maxCapacity = 30;
    private ObjectPool<Shape> _pool;
    void Start()
    {
        _pool = new ObjectPool<Shape>(() =>
        {
            return Instantiate(_shapePrefab);
        }, shape =>
        {
            shape.gameObject.SetActive(true);
        }, shape =>
        {
            shape.gameObject.SetActive(false);
        }, shape =>
        {
            Destroy(shape.gameObject);
        }, false, _defaultCapacity, _maxCapacity);
        InvokeRepeating(nameof(Spawn), 0.2f, 0.2f);
    }

    private void Spawn()
    {
        for(int i = 0; i < _spawnAmount; i++)
        {
            var shape = _usePool ? _pool.Get(): Instantiate(_shapePrefab);
            shape.transform.position = transform.position + Random.onUnitSphere * 5;
            shape.Init(KillShape);
        }
    }

    private void KillShape(Shape shape)
    {
        if (_usePool) _pool.Release(shape);
        else Destroy(shape.gameObject);
    }



}
