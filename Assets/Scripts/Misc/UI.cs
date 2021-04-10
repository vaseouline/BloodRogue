using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public Sprite playerIcon;
    public Sprite hpIcon;
    public Sprite weaponIcon;

    //public GameObject player;
    
   

    public void updateHp(int hp) {

    }

    public void updateAmmo(int ammo) {
        

    }

    private void updateWeaponIcon(Sprite icon){

    }
    
    public void updateWeapon(GameObject newWeapon) {
        updateAmmo(newWeapon.GetComponent<weapon>().ammoCount);
        updateWeaponIcon(newWeapon.GetComponent<weapon>().icon);
        
    }

    public void updateConsumable() {

    }
}
