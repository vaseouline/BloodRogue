using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public GameObject playerIcon;
    public GameObject hpPrefab;
    public Sprite weaponIcon;

    public GameObject player;

    public Text ammoUI;
    public Text comboUI;

    private List<GameObject> hpList = new List<GameObject>();

    public float spaceBetweenEachHP;
    public Vector3 initalOffset;

    private static UI _UIinstance;

    public static UI Instance { get { return _UIinstance; } }

    private void Awake()
    {
        if (_UIinstance != null && _UIinstance != this)
        {
            Destroy(this.gameObject);
        } else {

            updateHp(player.GetComponent<PlayerStateManager>().health);

            ammoUI.text =  "Ammo: ";
            comboUI.text = "Combo: ";
            _UIinstance = this;

        }
    }

    //Just prototype code of how to handle UI with data given

    //did forloop for hp update just in case player can gain/lose more than 1 hp
    public void updateHp(int hp) {
        //hpUI.text = "HP: " + hp.ToString();
        int diffHp = hp - hpList.Count;
        //Debug.Log("hp diff" + diffHp.ToString());

        //Player gaining Hp
        for(int i = 0; i < diffHp; i ++) {
            Vector3 offset = new Vector3(spaceBetweenEachHP* (i + 1) , 0,0);
            GameObject hpSpawned = Instantiate(hpPrefab, playerIcon.transform.position + offset + initalOffset, this.gameObject.transform.rotation);
            hpSpawned.gameObject.GetComponent<Animator>().enabled = false;
            hpSpawned.transform.parent = playerIcon.transform;
            hpList.Add(hpSpawned);
        }

        //Player took dmg probably
        for(int i = 0; i > diffHp; i --) {
            GameObject toDelete = hpList[hpList.Count -1];
            hpList.Remove(toDelete);
            toDelete.gameObject.GetComponent<Animator>().enabled = true;
            Destroy (toDelete, toDelete.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
        }

    }

    public void updateCombo(int combo) {
        comboUI.text = "Combo: " + combo.ToString();
    }

    public void updateAmmo(int ammo) {
        ammoUI.text = "Ammo: " + ammo.ToString();

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
