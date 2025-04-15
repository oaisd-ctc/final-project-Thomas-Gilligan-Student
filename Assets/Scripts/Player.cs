using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class Player : MonoBehaviour
{
    public float jumpForce = 6.0f;
    public Rigidbody2D rigid;
    public bool isFalling = true;
    public float speed = 5.0f;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (!isFalling && (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.W)) || Input.GetKey(KeyCode.UpArrow))
        {
            rigid.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
        
        rigid.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, rigid.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isFalling = false;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isFalling = true;
        }
    }
}