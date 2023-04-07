using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private int lives = 3;
    [SerializeField] private float respawnTime = 3.0f;
    public void OnEnable()
    {
        PlayerInfo.onPlayerEvent += PlayerDead;
    }

    public void PlayerDead()
    {
        
        this.lives--;

        if (lives <= 0)
        {
            GameOver();
        }
        else
        {
            player.SetActive(false);
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
        Debug.Log("Game Over\nYou Dead");
    }
}
