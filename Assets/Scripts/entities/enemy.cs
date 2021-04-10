using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : entity
{

    public GameObject player; 
    // Start is called before the first frame update
    public float moveSpeed;
    private Collider2D cldr;
    private Rigidbody2D rb;
    private Vector2 movement;
    public int damage;
    new void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        cldr = this.gameObject.GetComponent<Collider2D>();
    }

    // Update is called once per frame
    new void Update()
    {
        base.Update();
        if (player != null) {
            movement = (player.GetComponent<Rigidbody2D>().position - rb.position);
            rb.MovePosition(rb.position + movement.normalized * moveSpeed * Time.fixedDeltaTime);
        }
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //Check for a match with the specific tag on any GameObject that collides with your GameObject
        if (collision.gameObject.name.Contains("player"))
        {
            
            collision.gameObject.GetComponent<entity>().TakeDamage(damage);
        }
    }
}
