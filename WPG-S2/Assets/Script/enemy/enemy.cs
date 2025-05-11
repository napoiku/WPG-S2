using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform target;
    public string targetTag = "Point";
    public Animator animator;

    public float moveSpeed = 10f;
    public float stopDistance = 0.01f; // jarak minimum untuk berhenti

    private Rigidbody2D rb;
    private Vector2 movement;
    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if (target == null && !string.IsNullOrEmpty(targetTag))
        {
            GameObject found = GameObject.FindGameObjectWithTag(targetTag);
            if (found != null)
            {
                target = found.transform;
            }
            else
            {
                Debug.LogWarning("Enemy: Tidak menemukan objek dengan tag: " + targetTag);
            }
        }
    }

    void Update()
    {
        if (target == null) return;

        float distance = Vector2.Distance(transform.position, target.position);

        if (distance > stopDistance)
        {
            Vector3 direction = target.position - transform.position;
            direction.Normalize();
            movement = direction;
        }
        else
        {
            movement = Vector2.zero; // berhenti bergerak
        }
    }

    void FixedUpdate()
    {
        if (movement != Vector2.zero)
        {
            MoveCharacter(movement);
        }
    }

    void MoveCharacter(Vector2 direction)
    {
        rb.MovePosition(rb.position + direction * moveSpeed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Wind"))
        {
            animator.SetTrigger("Destroy");
            Destroy(gameObject,0.25f);
        }
    }
}
