using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScreenSetUp : MonoBehaviour
{
    // Start is called before the first frame update
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
