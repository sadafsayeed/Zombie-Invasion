using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Background : MonoBehaviour
{
    public int maxhealth;
    int currentHealth;
    public int health { get { return currentHealth; } }

    void Start()
    {
        currentHealth = maxhealth;
    }

    public void ChangeHealth(int amount)
    {
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxhealth);
        UIHandler.instance.SetHealthValue(currentHealth / (float)maxhealth);
        Debug.Log(currentHealth);

        if (currentHealth == 0)
        {
            SceneManager.LoadScene("EndScreenLose");
        }
    }



    
}
