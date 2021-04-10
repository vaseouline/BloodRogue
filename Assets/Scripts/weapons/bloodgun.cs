using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bloodgun : pistol {

    public int selfDmg;
    override public bool Shoot(Vector2 heldPosition) {
        this.equipper.GetComponent<entity>().TakeDamage(selfDmg);
        print(this.shootInterval);
        return base.Shoot(heldPosition);
    }

}