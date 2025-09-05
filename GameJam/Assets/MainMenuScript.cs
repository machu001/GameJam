using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
{
    public GameObject MainButtons;
    public GameObject ControlButtons;
    public GameObject AudioButtons;
    public void StartButton()
    {
        SceneManager.LoadScene(1);
    }

    public void ControlsButton()
    {
        MainButtons.SetActive(false);
        ControlButtons.SetActive(true);
    }

    public void AudioButton()
    {
        MainButtons.SetActive(false);
        AudioButtons.SetActive(true);
    }

    public void BackButton()
    {
        ControlButtons.SetActive(false);
        AudioButtons.SetActive(false);
        MainButtons.SetActive(true);
    }

    public void QuitButton()
    {
        Application.Quit();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
