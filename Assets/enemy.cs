using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{

    public GameObject player; 
    // Start is called before the first frame update
    public float moveSpeed;
    public float Health;
    private Collider2D cldr;
    private Rigidbody2D rb;
    private Vector2 movement;
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        cldr = this.gameObject.GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Health <= 0) {
            Destroy(this.gameObject, 0);
        }
        if (player != null) {
            movement = (player.GetComponent<Rigidbody2D>().position - rb.position);
            rb.MovePosition(rb.position + movement.normalized * moveSpeed * Time.fixedDeltaTime);
        }
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //Check for a match with the specified name on any GameObject that collides with your GameObject
        if (collision.gameObject.name.Contains("bullet"))
        {
            //If the GameObject's name matches the one you suggest, output this message in the console
            Debug.Log("Do something here");
            Health -= 10;
            Destroy(collision.gameObject, 0);
        }

        //Check for a match with the specific tag on any GameObject that collides with your GameObject
        if (collision.gameObject.name == "player")
        {
            //If the GameObject has the same tag as specified, output this message in the console
            Debug.Log("Do something else here");
            collision.gameObject.GetComponent<NewBehaviourScript>().Health -= 10;
            
        }
    }
}
