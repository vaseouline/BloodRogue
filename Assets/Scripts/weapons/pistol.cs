using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pistol : weapon {

    public GameObject bulletPrefab;
    public float bulletSpeed;
    public AudioSource pistolAudioSource;
    public AudioClip pistolShootSound;

    new void Start() {
        base.Start();
    }
    override public bool Shoot(Vector2 heldPosition) {

        if (shootInterval > 0) {
            return false;
        }
        Vector2 shootAngle = (Vector2) firingPosition.GetComponent<Transform>().position - heldPosition;
        GameObject bullet1 = Instantiate(bulletPrefab, base.firingPosition.transform.position, this.gameObject.transform.rotation);
        bullet1.GetComponent<bullet>().damageMod = baseDamage;
        Physics2D.IgnoreCollision(bullet1.GetComponent<Collider2D>(), equipper.GetComponent<Collider2D>());
        bullet1.GetComponent<Rigidbody2D>().velocity = shootAngle.normalized * bulletSpeed;
        pistolAudioSource.PlayOneShot(pistolShootSound);
        shootInterval = shootRate;
        return true;
    }

    override public bool Swing(Vector2 heldPosition) {
        Debug.Log("Swing!");
        return true;
    }

}