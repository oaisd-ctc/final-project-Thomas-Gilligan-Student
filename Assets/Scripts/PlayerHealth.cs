using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int health = 5;
    public GameObject healthBar;
    public Sprite[] healthSprites;
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
        if (health > 0)
        {
            health--;
            healthBar.GetComponent<Image>().sprite = healthSprites[health - 1];
            rigid.velocity *= Vector2.down;
        }
        else
        {
            SceneManager.LoadScene("Lose");
        }
    }

    public void Heal(int num = 1)
    {
        health += num;
        if (health > 5) health = 5;
        healthBar.GetComponent<Image>().sprite = healthSprites[health - 1];
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
        else if (other.gameObject.tag == "Jam")
        {
            Destroy(other.gameObject);
            Heal(3);
        }
    }
}
