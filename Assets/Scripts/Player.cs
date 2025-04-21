using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]

public class Player : MonoBehaviour
{
    public float jumpForce = 8.0f;
    public Rigidbody2D rigid;
    public bool isFalling = true;
    public float speed = 5.0f;
    public LayerMask groundLayer;
    public Transform lFoot;
    public Transform rFoot;

    Animator animator;
    SpriteRenderer sprite;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        RaycastHit2D rHit = Physics2D.Raycast(rFoot.position, Vector2.down, 0.1f, groundLayer);
        RaycastHit2D lHit = Physics2D.Raycast(lFoot.position, Vector2.down, 0.1f, groundLayer);
        isFalling = (lHit || rHit) ? false : true;

        if (!isFalling)
        {
            if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.W))
            {
                animator.SetTrigger("Jump");
                rigid.velocity = new Vector2(rigid.velocity.x, 0f);
                rigid.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            }
        }
        
        rigid.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, rigid.velocity.y);

        animator.SetBool("Run", Input.GetAxis("Horizontal") != 0);
        if (Input.GetAxis("Horizontal") != 0) sprite.flipX = Input.GetAxis("Horizontal") < 0;

        if (Input.GetMouseButtonDown(0)) animator.SetTrigger("Attack");
        if (Input.GetMouseButtonDown(1)) animator.SetTrigger("Ability");

        if (Input.GetKeyDown(KeyCode.E)) animator.SetTrigger("Hit");
    }
}