using Asteroid2D;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainController : MonoBehaviour
{
    [SerializeField] public AsteroidView asteroidView;
    [SerializeField] public EnemyView enemyView;
    
    private AsteroidController asteroidController;
    private EnemyController enemyController;
    void Start()
    {
        asteroidController = new AsteroidController(asteroidView);
        enemyController = new EnemyController(enemyView);
    }

    void Update()
    {
        asteroidController.Tick(Time.deltaTime);
    }

    
}
