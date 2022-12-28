using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyHealthController : MonoBehaviour
{

    public int currentHealth = 5;


    public void DamageEnemy(int damageAmount)
    {
        currentHealth -= damageAmount;

        if(currentHealth <= 0)
        {
            Destroy(gameObject);
            SceneManager.LoadScene("UI.WinScreenHunter");
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
