using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelOverController : MonoBehaviour
{
    private Scene currentScene;

    public GameObject LevelOverScreen;

    public GameObject LevelCompletedEffect;

    public GameObject LightOn;
    public GameObject LightOff;

    private void Start()
    {
        currentScene = SceneManager.GetActiveScene();

        LevelCompletedEffect.SetActive(false);
        LightOff.gameObject.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<PlayerController>() != null)
        {
            //level is over
            Debug.Log("Level finished by the player");

            SoundManager.Instance.Play(SoundManager.Sounds.LevelComplete);

            LevelCompletedEffect.SetActive(true);

            LightOff.gameObject.SetActive(false);
            LightOn.gameObject.SetActive(true);

            LevelCompleted();
        }
    }

    private void LevelCompleted()
    {
        if(currentScene.name != "Level5")
        {
            LevelManager.Instance.MarkCurrentLevelComplete();
        }
        
        LevelOverScreen.SetActive(true);
        
    }

    public void LoadNextScene()
    {
        SoundManager.Instance.Play(SoundManager.Sounds.ButtonClick);
        SceneManager.LoadScene(currentScene.buildIndex + 1);
    }
}
