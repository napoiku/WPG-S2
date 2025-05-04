using UnityEngine;

public class enemy : MonoBehaviour
{
    public Transform player;
    public float movespeed = 5f;
    private Rigidbody2D rb;
    private Vector2 movement;


    // Start is called before the first frame update
    void Start(){ 
        rb = this.GetComponent<Rigidbody2D>();
        
        GameObject foundPlayer = GameObject.FindGameObjectWithTag("Point");
        if (foundPlayer != null)
        {
            player = foundPlayer.transform;
        }
    }

    // Update is called once per frame
    void Update(){
        Vector3 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
        direction.Normalize();
        movement = direction;
    }
    private void FixedUpdate()
    {
        moveCharakter(movement);
    }
    void moveCharakter(Vector2 direction){
        rb.MovePosition(rb.position + (direction * movespeed * Time.deltaTime));
    }
}
