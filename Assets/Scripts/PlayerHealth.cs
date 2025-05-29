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
    float damageTime;
    Rigidbody2D rigid;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    void OnEnable()
    {
        damageTime = Time.time;
    }

    public void TakeDamage()
    {
        if (health > 1)
        {
            healthBar.GetComponent<Image>().sprite = halfHealth;
            health--;
            rigid.velocity *= Vector2.down;
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

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Damage Player")
        {
            if (Time.time >= damageTime + 0.2f)
            {
                damageTime = Time.time;
                TakeDamage();
            }
        }
    }
}
