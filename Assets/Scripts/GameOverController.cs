using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();

            playerController.KillPlayer();
        }
    }

    public void PlayerDied()
    {
        SoundManager.Instance.Play(SoundManager.Sounds.PlayerDeath);
        gameObject.SetActive(true);
    }

    public void RestartScene()
    {
        SoundManager.Instance.Play(SoundManager.Sounds.ButtonClick);
        gameObject.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadMenuScene()
    {
        SoundManager.Instance.Play(SoundManager.Sounds.ButtonClick);
        SceneManager.LoadScene(0);
    }
}
