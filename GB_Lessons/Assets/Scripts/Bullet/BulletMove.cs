using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroid2D
{
    public class BulletMove : MonoBehaviour
    {


        private void OnCollisionEnter2D(Collision2D collision)
        {
            if(collision.gameObject.tag == "Enemy" && collision.gameObject.tag == "Bullet")
            {
                Destroy(collision.gameObject);
            }
        }
        
    }
}
