using System;
using UnityEngine;

namespace Asteroid2D
{
    internal class EnemyController : IController, IUpdatable
    {
        private EnemyView _view;
        private IEnemyFactory _ifactory;

        private float spawnTimer = 2.0f;
        private int spawnAmount = 1;
        private float spawnDistance = 15.0f;

        public EnemyController(EnemyView enemyView)
        {

            _view = enemyView;
            _ifactory = new EnemyFactory(_view);
            spawnTimer = enemyView.spawnRate;
        }

        public void Tick(float delaTime)
        {
            spawnTimer -= delaTime;
            if (spawnTimer < 0)
            {
                SpawnEnemy();
                spawnTimer = _view.spawnRate;
            }

        }

        private void SpawnEnemy()
        {
            throw new NotImplementedException();
        }
    }
}
