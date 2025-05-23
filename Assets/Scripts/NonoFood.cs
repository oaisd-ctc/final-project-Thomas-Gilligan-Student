using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonoFood : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            other.gameObject.GetComponent<PlayerHealth>().TakeDamage();
            Destroy(this.gameObject);
        }
    }
}
