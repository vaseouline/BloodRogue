using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bloodgun : pistol {

    public int selfDmg;

    new void Start() {
        base.Start();
    }
    override public bool Shoot(Vector2 heldPosition) {
        this.equiper.GetComponent<entity>().TakeDamage(selfDmg);
        return base.Shoot(heldPosition);
    }

}