using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;

    Rigidbody2D rb;
    Animator animator;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        Vector2 vel = new Vector2(x, y);

        if (vel.magnitude != 0)
        {
            animator.SetBool("isMoving", true);
            animator.SetFloat("X", x);
            animator.SetFloat("Y", y);
        }
        else
        {
            animator.SetBool("isMoving", false);
        }

        rb.velocity = new Vector2(x, y) * speed; 
    }
}
