using UnityEngine;
using System;
public class PlayerInfo : MonoBehaviour
{

    public static Action onPlayerEvent;
    public void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Asteroid"))
        {
            Debug.Log("Damagaaaaa");
        }
        onPlayerEvent?.Invoke();
    }
}
