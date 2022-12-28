using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip audioClip;
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void PlayLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }

    public void QuitGame()
    {
        Metrics.CreateText(); 
        Application.Quit();
    }

    public void playClip()
    {
        audioSource.clip = audioClip;
        audioSource.Play();
    }
    }
