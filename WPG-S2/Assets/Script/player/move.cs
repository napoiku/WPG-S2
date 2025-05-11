using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    private float horizontal;
    private float vertical;
    private float speed = 30f;
    private Animator animator;

    [SerializeField] private Rigidbody2D rb;

    void Start()
    {
        animator = GetComponent<Animator>();
    }
    void FixedUpdate ()
    {
        rb.velocity = new Vector2(horizontal * speed, vertical * speed);
    }
    
    void Update ()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        if (horizontal != 0 || vertical != 0) {
            animator.SetBool("IsWalking", true);
        } 
        else if(horizontal == 0 && vertical == 0) {
            animator.SetBool("IsWalking", false);
        }

        animator.SetFloat("InputX", horizontal);
        animator.SetFloat("InputY", vertical);

    }
}
