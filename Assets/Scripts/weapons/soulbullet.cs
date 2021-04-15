using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soulbullet : bullet
{
    public GameObject player;
    private bool inAir = true;

    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.GetComponent<hittable>()) {
            collision.gameObject.GetComponent<hittable>().spawnHitParticles(collision);
        }

        if (collision.gameObject.name.Contains("enemy") && inAir == true)
        {
            inAir = false;
            GameObject newWeapon = collision.gameObject.GetComponent<enemy>().GetWeapon();
            player.GetComponent<PlayerStateManager>().RegainSoulCharge();
            player.GetComponent<PlayerStateManager>().ResetAmmoToTotal();
            player.GetComponent<PlayerStateManager>().GetWeapon(newWeapon);
            Die();
        }
       
        if (collision.gameObject.Equals(player))
        {
            Debug.Log("Soul bullet picked up by Player");
            player.GetComponent<PlayerStateManager>().RegainSoulCharge();
            Die();
        }

        Debug.Log(collision.gameObject.name);
        inAir = false;
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
        Physics2D.IgnoreCollision(this.GetComponent<Collider2D>(), player.GetComponent<Collider2D>(), false);

    }

}
