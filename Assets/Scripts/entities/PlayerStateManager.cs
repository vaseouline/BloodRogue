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
    public int currSoulAmmoCount;

    public GameObject ability;
    public GameObject consumable;
    private Vector2 currentMovement;
    public bool canControlMovement = true;
    public int ammoChargeCountTotal = 10;
    private int _ammoChargeCountCurrent;
    private int ammoChargeCountCurrent {
        get { return _ammoChargeCountCurrent; }
        set {
            _ammoChargeCountCurrent = value;
            if(_ammoChargeCountCurrent <= 0) 
            {
                _ammoChargeCountCurrent = 0; // force zero as min value
            }
        }

    }
    
    public dashSystem dash; 
    

    // Start is called before the first frame update
    new void Start()
    {
       
        //Instantiate()
        //this is only so player can instantiate a copy when needed.
        base.Start();
        Debug.Log("Starting with" + ammoChargeCountTotal.ToString() + " ammo");
        //health = 6;

    }

    // Update is called once per frame
    new void Update()
    {

    }

    void FixedUpdate()
    {
       
    }

    public void RequestMove(Vector2 direction) {
        currentMovement = direction.normalized;
        if (direction.sqrMagnitude < 0.01) {
            currentMovement = Vector2.zero;
            return;
        }
        
        var scaledMoveSpeed = moveSpeed * Time.fixedDeltaTime;
        if (canControlMovement) {
            rb.MovePosition(rb.position + direction.normalized * scaledMoveSpeed);
        }
    }

    public void RequestPlayerAngle(Vector2 mousePos) {
        float angle = Utilities.AngleBetweenTwoPoints(mousePos, rb.position);
        rb.rotation = angle;

        float handAngle =  Utilities.AngleBetweenTwoPoints(mousePos, handPosition.GetComponent<Transform>().position);
        handPosition.GetComponent<Transform>().rotation = Quaternion.Euler (new Vector3(0f,0f,handAngle));
    }

    public void RequestShootWeapon() {
        if (ammoChargeCountCurrent > 0) {
            if (weapon.GetComponent<weapon>().Shoot(handPosition.GetComponent<Transform>().position)) {
                SubtractAmmoCount(weapon.GetComponent<weapon>().ammoCostPerShot);
                Debug.Log("shot weapon");
            } else {
                Debug.Log("weapon cooldown");
            }
        } else {
            Debug.Log("Out of ammo");
        }

        
    }

    public void RequestSwingWeapon() {
        weapon.GetComponent<weapon>().Swing(handPosition.GetComponent<Transform>().position);
    }

    public bool RequestSoulCharge() {
        //TODO rework weapon ownership and handling
        if (currSoulAmmoCount <= 0) {
            Debug.Log("Out of soul charge");
            return false;
        }
        if (soulweapon.GetComponent<weapon>().Shoot(handPosition.GetComponent<Transform>().position)) {
            currSoulAmmoCount -=1;
        }
        return true;
    }

    public void GetWeapon(GameObject newWeapon) {
        Debug.Log(newWeapon);
        GameObject createdWeapon = InitializeWeapon(newWeapon);
        SwitchWeapon(createdWeapon);
    }

    private GameObject InitializeWeapon(GameObject newWeapon) {
        GameObject createdWeapon = Instantiate(newWeapon, weapon.transform.position, weapon.transform.rotation);
        createdWeapon.GetComponent<weapon>().equipper = this.gameObject;
        return createdWeapon;
    }

    private void SwitchWeapon(GameObject createdWeapon) {
        Destroy(weapon);
        weapon = createdWeapon;

        createdWeapon.transform.parent = handPosition.transform;
        Vector3 calc = Utilities.MatrixMultiplication(this.transform.localScale, handPosition.transform.localScale);
        createdWeapon.transform.localScale = Utilities.MatrixMultiplication(createdWeapon.transform.localScale, calc);
    }

    private void SubtractAmmoCount(int ammoCost){
        ammoChargeCountCurrent -= ammoCost;
        //userInterface.GetComponent<UI>().updateAmmo(currAmmoCount);
        Debug.Log("current ammo: " + ammoChargeCountCurrent);
    }

    public void ResetAmmoToTotal() {
        ammoChargeCountCurrent = ammoChargeCountTotal;
        Debug.Log("Reset! current ammo: " + ammoChargeCountCurrent);
    }

    public void IncreaseAmmoTotal() {
        ammoChargeCountTotal += 1;
        ammoChargeCountCurrent += 1;//maybe remove this. only weird case, is if you have 0 ammo, and pick this up, it gives you an extra shot. It might be good for split second choices/increasing combos
    }

    public void RegainSoulCharge(){
        currSoulAmmoCount +=1;
    }

    public void RequestDash() {
        dash.Dash(currentMovement);
    }

}
