using UnityEngine;
using UnityEngine.UI;

namespace Asteroid2D
{
    internal sealed class EnemyFactory : IEnemyFactory
    {
        private EnemyView _view;
        public EnemyFactory(EnemyView view)
        {
            _view = view;
        }

        public EnemyModel CreateEnemy()
        {
            return null;
        }
    }
}
