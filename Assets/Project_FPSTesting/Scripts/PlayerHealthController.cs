using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    public static PlayerHealthController instance;
    public int maxHealth, currentHealth;
    public float graceLength = 1f;
    private float graceCounter;

    void Awake()
    {
        instance = this;
    }
    void Start()
    {
        currentHealth = maxHealth;
        UIController.instance.healthSlider.maxValue = maxHealth;
        UIController.instance.healthSlider.value = currentHealth;
        UIController.instance.healthText.text = "Health: " + currentHealth + "/" + maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (graceCounter > 0)
        {
            graceCounter -= Time.deltaTime;
        }
    }

    public void DamagePlayer(int dmgAmount)
    {
        if (graceCounter <= 0)
        {
            currentHealth -= dmgAmount;

            if (currentHealth <= 0)
            {
                gameObject.SetActive(false);

                currentHealth = 0;

                GameManager.instance.PlayerDied();
            }

            graceCounter = graceLength;
            UIController.instance.healthSlider.value = currentHealth;
            UIController.instance.healthText.text = "Health: " + currentHealth + "/" + maxHealth;
        }
    }
}
