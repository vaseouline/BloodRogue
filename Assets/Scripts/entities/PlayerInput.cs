using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private PlayerStateManager playerState;
    public Camera cam;

    private InputMaster controls;

    void Awake() {
        controls = new InputMaster();
        controls.Player.Shoot.performed += _ => playerState.RequestShootWeapon();
        controls.Player.Extraction.performed += _ => playerState.RequestSoulCharge();
        controls.Player.Dash.performed += ctx => playerState.RequestDash();
    }

    void OnEnable() {
        controls.Enable();
    }

    void OnDisable() {
        controls.Disable();
    }


    void Start()
    {
        playerState = gameObject.GetComponent<PlayerStateManager>();
        
    }

    void Update()
    {
        
        
    }

    void FixedUpdate()
    {
        var look = cam.ScreenToWorldPoint(controls.Player.Look.ReadValue<Vector2>());
        var movement = controls.Player.Move.ReadValue<Vector2>();
        
        playerState.RequestPlayerAngle(look);
        playerState.RequestMove(movement);
    }

    
}
