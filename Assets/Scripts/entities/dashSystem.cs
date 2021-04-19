using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dashSystem : MonoBehaviour 
{

    public float dashDuration;
    private Rigidbody2D rb;
    private Vector2 dashDirection;
    public bool isDash;
    private float dashInterval;
    public bool canDash = true;

    public float dashForce;


    void Start() {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        isDash = false;
    }
    public void Dash(Vector2 movement) {
        if (Mathf.Approximately(movement.SqrMagnitude(), 0)) {
            Debug.Log("Need to be moving to Dash. Direction: " + movement);
            return;
        }
        if (canDash && !isDash) {
            isDash = true;
            dashDirection = getDashDirection(movement);
            
            dashInterval = dashDuration;
            Debug.Log("Dashing direction: " + dashDirection);
            this.gameObject.GetComponent<PlayerStateManager>().canControlMovement = false;
        }
    }

    private Vector2 getDashDirection(Vector2 movement) {
        Debug.Log("sqr:" + movement.SqrMagnitude());
        if (Mathf.Approximately(movement.SqrMagnitude(), 0)) {
            return rb.transform.right;
        }
        return movement.normalized;
    }

    void Update() {
        if (isDash) {
            Vector2 dashVelocity = dashDirection * (dashForce);
            rb.AddForce(dashVelocity, 0);
        }
        
    }

    void FixedUpdate() {
        if (isDash && dashInterval > 0) {
            dashInterval--;
        }
        if (isDash && dashInterval <= 0) {
            isDash = false;
            this.gameObject.GetComponent<PlayerStateManager>().canControlMovement = true;
            rb.velocity = Vector2.zero;
            Debug.Log("Dash End");
        }
        
    }
}