using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hittable : MonoBehaviour
{
    public GameObject bulletHitParticles;

//Can put hit sounds here too
    public void spawnHitParticles(Collision2D collision)
    {
        
        GameObject bulletHitParticlesPrefab = Instantiate(bulletHitParticles, collision.GetContact(0).point, Quaternion.LookRotation(collision.GetContact(0).normal));

    }


}
