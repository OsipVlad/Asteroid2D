
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Asteroid2D
{
    internal sealed class AsteroidFactory: IAsteroidFactory
    {
        private AsteroidView _view;
        public AsteroidFactory(AsteroidView view)
        {
            _view = view;
        }
        
        public AsteroidModel CreateAsteroid()
        {
            var asteroidObject = GameObject.Instantiate(_view._asteroidPrefab);
            asteroidObject.GetComponent<SpriteRenderer>().sprite = _view.Sprites[Random.Range(0, _view.Sprites.Length)];
            asteroidObject.AddComponent<BoxCollider2D>();

            asteroidObject.transform.eulerAngles = new Vector3(0.0f, 0.0f, Random.value * 360.0f);
            var size = Random.Range(_view.minSize, _view.maxSize);
            
            asteroidObject.transform.localScale = Vector3.one * size;

            asteroidObject.GetComponent<Rigidbody2D>().mass = size;
            var asteroidModel = new AsteroidModel(asteroidObject);
            return asteroidModel;
        }
    }
}
