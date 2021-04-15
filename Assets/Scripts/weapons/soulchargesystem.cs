using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class soulchargesystem : weapon {

    public GameObject soulBulletPrefab;
    public float bulletSpeed;
    //public AudioSource soulBulletAudioSource;
    //public AudioClip soulBulletShootSound;

    new void Start() {
        base.Start();
    }
    override public bool Shoot(Vector2 heldPosition) {

        if (shootInterval > 0) {
            return false;
        }
        //TODO either eventually change or otherwise just use pistol.
        Vector2 shootAngle = (Vector2) firingPosition.GetComponent<Transform>().position - heldPosition;
        GameObject bulletInstance = Instantiate(soulBulletPrefab, base.firingPosition.transform.position, this.gameObject.transform.rotation);
        bulletInstance.GetComponent<soulbullet>().damageMod = baseDamage;
        bulletInstance.GetComponent<soulbullet>().player = equipper;
        Physics2D.IgnoreCollision(bulletInstance.GetComponent<Collider2D>(), equipper.GetComponent<Collider2D>());
        bulletInstance.GetComponent<Rigidbody2D>().velocity = shootAngle.normalized * bulletSpeed;
        //soulBulletAudioSource.PlayOneShot(soulBulletShootSound);
        shootInterval = shootRate;
        return true;
    }

    override public bool Swing(Vector2 heldPosition) {
        Debug.Log("Swing!");
        return true;
    }

}
