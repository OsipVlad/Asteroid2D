
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Asteroid2D
{
    internal class AsteroidController: IController, IUpdatable
    {


        private AsteroidView _view;
        private IAsteroidFactory _ifactory;

        private float trajectoriVariance = 15.0f;

        private float spawnTimer = 2.0f;
        private int spawnAmount = 1;
        private float spawnDistance = 12.0f;

        public AsteroidController(AsteroidView asteroidView)
        {

            _view = asteroidView;
            _ifactory = new AsteroidFactory(_view);
            spawnTimer = asteroidView.spawnRate;
        }
        public void Tick(float delaTime)
        {
            spawnTimer -= delaTime;
            if(spawnTimer < 0)
            {
                SpawnAsteroids();
                spawnTimer = _view.spawnRate;
            }
            
        }
        private void SpawnAsteroids()
        {
            for (int i = 0; i < this.spawnAmount; i++)
            {
                var asteroidModel = _ifactory.CreateAsteroid();
                Vector3 spawnDirection = Random.insideUnitCircle.normalized * spawnDistance;
                asteroidModel.AsteroidObject.transform.position += spawnDirection;

                float variance = Random.Range(-this.trajectoriVariance, this.trajectoriVariance);
                Quaternion rotation = Quaternion.AngleAxis(variance, Vector3.forward);
                asteroidModel.AsteroidObject.transform.rotation = rotation;
                
                SetTrajectory(rotation * -spawnDirection, asteroidModel);

            }
        }
        public void SetTrajectory(Vector2 direction, AsteroidModel asteroidModel)
        {
            asteroidModel.AsteroidObject.GetComponent<Rigidbody2D>().AddForce(direction * _view.speed);

            GameObject.Destroy(asteroidModel.AsteroidObject, _view.maxLiveTime);
        }

    }
}
