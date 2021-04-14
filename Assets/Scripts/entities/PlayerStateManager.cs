using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateManager : entity
{
    public float moveSpeed = 5f;

    public Rigidbody2D rb;
    
    //This is going to be currentweapon player is holding that can be swapped
    public GameObject weapon;
    public GameObject soulweapon;

    private Vector2 lookDir;
    public GameObject handPosition;
    private Vector2 oldLookDir;
    private Vector2 newLookDir;
    private Quaternion lookRotation;
    public float armlength;

    private int ammoCharge;
    private int currAmmoCount;
    public int currSoulAmmoCount;

    public GameObject ability;
    public GameObject consumable;

    // Start is called before the first frame update
    new void Start()
    {
       
        //Instantiate()
        //this is only so player can instantiate a copy when needed.
        base.Start();
        currAmmoCount = weapon.GetComponent<weapon>().ammoCount;
        Debug.Log("Starting with" + currAmmoCount.ToString() + " ammo");
        Debug.Log(weapon.transform.localScale);
        //health = 6;

    }

    // Update is called once per frame
    new void Update()
    {

    }

    void FixedUpdate()
    {
       
    }

    public void RequestMove(Vector2 movement) {
        rb.MovePosition(rb.position + movement.normalized * moveSpeed * Time.fixedDeltaTime);
    }

    public void RequestPlayerAngle(Vector2 mousePos) {
        float angle = Utilities.AngleBetweenTwoPoints(mousePos, rb.position);
        newLookDir = (mousePos - rb.position).normalized;
        Vector3 newPosition = rb.position + newLookDir * armlength;
        handPosition.GetComponent<Transform>().position = newPosition;
        handPosition.GetComponent<Transform>().rotation = Quaternion.Euler (new Vector3(0f,0f,angle));
    }

    public void RequestShootWeapon() {
        if(currAmmoCount == 0) {
            return;
        }
        if (weapon.GetComponent<weapon>().Shoot(handPosition.GetComponent<Transform>().position)) {
            AdjustAmmoCount();
            Debug.Log("shot weapon");
        } else {
            Debug.Log("weapon cooldown");
        }
    }

    public void RequestSwingWeapon() {
        weapon.GetComponent<weapon>().Swing(handPosition.GetComponent<Transform>().position);
    }

    public void RequestSoulCharge() {
        if (currSoulAmmoCount == 0) {
            return;
        }
        if (soulweapon.GetComponent<weapon>().Shoot(handPosition.GetComponent<Transform>().position)) {
            currSoulAmmoCount -=1;
        }

    }

    public void GetWeapon(GameObject newWeapon) {
        Debug.Log(newWeapon);

        //Not sure if transferring the weapon directly to the player will be good
        //For now, just creating copy of the enemyweapon that needs to be transferred over to the player
        GameObject createdWeapon = Instantiate(newWeapon, weapon.transform.position, weapon.transform.rotation);
        currAmmoCount = createdWeapon.GetComponent<weapon>().ammoCount;
        createdWeapon.GetComponent<weapon>().equipper = this.gameObject;
        
        Destroy(weapon);
        weapon = createdWeapon;

        createdWeapon.transform.parent = handPosition.transform;
        Vector3 calc = Utilities.MatrixMultiplication(this.transform.localScale, handPosition.transform.localScale);
        createdWeapon.transform.localScale = Utilities.MatrixMultiplication(createdWeapon.transform.localScale, calc);

        Debug.Log(calc);

    }

    private void AdjustAmmoCount(){
        currAmmoCount -= 1;
        //userInterface.GetComponent<UI>().updateAmmo(currAmmoCount);
        Debug.Log(currAmmoCount);
        if(currAmmoCount <= 0){
            currAmmoCount = 0;
            Debug.Log("No ammo left");
            //GetWeapon(null);
        }
    }

    public void RegainSoulCharge(){
        currSoulAmmoCount +=1;
    }

}
