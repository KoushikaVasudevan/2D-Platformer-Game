using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Button))]
public class LevelLoader : MonoBehaviour
{
    private Button button;
    public string LevelName;

    public GameObject LevelLockedPopup;

    private void Awake()
    {
        LevelLockedPopup.SetActive(false);
        button = GetComponent<Button>();
        button.onClick.AddListener(onClick);
    }

    /*void OnGUI()
    {
        //Delete all of the PlayerPrefs settings by pressing this button.
        if (GUI.Button(new Rect(100, 200, 200, 60), "Delete"))
        {
            PlayerPrefs.DeleteAll();
        }
    }*/

    private void onClick()
    {
        if(gameObject.tag == "Ok-UIButton")
        {
            LevelLockedPopup.SetActive(false);
        }
        else if (gameObject.tag != "Ok-UIButton")
        {
            LevelStatus levelstatus = LevelManager.Instance.GetLevelStatus(LevelName);
            switch (levelstatus)
            {
                case LevelStatus.Locked:
                    Debug.Log("The level has to be unlocked");
                    LevelLockedPopup.SetActive(true);
                    break;

                case LevelStatus.Unlocked:
                    SceneManager.LoadScene(LevelName);
                    break;

                case LevelStatus.Completed:
                    SceneManager.LoadScene(LevelName);
                    break;
            }

        }
        
    }
}
