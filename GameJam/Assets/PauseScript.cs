using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{
    public static bool gameIsPaused;
    public GameObject PauseMenu;
    public GameObject PauseButtons;
    public GameObject AudioButtons;
    public GameObject ControlButtons;

    public void ResumeButton()
    {
        Time.timeScale = 1f;
        gameIsPaused = false;
        PauseMenu.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void QuitButton()
    {
        Application.Quit();
    }

    public void ControlsButton()
    {
        PauseButtons.SetActive(false);
        ControlButtons.SetActive(true);
    }

    public void AudioButton()
    {
        PauseButtons.SetActive(false);
        AudioButtons.SetActive(true);
    }

    public void BackButton()
    {
        ControlButtons.SetActive(false);
        AudioButtons.SetActive(false);
        PauseButtons.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            gameIsPaused = !gameIsPaused;
            PauseGame();
        }
    }

    void PauseGame()
    {
        if (gameIsPaused)
        {
            PauseMenu.SetActive(true);
            Time.timeScale = 0f;
           
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            PauseMenu.SetActive(false);
            Time.timeScale = 1f;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}
