using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelOverController : MonoBehaviour
{
    private Scene currentScene;

    public GameObject LevelOverScreen;

    private void Start()
    {
        currentScene = SceneManager.GetActiveScene();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<PlayerController>() != null)
        {
            //level is over
            Debug.Log("Level finished by the player");

            LevelCompleted();
        }
    }

    private void LevelCompleted()
    {
        if(currentScene.name != "Level4")
        {
            LevelManager.Instance.MarkCurrentLevelComplete();
        }
        
        LevelOverScreen.SetActive(true);
        
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(currentScene.buildIndex + 1);
    }
}
