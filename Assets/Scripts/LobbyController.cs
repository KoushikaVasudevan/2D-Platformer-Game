using UnityEngine;
using UnityEngine.UI;

public class LobbyController : MonoBehaviour
{
    public Button playButton;
    public GameObject LevelSelection;

    private void Awake()
    {
        playButton.onClick.AddListener(PlayGame);
    }

    private void PlayGame()
    {
        SoundManager.Instance.Play(SoundManager.Sounds.ButtonClick);
        LevelSelection.SetActive(true);
    }
}
