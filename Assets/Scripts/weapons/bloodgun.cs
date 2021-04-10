using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bloodgun : pistol {

    public int selfDmg;
    override public bool Shoot(Vector2 heldPosition) {
        this.equiper.GetComponent<entity>().TakeDamage(selfDmg);
        print(this.shootInterval);
        return base.Shoot(heldPosition);
    }

}