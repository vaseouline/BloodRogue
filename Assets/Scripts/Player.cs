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
    public GameObject bullet;
    public float bulletSpeed;
    public float fireRate;
    private float fireRateInterval;
    public float bulletTimer;
    

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
        if (mouse0 && fireRateInterval <= 0)
        {

            var bullet1 = Instantiate(bullet, this.gameObject.transform.position, this.gameObject.transform.rotation);
            Physics2D.IgnoreCollision(bullet1.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            Vector2 lookDir = mousePos - rb.position;
            bullet1.GetComponent<Rigidbody2D>().velocity = lookDir.normalized * bulletSpeed;
            fireRateInterval = fireRate;


        }

    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement.normalized * moveSpeed * Time.fixedDeltaTime);

        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        //rb.rotation = angle;

        if (fireRateInterval > 0)
        {
            fireRateInterval--;
        }
        else if (fireRateInterval < 0)
        {
            fireRateInterval = 0;
        }


    }
}