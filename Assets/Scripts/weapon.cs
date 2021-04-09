using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//base weapon class
//equipable by enemies and player
//probably has a rigidbody and collidor when dropped
//when equiped disable rigidbody and collider things.
//not sure how orientation will work exactly, but I want the equipper to decide how to orient the weapon, such that the same weapon can be used in a variety of positions on different shaped enemies.
//e.g. a behemoth will carry a sword differently than a humanoid.

//still not sure if game logic and display logic are tied here.
// especially once we tie in animation

//weapons are throwable

public class weapon : MonoBehaviour {
    public int baseDamage;
    public int shootRate;
    public int swingRate;
    private int shootInterval;
    private int swingInterval;


    public void Shoot() {
        
    }

    public void Swing() {

    }
}