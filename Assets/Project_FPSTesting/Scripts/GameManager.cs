using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public float waitAfterDeath = 2f;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {

    }

    public void PlayerDied()
    {
        StartCoroutine(PlayerDeathCo());
    }

    public IEnumerator PlayerDeathCo()
    {
        yield return new WaitForSeconds(waitAfterDeath);

        /*
         * This is for respawning temporarily, can change this to any scene you like
         */
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
