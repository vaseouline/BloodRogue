using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class bullet : entity
{

    [SerializeField]
    private int baseDamage;
    public int damageMod;
    new void Start() {
        base.Start();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //TODO damage calculation stuff
        int damage = baseDamage + damageMod;
        if (collision.gameObject.name.Contains("enemy"))
        {
            collision.gameObject.GetComponent<entity>().TakeDamage(damage);
            
        }
        if (collision.gameObject.GetComponent<hittable>()) {
            collision.gameObject.GetComponent<hittable>().spawnHitParticles(collision);
        }
        Die(0);
    }
}
