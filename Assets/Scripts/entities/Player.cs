using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : entity
{
    public float moveSpeed = 5f;

    public Rigidbody2D rb;

    Vector2 movement;
    Vector2 mousePos;
    
    //This is going to be currentweapon player is holding that can be swapped
    public GameObject weapon;

    private Vector2 lookDir;
    public GameObject handPosition;
    private Vector2 oldLookDir;
    private Vector2 newLookDir;
    private Quaternion lookRotation;
    public float armlength;

    private int currAmmoCount;
    public GameObject bloodgun;
    public GameObject ability;
    public GameObject consumable;

    // Start is called before the first frame update
    new void Start()
    {
       
        //Instantiate()
        //this is only so player can instantiate a copy when needed.
        base.Start();
        bloodgun.SetActive(false);
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
        rb.MovePosition(rb.position + movement.normalized * moveSpeed * Time.fixedDeltaTime);
        float angle = Utilities.AngleBetweenTwoPoints(mousePos, rb.position);
        newLookDir = (mousePos - rb.position).normalized;
        Vector3 newPosition = rb.position + newLookDir * armlength;
        handPosition.GetComponent<Transform>().position = newPosition;
        handPosition.GetComponent<Transform>().rotation = Quaternion.Euler (new Vector3(0f,0f,angle));
       
    }

    public void RequestShootWeapon() {
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

    private void GetWeapon(GameObject newWeapon) {
        Debug.Log(newWeapon);

        //Not sure if transferring the weapon directly to the player will be good
        //For now, just creating copy of the enemyweapon that needs to be transferred over to the player
        GameObject createdWeapon = Instantiate(newWeapon, weapon.transform.position, weapon.transform.rotation);
        currAmmoCount = createdWeapon.GetComponent<weapon>().ammoCount;
        createdWeapon.GetComponent<weapon>().equipper = this.gameObject;
        
        DestroyImmediate(weapon);
        weapon = createdWeapon;
        createdWeapon.transform.parent = handPosition.transform;
        //weapon.transform.parent = handPosition.transform;
        Vector3 calc = Utilities.MatrixMultiplication(this.transform.localScale, handPosition.transform.localScale);
        createdWeapon.transform.localScale = Utilities.MatrixMultiplication(createdWeapon.transform.localScale, calc);

        Debug.Log(calc);

    }

    private void AdjustAmmoCount(){
        currAmmoCount -= 1;
        //userInterface.GetComponent<UI>().updateAmmo(currAmmoCount);
        Debug.Log(currAmmoCount);
        if(currAmmoCount <= 0){
            Debug.Log("AMMO RAN OUT SWITCHING TO BLOODGUN");
            bloodgun.SetActive(true);
            GetWeapon(bloodgun);
        }
    }

}
