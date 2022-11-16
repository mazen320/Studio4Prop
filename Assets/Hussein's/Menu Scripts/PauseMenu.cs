using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public GameObject pauseMenu;
    // public GameObject HUD;
    // public GameObject Cam;
    public GameObject SplitScreen;

    public bool isPaused;
    void Start()
    {
        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPaused)
            {
                PauseGame();
                Cursor.lockState = CursorLockMode.Confined;
                SplitScreen.SetActive(false);
                //HUD.SetActive(false);
                //Cam.GetComponent<CameraController>().enabled = false;
            }
            else if (isPaused)
            {
                ResumeGame();
                Cursor.lockState = CursorLockMode.Locked;
                SplitScreen.SetActive(true);




            }
        }
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
        // HUD.SetActive(true);
        // Cam.GetComponent<CameraController>().enabled = true;
    }

    public void RestartLevel()
    {
        string levelName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(levelName);
        ResumeGame();
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("HusseinScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
