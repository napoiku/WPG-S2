using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    public AudioSource audioSource;

    private float horizontal;
    private float vertical;
    public float speed = 70f;
    private Animator animator;

    [SerializeField] private Rigidbody2D rb;

    void Start()
    {
        animator = GetComponent<Animator>();
    }
    void FixedUpdate()
    {
        if(horizontal != 0 && vertical != 0) {
            rb.velocity = new Vector2(horizontal * speed/1.4f, vertical * speed/1.4f);
        } else {
            rb.velocity = new Vector2(horizontal * speed, vertical * speed);
        }

        if (rb.velocity.x != 0 || rb.velocity.y != 0)
        {
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
        else
        {
            if (audioSource.isPlaying)
            {
                audioSource.Stop();
            }
        }
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
