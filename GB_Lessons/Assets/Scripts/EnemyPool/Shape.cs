using System;
using UnityEngine;
using UnityEngine.Pool;
using Random = UnityEngine.Random;

public class Shape: MonoBehaviour
{
    private Action<Shape> _killAction;

    public void Init(Action<Shape> killAction)
    {
        _killAction = killAction;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.CompareTag("Asteroid") || collision.transform.CompareTag("Ground"))  _killAction(this);
    }
}

