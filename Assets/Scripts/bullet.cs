using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class bullet : entity
{
    public int damage;

    new void Start() {
        base.Start();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //Check for a match with the specified name on any GameObject that collides with your GameObject
        if (collision.gameObject.name.Contains("enemy"))
        {
            collision.gameObject.GetComponent<entity>().TakeDamage(damage);
            
        }
        Die();
    }
}
