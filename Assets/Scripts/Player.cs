using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class Player : MonoBehaviour
{
    public float jumpForce = 8.0f;
    public Rigidbody2D rigid;
    public bool isFalling = true;
    public float speed = 5.0f;
    public LayerMask groundLayer;
    public Transform feetPos;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Collider2D hit = Physics2D.OverlapCircle(feetPos.position, 0.2f, groundLayer);

        isFalling = (hit) ? false : true;

        if (!isFalling)
        {
            if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.W))
            {
                rigid.velocity = new Vector2(rigid.velocity.x, 0f);
                rigid.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            }
        }
        
        rigid.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, rigid.velocity.y);
    }
}