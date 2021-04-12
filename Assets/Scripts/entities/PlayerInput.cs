using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private PlayerStateManager playerState;
    Vector2 movement;
    Vector2 mousePos;
    public Camera cam;

    
    private Vector2 oldLookDir;
    private Vector2 newLookDir; 

    void Start()
    {
        playerState = gameObject.GetComponent<PlayerStateManager>();
        
    }

    void Update()
    {
        takeInput();
    }

    void FixedUpdate()
    {
        playerState.RequestMove(movement);
        playerState.RequestPlayerAngle(mousePos);
    }


    private void takeInput() {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        var mouse0 = Input.GetMouseButtonDown(0);
        var mouse1 = Input.GetMouseButtonDown(1);
        if (mouse0)
        {
            playerState.RequestShootWeapon();
        }
        if (mouse1) {
            playerState.RequestSwingWeapon();
        }
    }

}
