using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int health = 2;
    public GameObject healthBar;
    public Sprite fullHealth;
    public Sprite halfHealth;

    public void TakeDamage()
    {
        if (health > 1)
        {
            healthBar.GetComponent<Image>().sprite = halfHealth;
            health--;
        }
        else
        {
            SceneManager.LoadScene("Lose");
        }
    }

    public void Heal()
    {
        health = 2;
        healthBar.GetComponent<Image>().sprite = fullHealth;
    }
}
