using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class MainMenuController : MonoBehaviour
{
    [Header("Necessary Links")] public IntroManager introManager;

    [FormerlySerializedAs("MainMenuPanel")] [Header("Panels")]
    public GameObject mainMenuPanel;

    [FormerlySerializedAs("howToPlayPanels")]
    public GameObject howToPlayPanel;


    public void HowToPlay()
    {
        mainMenuPanel.SetActive(false);
        howToPlayPanel.SetActive(true);
    }


    public void BackToMainMenu()
    {
        howToPlayPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
    }


    public void QuitGame()
    {
        Debug.Log("Game Exited!");
        Application.Quit();
    }
}