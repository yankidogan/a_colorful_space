using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public Button resume;
    public Button mainMenu;
    public Button restart;
    public Canvas pauseCanvas;
    public bool isPaused;
    public GameObject ship;

    void Start()
    {
        resume.onClick.AddListener(ResumeEvent);
        mainMenu.onClick.AddListener(MMenuEvent);
        restart.onClick.AddListener(RestartEvent);
        isPaused = false;
        pauseCanvas.gameObject.SetActive(isPaused);
    }

    void Update()
    {
        pauseCanvas.gameObject.SetActive(isPaused);
        ship.transform.gameObject.SetActive(!isPaused);
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseEvent();
        }
    }

    void PauseEvent()
    {
        if (!isPaused)
        {
            isPaused = true;
        }

        else
        {
            isPaused = false;
        }
    }

    void ResumeEvent()
    {
        isPaused = false;
    }

    void MMenuEvent()
    {
        SceneManager.LoadScene("MainMenu");
    }

    void RestartEvent()
    {
        SceneManager.LoadScene("Challenge");
    }
}
