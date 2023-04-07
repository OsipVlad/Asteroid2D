using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroid2D
{
    public class DestroyObject: PlayerController
    {
        private void OnBecameInvisible()
        {
            this.gameObject.SetActive(false);
        }
    }
}
