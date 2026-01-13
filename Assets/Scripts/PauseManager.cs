using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    [Header("Appointments")] public GameObject pausePanel;


    public static bool PauseGame = false;

    void Start()
    {
        if (pausePanel != null)
            pausePanel.SetActive(false);

        Time.timeScale = 1f;
        PauseGame = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (PauseGame)
            {
                Continue();
            }
            else
            {
                StopGame();
            }
        }
    }

    public void StopGame()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0f;
        PauseGame = true;
    }

    public void Continue()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
        PauseGame = false;
    }

    public void NewGame()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Quit()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main Menu");
    }
}