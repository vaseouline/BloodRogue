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
    
    public GameObject weapon;
    private Vector2 lookDir;
    public GameObject handPosition;
    private Vector2 oldLookDir;
    private Vector2 newLookDir;
    private Quaternion lookRotation;
    public float armlength;

    // Start is called before the first frame update
    new void Start()
    {


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
            Debug.Log("shot weapon");
        } else {
            Debug.Log("weapon cooldown");
        }
    }

    private void RequestSwingWeapon() {
        weapon.GetComponent<weapon>().Swing(handPosition.GetComponent<Transform>().position);
    }
}
