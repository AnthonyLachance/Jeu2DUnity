using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;

    public GameObject pauseMenuUI;

    public GameObject settingsWindow;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused)
            {
                Resume();
            }
            else
            {
                Paused();
            }
        }
    }

    public void Paused()
    {
        PlayerMovement.instance.enabled = false;
        // activer notre menu de pause
        pauseMenuUI.SetActive(true);
        // arreter le temps
        Time.timeScale = 0;
        // Changer le statut du jeu
        gameIsPaused = true;
    }

    public void Resume()
    {
        PlayerMovement.instance.enabled = true;
        // desactiver notre menu de pause
        pauseMenuUI.SetActive(false);
        // reprendre le temps
        Time.timeScale = 1;
        // Changer le statut du jeu
        gameIsPaused = false;
    }

    public void LoadMainMenu()
    {      
        Resume();
        SceneManager.LoadScene("MainMenu");
    }

    public void OpenSettingsWindow()
    {
        settingsWindow.SetActive(true);
    }

    public void CloseSettingsWindow()
    {
        settingsWindow.SetActive(false);
    }
}
