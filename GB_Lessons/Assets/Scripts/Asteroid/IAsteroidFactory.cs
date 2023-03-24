using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Asteroid2D
{
    internal interface IAsteroidFactory
    {
        AsteroidModel CreateAsteroid();
    }
}
