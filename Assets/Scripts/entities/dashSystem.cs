using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dashSystem : MonoBehaviour 
{

    public float dashDistance;
    public float dashDuration;
    private Rigidbody2D rb;
    private Vector2 dashDirection;
    private bool isDash;

    void Start() {
        // rb = this.gameObject.GetComponent<Rigidbody2D>();
        isDash = false;
    }
    public void Dash(Vector2 movement) {
        dashDirection = movement.normalized;
        Debug.Log("Dashing start");
        
    }

    void Update() {
        if (isDash) {
            Vector2 dashVelocity = Vector2.Scale(dashDirection, dashDistance * new Vector2((Mathf.Log(1f / (Time.deltaTime * rb.drag + 1)) / -Time.deltaTime),(Mathf.Log(1f / (Time.deltaTime * rb.drag + 1)) / -Time.deltaTime)));
        rb.AddForce(dashVelocity, ForceMode2D.Force);
        }
        
    }

    void FixedUpdate() {

            // rb.MovePosition(rb.position + dashDirection.normalized * dashDistance * Time.fixedDeltaTime);
    }
}