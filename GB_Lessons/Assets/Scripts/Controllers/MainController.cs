using Asteroid2D;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainController : MonoBehaviour
{
    [SerializeField] public AsteroidView asteroidView;
    
    private AsteroidController asteroidController;
    void Start()
    {
        asteroidController = new AsteroidController(asteroidView);
    }

    void Update()
    {
        asteroidController.Tick(Time.deltaTime);
    }
}
