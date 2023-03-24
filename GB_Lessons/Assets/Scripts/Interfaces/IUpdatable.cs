using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroid2D
{
    internal interface IUpdatable
    {
        void Tick(float deltaTime);
    }
}
