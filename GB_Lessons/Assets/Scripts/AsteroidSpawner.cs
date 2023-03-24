using UnityEngine;
using UnityEngine.UI;

namespace Asteroid2D
{


    public class AsteroidSpawner : MonoBehaviour
    {
        public Asteroid asteroidPrefab;

        public float trajectoriVariance = 15.0f;

        public float spawnRate = 2.0f;
        public int spawnAmount = 1;
        public float spawnDistance = 12.0f;

        private void Start()
        {
            InvokeRepeating(nameof(Spawn), this.spawnRate, this.spawnRate);
        }

        private void Spawn()
        {
            for (int i = 0; i < this.spawnAmount; i++)
            {
                Vector3 spawnDirection = Random.insideUnitCircle.normalized * this.spawnDistance;
                Vector3 spawnPoint = this.transform.position + spawnDirection;

                float variance = Random.Range(-this.trajectoriVariance, this.trajectoriVariance);
                Quaternion rotation = Quaternion.AngleAxis(variance, Vector3.forward);

                Asteroid asteroid = Instantiate(this.asteroidPrefab, spawnPoint, rotation);
                asteroid.Size = Random.Range(asteroid.MinSize, asteroid.MaxSize);
                asteroid.SetTrajectory(rotation * -spawnDirection);

            }
        }
    }
}