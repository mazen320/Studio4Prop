using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScreenSetUp : MonoBehaviour
{
    private void Start()
    {
        
    Cursor.lockState = CursorLockMode.None;
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
