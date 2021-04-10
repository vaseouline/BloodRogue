using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : entity
{
    public float moveSpeed = 5f;

    public Rigidbody2D rb;
    public Camera cam;

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
        Debug.Log("FDSFDGHFSGH");
        bloodgun.SetActive(false);
        currAmmoCount = weapon.GetComponent<weapon>().ammoCount;
        Debug.Log("Starting with" + currAmmoCount.ToString() + " ammo");

    }

    // Update is called once per frame
    new void Update()
    {
        base.Update();
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        var mouse0 = Input.GetMouseButtonDown(0);
        var mouse1 = Input.GetMouseButtonDown(1);
        if (mouse0)
        {
            RequestShootWeapon();
        }
        if (mouse1) {
            RequestSwingWeapon();
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement.normalized * moveSpeed * Time.fixedDeltaTime);
        oldLookDir = newLookDir;
        newLookDir = mousePos - rb.position;
        lookRotation.SetFromToRotation(oldLookDir, newLookDir);
        Vector3 newPosition = rb.position + newLookDir.normalized * armlength;
        handPosition.GetComponent<Transform>().position = newPosition;
        //TODO quaternion still is a bit weird
        handPosition.GetComponent<Transform>().rotation = lookRotation * handPosition.GetComponent<Transform>().rotation;
       
    }

    private void RequestShootWeapon() {
        if (weapon.GetComponent<weapon>().Shoot(handPosition.GetComponent<Transform>().position)) {
            AdjustAmmoCount();
            Debug.Log("shot weapon");
        } else {
            Debug.Log("weapon cooldown");
        }
    }

    private void RequestSwingWeapon() {
        weapon.GetComponent<weapon>().Swing(handPosition.GetComponent<Transform>().position);
    }

    private void GetWeapon(GameObject newWeapon) {
        Debug.Log(newWeapon);

        //Not sure if transferring the weapon directly to the player will be good
        //For now, just creating copy of the enemyweapon that needs to be transferred over to the player
        GameObject createdWeapon = Instantiate(newWeapon, weapon.transform.position, weapon.transform.rotation);
        currAmmoCount = createdWeapon.GetComponent<weapon>().ammoCount;
        createdWeapon.GetComponent<weapon>().equiper = this.gameObject;
        
        //for now transfer over the firing position since there is no prefab for it. (?)
        //GameObject oldfiringPos = weapon.GetComponent<weapon>().firingPosition;
        //GameObject newFiringPosition = Instantiate(oldfiringPos, oldfiringPos.transform.position, oldfiringPos.transform.rotation);
        //newFiringPosition.transform.parent = createdWeapon.transform;        

    }

    private void AdjustAmmoCount(){
        currAmmoCount -= 1;
        Debug.Log(currAmmoCount);
        if(currAmmoCount <= 0){
            Debug.Log("AMMO RAN OUT SWITCHING TO BLOODGUN");
            //GetWeapon(bloodgun);
        }
    }
}
