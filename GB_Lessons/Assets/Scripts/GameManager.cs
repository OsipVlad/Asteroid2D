using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public int lives = 3;
    public float respawnTime = 3.0f;
    public void PlayerDead()
    {
        this.lives--;

        if(lives <= 0)
        {
            GameOver();
        }
        else
        {
            Invoke(nameof(Respawn), this.respawnTime);

        }

    }

    private void Respawn()
    {
        this.player.transform.position = Vector3.zero;
        player.SetActive(true);
    }


    private void GameOver()
    {

    }
}
