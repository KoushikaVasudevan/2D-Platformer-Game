using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerDied : MonoBehaviour
{
    public GameObject gameOverCanvas;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<PlayerController>() != null)
        {
            Debug.Log("Player died");

            gameOverCanvas.gameObject.SetActive(true);
            //restartButton.gameObject.SetActive(true);
            //gameOverText.gameObject.SetActive(true);
}
    }

    public void RestartScene()
    {
        gameOverCanvas.gameObject.SetActive(false);
        //restartButton.gameObject.SetActive(false);
        //gameOverText.gameObject.SetActive(false);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
